
using Moq;
using Interview_Task_TruckAPI.Controllers;
using Interview_Task_TruckAPI.Data;
using Interview_Task_TruckAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interview_Task_TruckAPITests
{
    public class EditTruckControllerTests       // Unit tests for the endpoint - /EditTruck
    {
        [Fact]  // xUnit attribute to mark a method as a test method. Executes a test
        public async Task EditTruck_ValidIdAndUpdatedTruck_ReturnsOkResult()
        {
            // Arrange - Setting up in-memory database 
            var mockContext = new Mock<ApplicationDbContext>();

            // Seed the database with test data
            var existingTruck = new Truck { Id = Guid.NewGuid(), Registration = "JH67KII", GrossWeight = 4500 };
            mockContext.Setup(c => c.Trucks.FindAsync(It.IsAny<Guid>())).ReturnsAsync(existingTruck);
            var controller = new EditTruckController(mockContext.Object);
            var updatedTruck = new Truck { Id = existingTruck.Id, Registration = "FG18YHT", GrossWeight = 5000 };

            // Act - Ensure truck information is edited
            var result = await controller.EditTruck(existingTruck.Id, updatedTruck);

            // Assert - check if OkResult is the expected result
            Assert.IsType<OkResult>(result);
        }

        [Fact]  // xUnit attribute to mark a method as a test method. Executes a test
        public async Task EditTruck_InvalidId_ReturnsBadRequestResult()
        {
            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            var controller = new EditTruckController(mockContext.Object);

            // Act - Ensure that a BadRequestObjectResult is returned 
            var result = await controller.EditTruck(Guid.Empty, new Truck());

            // Assert - Check if BadRequestObjectResult is the expected result
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]  // xUnit attribute to mark a method as a test method. Executes a test
        public async Task EditTruck_TruckNotFound_ReturnsNotFoundResult()
        {
            // Arrange - Use in-memory database context to fetch updated truck from database
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Trucks.FindAsync(It.IsAny<Guid>())).ReturnsAsync((Truck)null);
            var controller = new EditTruckController(mockContext.Object);
            var updatedTruck = new Truck { Id = Guid.NewGuid(), Registration = "FG18YHT", GrossWeight = 5000 };

            // Act - Ensure that a NotFoundResult is returned
            var result = await controller.EditTruck(Guid.NewGuid(), updatedTruck);

            // Assert - Check if NotFoundResult is the expected result 
            Assert.IsType<NotFoundResult>(result);
        }
    }
}

