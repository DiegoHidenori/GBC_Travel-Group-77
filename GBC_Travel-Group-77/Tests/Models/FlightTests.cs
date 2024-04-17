using GBC_Travel_Group_77.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace GBC_Travel_Group_77.Tests.Models
{
    public class FlightTests
    {
        [Fact]
        public void Company_Should_Not_Be_Empty()
        {
            var flight = new Flight();
            Assert.Throws<ValidationException>(() => ValidateModel(flight));
        }

        [Fact]
        public void DepartureAirport_Should_Not_Be_Empty()
        {
            var flight = new Flight();
            Assert.Throws<ValidationException>(() => ValidateModel(flight));
        }

        [Fact]
        public void ArrivalAirport_Should_Not_Be_Empty()
        {
            var flight = new Flight();
            Assert.Throws<ValidationException>(() => ValidateModel(flight));
        }

        private void ValidateModel(object model)
        {
            var validationContext = new ValidationContext(model);
            Validator.ValidateObject(model, validationContext, validateAllProperties: true);
        }

        [Fact]
        public void Flight_Properties_Should_Set_Correctly()
        {
            int id = 1;
            string category = "Economy";
            string company = "Airline Inc.";
            string departureAirport = "JFK";
            string departureGate = "A1";
            string departureDate = "2024-04-20 10:00 AM";
            string arrivalAirport = "LHR";
            string arrivalGate = "B2";
            string arrivalDate = "2024-04-21 5:00 PM";
            int flightDuration = 1200;
            int totalSeats = 200;
            int availableSeats = 180;
            string flightStatus = "On time";
            double price = 500.00;
            bool isHotDeal = false;
            string shortDescription = "test";
            string longDescription = "test";

            var flight = new Flight
            {
                id = id,
                category = category,
                company = company,
                departureAirport = departureAirport,
                departureGate = departureGate,
                departureDate = departureDate,
                arrivalAirport = arrivalAirport,
                arrivalGate = arrivalGate,
                arrivalDate = arrivalDate,
                flightDuration = flightDuration,
                totalSeats = totalSeats,
                availableSeats = availableSeats,
                flightStatus = flightStatus,
                price = price,
                isHotDeal = isHotDeal,
                shortDescription = shortDescription,
                longDescription = longDescription
            };

            Assert.Equal(id, flight.id);
            Assert.Equal(category, flight.category);
            Assert.Equal(company, flight.company);
            Assert.Equal(departureAirport, flight.departureAirport);
            Assert.Equal(departureGate, flight.departureGate);
            Assert.Equal(departureDate, flight.departureDate);
            Assert.Equal(arrivalAirport, flight.arrivalAirport);
            Assert.Equal(arrivalGate, flight.arrivalGate);
            Assert.Equal(arrivalDate, flight.arrivalDate);
            Assert.Equal(flightDuration, flight.flightDuration);
            Assert.Equal(totalSeats, flight.totalSeats);
            Assert.Equal(availableSeats, flight.availableSeats);
            Assert.Equal(flightStatus, flight.flightStatus);
            Assert.Equal(price, flight.price);
            Assert.Equal(isHotDeal, flight.isHotDeal);
            Assert.Equal(shortDescription, flight.shortDescription);
            Assert.Equal(longDescription, flight.longDescription);
        }

        [Fact]
        public void Flight_Properties_Should_Have_Correct_Data_Types()
        {
            var flight = new Flight();

            Assert.IsType<int>(flight.id);
            Assert.IsType<string>(flight.category);
            Assert.IsType<string>(flight.company);
            Assert.IsType<string>(flight.departureAirport);
            Assert.IsType<string>(flight.departureGate);
            Assert.IsType<string>(flight.departureDate);
            Assert.IsType<string>(flight.arrivalAirport);
            Assert.IsType<string>(flight.arrivalGate);
            Assert.IsType<string>(flight.arrivalDate);
            Assert.IsType<int>(flight.flightDuration);
            Assert.IsType<int>(flight.totalSeats);
            Assert.IsType<int>(flight.availableSeats);
            Assert.IsType<string>(flight.flightStatus);
            Assert.IsType<double>(flight.price);
            Assert.IsType<bool>(flight.isHotDeal);
            Assert.IsType<string>(flight.shortDescription);
            Assert.IsType<string>(flight.longDescription);
        }
    }
}
