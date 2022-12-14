namespace ManchesterAirportParking.Public.Api.Models.Public.Api.Models
{
    using NodaTime;

    public class ApiReservationRequest
    {
        public LocalDate From { get; set; }

        public string RegistrationPlate { get; set; }

        public int SpaceId { get; set; }

        public LocalDate To { get; set; }
    }
}
