namespace NapocaBike.Models
{
    public class LocationData
    {
        public IEnumerable<BikeRental> BikeRentals { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<LocationCategory> LocationCategories { get; set; }

    }
}
