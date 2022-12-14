namespace ManchesterAirportParking.Public.Api.Models.Public.Api.Models
{
    using NodaTime;

    public class ApiReservation
    {
        public LocalDate From { get; set; }

        public string Reference { get; set; }

        public string SpaceId { get; set; }

        public LocalDate To { get; set; }

        public string VehicleRegistrationPlate { get; set; }
    }
}
