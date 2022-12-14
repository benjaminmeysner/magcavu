namespace ManchesterAirportParking.Public.Api.Models
{
    using NodaTime;

    public class ApiAvailability
    {
        public LocalDate From { get; set; }

        public int NumberOfAvailableSpaces { get; set; }

        public string[] Spaces { get; set; }

        public LocalDate To { get; set; }
    }
}
