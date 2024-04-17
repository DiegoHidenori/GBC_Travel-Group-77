using GBC_Travel_Group_77.Models;
using System;
using Xunit;

namespace GBC_Travel_Group_77.Tests.Models
{
    public class HotelBookingTests
    {
        [Fact]
        public void HotelBooking_Properties_Should_Set_Correctly()
        {
            int id = 1;
            int hotelId = 2;
            DateTime bookingDate = DateTime.Now;

            var hotelBooking = new HotelBooking
            {
                id = id,
                hotelId = hotelId,
                bookingDate = bookingDate
            };

            Assert.Equal(id, hotelBooking.id);
            Assert.Equal(hotelId, hotelBooking.hotelId);
            Assert.Equal(bookingDate, hotelBooking.bookingDate);
        }

        [Fact]
        public void HotelBooking_Properties_Should_Have_Correct_Data_Types()
        {
            var hotelBooking = new HotelBooking();

            Assert.IsType<int>(hotelBooking.id);
            Assert.IsType<int>(hotelBooking.hotelId);
            Assert.IsType<DateTime>(hotelBooking.bookingDate);
        }
    }
}
