namespace ManchesterAirportParking.Controllers
{
    using Base62;
    using ManchesterAirportParking.Public.Api.Models;
    using ManchesterAirportParking.Public.Api.Models.Public.Api.Models;
    using ManchesterAirportParking.Repository.Domain;
    using ManchesterAirportParking.Repository.Domain.Models;
    using ManchesterAirportParking.Repository.Domain.Repository.Domain.Models;
    using ManchesterAirportParking.Repository.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using NodaTime;

    [ApiController]
    [Route("reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly AppDbContext context;

        private readonly IReservationService reservationService;

        public ReservationsController(AppDbContext context, IReservationService reservationService)
        {
            this.context = context;
            this.reservationService = reservationService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ApiReservation>> CreateAsync(ApiReservationRequest? model)
        {
            if (model is null)
            {
                return this.BadRequest(this.ModelState);
            }

            model.From = LocalDate.Min(model.From, model.To);
            model.To = LocalDate.Max(model.From, model.To);

            IEnumerable<SpaceAvailability> availability = this.context.ParkingAreas.Include(x => x.Spaces)
                                                              .ThenInclude(x => x.Reservations)
                                                              .First()
                                                              .GetAvailabilityBetween(model.From, model.To)
                                                              .ToList();

            if (availability.All(x => x.Space.Id != model.SpaceId))
            {
                return this.BadRequest("no availability for parking");
            }

            try
            {
                Reservation reservation = await this.reservationService.CreateAsync(model.SpaceId, model.From, model.To, model.RegistrationPlate);

                return this.Ok(new ApiReservation
                               {
                                   From = reservation.From,
                                   To = reservation.To,
                                   SpaceId = reservation.Space.Alias,
                                   VehicleRegistrationPlate = reservation.Vehicle.RegistrationPlate,
                                   Reference = reservation.Reference.ToByteArray()
                                                          .ToBase62(),
                               });

                ;
            }
            catch (Exception e)
            {
                return this.BadRequest(e);
            }
        }

        [HttpPost("lookup")]
        public ActionResult<ApiAvailability> LookupAvailability(ApiAvailabilityRequest? model)
        {
            if (model is null)
            {
                return this.BadRequest(this.ModelState);
            }

            model.From = LocalDate.Min(model.From, model.To);
            model.To = LocalDate.Max(model.From, model.To);

            IEnumerable<SpaceAvailability> availability = this.context.ParkingAreas.Include(x => x.Spaces)
                                                              .ThenInclude(x => x.Reservations)
                                                              .First()
                                                              .GetAvailabilityBetween(model.From, model.To)
                                                              .ToList();

            return this.Ok(new ApiAvailability
                           {
                               NumberOfAvailableSpaces = availability.Count(),
                               Spaces = availability.Select(x => x.Space.Alias)
                                                    .ToArray(),
                               From = model.From,
                               To = model.To
                           });
        }

        [HttpPost("unreserve")]
        public async Task<ActionResult<ApiReservation>> UnReserveAsync(string reference)
        {
            if (reference.IsNullOrEmpty())
            {
                return this.BadRequest(this.ModelState);
            }

            Guid guid = new Guid(reference.FromBase62());

            Reservation? reservation = await this.context.Reservations.FirstOrDefaultAsync(x => x.Reference == guid);

            if (reservation == null)
            {
                return this.NotFound();
            }

            this.context.Reservations.Remove(reservation);
            await this.context.SaveChangesAsync();

            return this.Ok(reservation);
        }
    }
}
