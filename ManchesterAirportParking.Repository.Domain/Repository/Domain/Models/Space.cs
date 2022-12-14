namespace ManchesterAirportParking.Repository.Domain.Models
{
    public class Space : EntityBase
    {
        public string Alias { get; set; }

        public ParkingArea ParkingArea { get; set; }

        public int ParkingAreaId { get; set; }

        public string Reference { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
