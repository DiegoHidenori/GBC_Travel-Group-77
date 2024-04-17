using GBC_Travel_Group_77.Controllers;
using GBC_Travel_Group_77.Models;
using GBC_Travel_Group_77.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace GBC_Travel_Group_77.Tests.Controllers
{
    public class HotelControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult_WithListOfHotels()
        {
            var hotels = new List<Hotel>();
            var mockHotelRepository = new Mock<IHotelRepository>();
            mockHotelRepository.Setup(repo => repo.AllHotels).Returns(hotels);

            var mockLogger = new Mock<ILogger<HotelController>>();
            var mockSessionService = new Mock<ISessionService>();

            var controller = new HotelController(mockHotelRepository.Object, null, mockLogger.Object, mockSessionService.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Hotel>>(viewResult.ViewData.Model);
            Assert.Equal(hotels, model);
        }

        [Fact]
        public void Index_ThrowsException_ReturnsNotFoundViewResult()
        {
            var mockHotelRepository = new Mock<IHotelRepository>();
            mockHotelRepository.Setup(repo => repo.AllHotels).Throws(new Exception());

            var mockLogger = new Mock<ILogger<HotelController>>();
            var mockSessionService = new Mock<ISessionService>();

            var controller = new HotelController(mockHotelRepository.Object, null, mockLogger.Object, mockSessionService.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewData.Model);
        }

        [Fact]
        public void HotelsList_ReturnsViewResult_WithListOfHotels()
        {
            var hotels = new List<Hotel>();
            var mockHotelRepository = new Mock<IHotelRepository>();
            mockHotelRepository.Setup(repo => repo.AllHotels).Returns(hotels);

            var mockLogger = new Mock<ILogger<HotelController>>();
            var mockSessionService = new Mock<ISessionService>();

            var controller = new HotelController(mockHotelRepository.Object, null, mockLogger.Object, mockSessionService.Object);

            var result = controller.HotelsList();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Hotel>>(viewResult.ViewData.Model);
            Assert.Equal(hotels, model);
        }

        [Fact]
        public void Details_WithValidId_ReturnsViewResult_WithHotel()
        {
            var hotel = new Hotel { id = 1, name = "Test Hotel" };
            var mockHotelRepository = new Mock<IHotelRepository>();
            mockHotelRepository.Setup(repo => repo.GetHotelById(1)).Returns(hotel);

            var mockLogger = new Mock<ILogger<HotelController>>();
            var mockSessionService = new Mock<ISessionService>();

            var controller = new HotelController(mockHotelRepository.Object, null, mockLogger.Object, mockSessionService.Object);

            var result = controller.Details(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Hotel>(viewResult.ViewData.Model);
            Assert.Equal(hotel, model);
        }
    }
}
