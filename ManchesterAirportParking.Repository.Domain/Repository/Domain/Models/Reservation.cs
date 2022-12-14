namespace ManchesterAirportParking.Repository.Domain.Models
{
    using NodaTime;

    public class Reservation : EntityBase
    {
        public LocalDate From { get; set; }

        public Guid Reference { get; set; }

        public Space Space { get; set; }

        public int SpaceId { get; set; }

        public LocalDate To { get; set; }

        public Vehicle Vehicle { get; set; }

        public int VehicleId { get; set; }
    }
}
