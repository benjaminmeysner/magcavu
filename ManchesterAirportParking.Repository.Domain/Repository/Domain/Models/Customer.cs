namespace ManchesterAirportParking.Repository.Domain
{
    using ManchesterAirportParking.Repository.Domain.Models;

    public class Customer : EntityBase
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
