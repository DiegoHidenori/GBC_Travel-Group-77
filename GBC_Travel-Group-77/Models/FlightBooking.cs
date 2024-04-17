using GBC_Travel_Group_77.Models;
using System;
using Xunit;

namespace GBC_Travel_Group_77.Models
{
    public class FlightBooking
    {
        public int id { get; set; }
        public int flightId { get; set; }
        public DateTime bookingDate { get; set; }
    }
}
