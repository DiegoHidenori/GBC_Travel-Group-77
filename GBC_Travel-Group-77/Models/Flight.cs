namespace GBC_Travel_Group_77.Models
{
    public class Flight
    {
        public int id { get; set; }
        public string category { get; set; }
        public string company { get; set; }
        public string departureAirport { get; set; }
        public string departureGate { get; set; }
        public string departureDate { get; set; }
        public string arrivalAirport { get; set; }
        public string arrivalGate { get; set; }
        public string arrivalDate { get; set; }
        public int flightDuration { get; set; }
        public int totalSeats { get; set; }
        public int availableSeats { get; set; }
        public string flightStatus { get; set; }
        public double price { get; set; }
        public bool isHotDeal { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
    }
}
