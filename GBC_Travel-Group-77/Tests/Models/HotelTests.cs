using GBC_Travel_Group_77.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace GBC_Travel_Group_77.Tests.Models
{
    public class HotelTests
    {
        [Fact]
        public void Name_Should_Not_Be_Empty()
        {
            var hotel = new Hotel();
            Assert.Throws<ValidationException>(() => ValidateModel(hotel));
        }

        [Fact]
        public void Address_Should_Not_Be_Empty()
        {
            var hotel = new Hotel();
            Assert.Throws<ValidationException>(() => ValidateModel(hotel));
        }

        [Fact]
        public void City_Should_Not_Be_Empty()
        {
            var hotel = new Hotel();
            Assert.Throws<ValidationException>(() => ValidateModel(hotel));
        }

        [Fact]
        public void Country_Should_Not_Be_Empty()
        {
            var hotel = new Hotel();
            Assert.Throws<ValidationException>(() => ValidateModel(hotel));
        }

        private void ValidateModel(object model)
        {
            var validationContext = new ValidationContext(model);
            Validator.ValidateObject(model, validationContext, validateAllProperties: true);
        }

        [Fact]
        public void Hotel_Properties_Should_Set_Correctly()
        {
            int id = 2;
            string category = "Standard";
            string name = "City View Hotel";
            string address = "456 Elm St";
            string city = "Los Angeles";
            string country = "USA";
            int starRating = 3;
            string description = "A cozy hotel with a view of the city skyline.";
            int totalRooms = 50;
            int availableRooms = 40;
            string roomTypes = "Single, Double";
            string contactInfo = "info@cityviewhotel.com";
            double price = 150.00;
            bool isHotDeal = true;
            string shortDescription = "Affordable hotel in Los Angeles";
            string longDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dictum erat eget est aliquet.";
            string imageUrl = "https://example.com/cityview.jpg";

            var hotel = new Hotel
            {
                id = id,
                category = category,
                name = name,
                address = address,
                city = city,
                country = country,
                starRating = starRating,
                description = description,
                totalRooms = totalRooms,
                availableRooms = availableRooms,
                roomTypes = roomTypes,
                contactInfo = contactInfo,
                price = price,
                isHotDeal = isHotDeal,
                shortDescription = shortDescription,
                longDescription = longDescription,
                imageUrl = imageUrl
            };

            Assert.Equal(id, hotel.id);
            Assert.Equal(category, hotel.category);
            Assert.Equal(name, hotel.name);
            Assert.Equal(address, hotel.address);
            Assert.Equal(city, hotel.city);
            Assert.Equal(country, hotel.country);
            Assert.Equal(starRating, hotel.starRating);
            Assert.Equal(description, hotel.description);
            Assert.Equal(totalRooms, hotel.totalRooms);
            Assert.Equal(availableRooms, hotel.availableRooms);
            Assert.Equal(roomTypes, hotel.roomTypes);
            Assert.Equal(contactInfo, hotel.contactInfo);
            Assert.Equal(price, hotel.price);
            Assert.Equal(isHotDeal, hotel.isHotDeal);
            Assert.Equal(shortDescription, hotel.shortDescription);
            Assert.Equal(longDescription, hotel.longDescription);
            Assert.Equal(imageUrl, hotel.imageUrl);
        }

        [Fact]
        public void Hotel_Properties_Should_Have_Correct_Data_Types()
        {
            var hotel = new Hotel();

            Assert.IsType<int>(hotel.id);
            Assert.IsType<string>(hotel.category);
            Assert.IsType<string>(hotel.name);
            Assert.IsType<string>(hotel.address);
            Assert.IsType<string>(hotel.city);
            Assert.IsType<string>(hotel.country);
            Assert.IsType<int>(hotel.starRating);
            Assert.IsType<string>(hotel.description);
            Assert.IsType<int>(hotel.totalRooms);
            Assert.IsType<int>(hotel.availableRooms);
            Assert.IsType<string>(hotel.roomTypes);
            Assert.IsType<string>(hotel.contactInfo);
            Assert.IsType<double>(hotel.price);
            Assert.IsType<bool>(hotel.isHotDeal);
            Assert.IsType<string>(hotel.shortDescription);
            Assert.IsType<string>(hotel.longDescription);
            Assert.IsType<string>(hotel.imageUrl);
        }
    }
}
