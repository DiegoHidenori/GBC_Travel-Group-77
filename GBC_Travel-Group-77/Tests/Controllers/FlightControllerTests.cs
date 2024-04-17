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
    public class FlightControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult_WithListOfFlights()
        {
            var flights = new List<Flight>();
            var mockFlightRepository = new Mock<IFlightRepository>();
            mockFlightRepository.Setup(repo => repo.AllFlights).Returns(flights);

            var mockLogger = new Mock<ILogger<FlightController>>();
            var mockSessionService = new Mock<ISessionService>();

            var controller = new FlightController(mockFlightRepository.Object, null, mockLogger.Object, mockSessionService.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Flight>>(viewResult.ViewData.Model);
            Assert.Equal(flights, model);
        }

        [Fact]
        public void Index_ThrowsException_ReturnsNotFoundViewResult()
        {
            var mockFlightRepository = new Mock<IFlightRepository>();
            mockFlightRepository.Setup(repo => repo.AllFlights).Throws(new Exception());

            var mockLogger = new Mock<ILogger<FlightController>>();
            var mockSessionService = new Mock<ISessionService>();

            var controller = new FlightController(mockFlightRepository.Object, null, mockLogger.Object, mockSessionService.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewData.Model);
        }

        [Fact]
        public void FlightsList_ReturnsViewResult_WithListOfFlights()
        {
            var flights = new List<Flight>();
            var mockFlightRepository = new Mock<IFlightRepository>();
            mockFlightRepository.Setup(repo => repo.AllFlights).Returns(flights);

            var mockLogger = new Mock<ILogger<FlightController>>();
            var mockSessionService = new Mock<ISessionService>();

            var controller = new FlightController(mockFlightRepository.Object, null, mockLogger.Object, mockSessionService.Object);

            var result = controller.FlightsList();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Flight>>(viewResult.ViewData.Model);
            Assert.Equal(flights, model);
        }

        [Fact]
        public void Details_WithValidId_ReturnsViewResult_WithFlight()
        {
            var flight = new Flight { id = 1, company = "Test Flight" };
            var mockFlightRepository = new Mock<IFlightRepository>();
            mockFlightRepository.Setup(repo => repo.GetFlightById(1)).Returns(flight);

            var mockLogger = new Mock<ILogger<FlightController>>();
            var mockSessionService = new Mock<ISessionService>();

            var controller = new FlightController(mockFlightRepository.Object, null, mockLogger.Object, mockSessionService.Object);

            var result = controller.Details(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Flight>(viewResult.ViewData.Model);
            Assert.Equal(flight, model);
        }
    }
}
