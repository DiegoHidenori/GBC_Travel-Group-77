using GBC_Travel_Group_77.Models;
using System;
using Xunit;

namespace GBC_Travel_Group_77.Tests.Models
{
    public class CarBookingTests
    {
        [Fact]
        public void CarBooking_Properties_Should_Set_Correctly()
        {
            int id = 1;
            int carId = 123;
            DateTime bookingDate = DateTime.Now;

            var carBooking = new CarBooking
            {
                id = id,
                carId = carId,
                bookingDate = bookingDate
            };

            Assert.Equal(id, carBooking.id);
            Assert.Equal(carId, carBooking.carId);
            Assert.Equal(bookingDate, carBooking.bookingDate);
        }

        [Fact]
        public void CarBooking_Properties_Should_Have_Correct_Data_Types()
        {
            var carBooking = new CarBooking();

            Assert.IsType<int>(carBooking.id);
            Assert.IsType<int>(carBooking.carId);
            Assert.IsType<DateTime>(carBooking.bookingDate);
        }
    }
}
