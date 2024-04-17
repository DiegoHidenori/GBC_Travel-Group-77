using GBC_Travel_Group_77.Controllers;
using GBC_Travel_Group_77.Models;
using GBC_Travel_Group_77.Services;
using GBC_Travel_Group_77.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace GBC_Travel_Group_77.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult_WithHomeViewModel()
        {
            var mockFlightRepository = new Mock<IFlightRepository>();
            mockFlightRepository.Setup(repo => repo.FlightsHotDeals).Returns(new List<Flight>());

            var mockCarRepository = new Mock<ICarRepository>();
            mockCarRepository.Setup(repo => repo.CarsHotDeals).Returns(new List<Car>());

            var mockHotelRepository = new Mock<IHotelRepository>();
            mockHotelRepository.Setup(repo => repo.HotelsHotDeals).Returns(new List<Hotel>());

            var mockLogger = new Mock<ILogger<HomeController>>();
            var mockSessionService = new Mock<ISessionService>();

            var controller = new HomeController(mockFlightRepository.Object, mockCarRepository.Object, mockHotelRepository.Object, mockLogger.Object, mockSessionService.Object);


            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomeViewModel>(viewResult.ViewData.Model);
            Assert.Empty(model.flightsHotDeals);
            Assert.Empty(model.carsHotDeals);
            Assert.Empty(model.hotelsHotDeals);
        }

        [Fact]
        public void NotFound_ReturnsNotFoundView_WhenStatusCodeIs404()
        {
            var mockLogger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(null, null, null, mockLogger.Object, null);

            var result = controller.NotFound(404);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("NotFound", viewResult.ViewName);
        }

        [Fact]
        public void NotFound_ReturnsErrorView_WhenStatusCodeIsNot404()
        {
            var mockLogger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(null, null, null, mockLogger.Object, null);

            var result = controller.NotFound(500);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Error", viewResult.ViewName);
        }

        [Fact]
        public void Error_ReturnsErrorView_WithErrorMessage()
        {
            var mockLogger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(null, null, null, mockLogger.Object, null);

            var result = controller.Error();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ErrorViewModel>(viewResult.ViewData.Model);
            Assert.NotNull(model.RequestId);
        }
    }
}
