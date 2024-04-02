namespace GBC_Travel_Group_77.Models
{
    public class FlightBooking
    {
        public int id { get; set; }
        public int flightId { get; }
        public DateTime bookingDate { get; set; }
    }
}
