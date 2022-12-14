namespace ManchesterAirportParking.Repository.Services
{
    using ManchesterAirportParking.Repository.Domain;
    using ManchesterAirportParking.Repository.Domain.Models;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using NodaTime;

    public interface IReservationService
    {
        Task<Reservation> CreateAsync(int spaceId, LocalDate from, LocalDate to, string vehicleRegistrationPlate);
    }

    public class ReservationService : IReservationService
    {
        private readonly AppDbContext context;

        public ReservationService(AppDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc />
        public async Task<Reservation> CreateAsync(int spaceId, LocalDate from, LocalDate to, string vehicleRegistrationPlate)
        {
            Vehicle? existingVehicle = this.context.Vehicles.FirstOrDefault(x => x.RegistrationPlate == vehicleRegistrationPlate) ??
                                       new Vehicle
                                       {
                                           RegistrationPlate = vehicleRegistrationPlate
                                       };

            EntityEntry<Reservation> result = await this.context.Reservations.AddAsync(new Reservation
                                                                                       {
                                                                                           From = from,
                                                                                           To = to,
                                                                                           SpaceId = spaceId,
                                                                                           Vehicle = existingVehicle,
                                                                                           Reference = Guid.NewGuid()
                                                                                       });

            await this.context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
