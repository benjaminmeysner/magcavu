namespace ManchesterAirportParking.Public.Api.Models
{
    using NodaTime;

    public class ApiAvailabilityRequest
    {
        public LocalDate From { get; set; }

        public LocalDate To { get; set; }
    }
}
