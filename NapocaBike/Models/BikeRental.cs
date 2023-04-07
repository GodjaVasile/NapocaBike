namespace NapocaBike.Models
{
    public class BikeRental
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int BikesAvailable { get; set; }
        public int EmptySpaces { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

