namespace ManchesterAirportParking.Repository.Domain.Models
{
    public class Vehicle : EntityBase
    {
        public string RegistrationPlate { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
