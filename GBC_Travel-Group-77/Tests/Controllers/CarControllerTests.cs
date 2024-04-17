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
    public class CarControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult_WithListOfCars()
        {
            var cars = new List<Car>();
            var mockCarRepository = new Mock<ICarRepository>();
            mockCarRepository.Setup(repo => repo.AllCars).Returns(cars);

            var mockLogger = new Mock<ILogger<CarController>>();
            var mockSessionService = new Mock<ISessionService>();

            var controller = new CarController(mockCarRepository.Object, null, mockLogger.Object, mockSessionService.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Car>>(viewResult.ViewData.Model);
            Assert.Equal(cars, model);
        }

        [Fact]
        public void Index_ThrowsException_ReturnsNotFoundViewResult()
        {
            var mockCarRepository = new Mock<ICarRepository>();
            mockCarRepository.Setup(repo => repo.AllCars).Throws(new Exception());

            var mockLogger = new Mock<ILogger<CarController>>();
            var mockSessionService = new Mock<ISessionService>();

            var controller = new CarController(mockCarRepository.Object, null, mockLogger.Object, mockSessionService.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewData.Model);
        }

        [Fact]
        public void CarsList_ReturnsViewResult_WithListOfCars()
        {
            var cars = new List<Car>();
            var mockCarRepository = new Mock<ICarRepository>();
            mockCarRepository.Setup(repo => repo.AllCars).Returns(cars);

            var mockLogger = new Mock<ILogger<CarController>>();
            var mockSessionService = new Mock<ISessionService>();

            var controller = new CarController(mockCarRepository.Object, null, mockLogger.Object, mockSessionService.Object);

            var result = controller.CarsList();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Car>>(viewResult.ViewData.Model);
            Assert.Equal(cars, model);
        }

        [Fact]
        public void Details_WithValidId_ReturnsViewResult_WithCar()
        {
            var car = new Car { id = 1, make = "Test Car" };
            var mockCarRepository = new Mock<ICarRepository>();
            mockCarRepository.Setup(repo => repo.GetCarById(1)).Returns(car);

            var mockLogger = new Mock<ILogger<CarController>>();
            var mockSessionService = new Mock<ISessionService>();

            var controller = new CarController(mockCarRepository.Object, null, mockLogger.Object, mockSessionService.Object);

            var result = controller.Details(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Car>(viewResult.ViewData.Model);
            Assert.Equal(car, model);
        }
    }
}
