using GBC_Travel_Group_77.Models;
using Xunit;
using System;
using System.ComponentModel.DataAnnotations;

namespace GBC_Travel_Group_77.Tests.Models
{
    public class CarTests
    {
        [Fact]
        public void Make_Should_Not_Be_Empty()
        {
            var car = new Car();
            Assert.Throws<ValidationException>(() => ValidateModel(car));
        }

        [Fact]
        public void Model_Should_Not_Be_Empty()
        {
            var car = new Car();
            Assert.Throws<ValidationException>(() => ValidateModel(car));
        }

        [Fact]
        public void Type_Should_Not_Be_Empty()
        {
            var car = new Car();
            Assert.Throws<ValidationException>(() => ValidateModel(car));
        }

        [Fact]
        public void YearManufactured_Should_Not_Be_Empty()
        {
            var car = new Car();
            Assert.Throws<ValidationException>(() => ValidateModel(car));
        }

        private void ValidateModel(object model)
        {
            var validationContext = new ValidationContext(model);
            Validator.ValidateObject(model, validationContext, validateAllProperties: true);
        }

        [Fact]
        public void Car_Properties_Should_Set_Correctly()
        {
            string category = "SUV";
            int id = 1;
            string make = "Toyota";
            string model = "RAV4";
            string type = "SUV";
            int yearManufactured = 2020;
            string color = "Black";
            string licensePlate = "ABC123";
            int seatCapacity = 5;
            bool isAvailable = true;
            double price = 50000.00;
            bool isHotDeal = false;
            string shortDescription = "Compact SUV";
            string longDescription = "Spacious interior, advanced safety features";
            string imageUrl = "/img/cars/rav4.jpg";

            var car = new Car
            {
                category = category,
                id = id,
                make = make,
                model = model,
                type = type,
                yearManufactured = yearManufactured,
                color = color,
                licensePlate = licensePlate,
                seatCapacity = seatCapacity,
                isAvailable = isAvailable,
                price = price,
                isHotDeal = isHotDeal,
                shortDescription = shortDescription,
                longDescription = longDescription,
                imageUrl = imageUrl
            };

            Assert.Equal(category, car.category);
            Assert.Equal(id, car.id);
            Assert.Equal(make, car.make);
            Assert.Equal(model, car.model);
            Assert.Equal(type, car.type);
            Assert.Equal(yearManufactured, car.yearManufactured);
            Assert.Equal(color, car.color);
            Assert.Equal(licensePlate, car.licensePlate);
            Assert.Equal(seatCapacity, car.seatCapacity);
            Assert.Equal(isAvailable, car.isAvailable);
            Assert.Equal(price, car.price);
            Assert.Equal(isHotDeal, car.isHotDeal);
            Assert.Equal(shortDescription, car.shortDescription);
            Assert.Equal(longDescription, car.longDescription);
            Assert.Equal(imageUrl, car.imageUrl);
        }

        [Fact]
        public void Car_Properties_Should_Have_Correct_Data_Types()
        {
            var car = new Car();

            Assert.IsType<string>(car.category);
            Assert.IsType<int>(car.id);
            Assert.IsType<string>(car.make);
            Assert.IsType<string>(car.model);
            Assert.IsType<string>(car.type);
            Assert.IsType<int>(car.yearManufactured);
            Assert.IsType<string>(car.color);
            Assert.IsType<string>(car.licensePlate);
            Assert.IsType<int>(car.seatCapacity);
            Assert.IsType<bool>(car.isAvailable);
            Assert.IsType<double>(car.price);
            Assert.IsType<bool>(car.isHotDeal);
            Assert.IsType<string>(car.shortDescription);
            Assert.IsType<string>(car.longDescription);
            Assert.IsType<string>(car.imageUrl);
        }
    }
}
