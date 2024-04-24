using Xunit;
using Moq;
using Interview_Task_TruckAPI.Controllers;
using Interview_Task_TruckAPI.Data;
using Interview_Task_TruckAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;

namespace Interview_Task_TruckAPITests
{
    public class TruckControllerTests       // Unit tests for the endpoint - /Truck
    {
        [Fact]
        public async Task PostTruck_ValidTruck_ReturnsCreatedAtAction()
        {
            // Arrange - Setting up in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database2")
                .Options;

            
            // Created test truck with truck information
            var truck = new Truck
            {
                Id = Guid.NewGuid(),
                Registration = "YU15NBB",
                GrossWeight = 5400,
                TareWeight = 2400,
                NettWeight = 3000,
                Haulier = "Amazon"
            };

            // Act
            // Using in-memory database context
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new TruckController(context);

                var result = await controller.PostTruck(truck);

                // Assert
                var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
                Assert.Equal(nameof(TruckController.GetTrucks), createdAtActionResult.ActionName);

                // Checks if information of the created test truck matches the information of the test truck 
                var createdTruck = Assert.IsType<Truck>(createdAtActionResult.Value);
                Assert.Equal(truck.Id, createdTruck.Id);
                Assert.Equal(truck.Registration, createdTruck.Registration);
                Assert.Equal(truck.GrossWeight, createdTruck.GrossWeight);
                Assert.Equal(truck.TareWeight, createdTruck.TareWeight);
                Assert.Equal(truck.NettWeight, createdTruck.NettWeight);
                Assert.Equal(truck.Haulier, createdTruck.Haulier);
            }
        }


        [Fact]
        public async Task PostTruck_WithNullData_ReturnsBadRequest()
        {
            // Using in-memory database context 
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database2")
                .Options;

            Truck truck = null; 

            // Act
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new TruckController(context);
                var result = await controller.PostTruck(truck);

                // Assert
                // Ensure that a BadRequestObjectResult is returned 
                var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
                
                // Check if BadRequestObjectResult is the expected result
                Assert.Equal("Truck data is required", badRequestResult.Value);
            }
        }
    }
}
