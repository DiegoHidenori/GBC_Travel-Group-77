using GBC_Travel_Group_77.Models;
using Xunit;

namespace GBC_Travel_Group_77.Tests.Models
{
    public class FlightBookingTests
    {
        [Fact]
        public void FlightBooking_Properties_Should_Set_Correctly()
        {
            int id = 1;
            int flightId = 123;
            DateTime bookingDate = DateTime.Now;

            var flightBooking = new FlightBooking
            {
                id = id,
                flightId = flightId,
                bookingDate = bookingDate
            };

            Assert.Equal(id, flightBooking.id);
            Assert.Equal(flightId, flightBooking.flightId);
            Assert.Equal(bookingDate, flightBooking.bookingDate);
        }

        [Fact]
        public void FlightBooking_Properties_Should_Have_Correct_Data_Types()
        {
            var flightBooking = new FlightBooking();

            Assert.IsType<int>(flightBooking.id);
            Assert.IsType<int>(flightBooking.flightId);
            Assert.IsType<DateTime>(flightBooking.bookingDate);
        }
    }
}
