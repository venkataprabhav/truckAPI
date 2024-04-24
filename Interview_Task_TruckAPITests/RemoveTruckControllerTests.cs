using Interview_Task_TruckAPI.Controllers;
using Interview_Task_TruckAPI.Data;
using Interview_Task_TruckAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Task_TruckAPITests
{
    public class RemoveTruckControllerTests     // Unit tests for the endpoint - /RemoveTruck
    {
        [Fact] // xUnit attribute to mark a method as a test method. Executes a test
        public async Task GetTrucks_ReturnsTruckList_ForRemoval()
        {
            // Arrange - Setting up in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database2")
                .Options;

            // Seed test database with test truck information
            using (var context = new ApplicationDbContext(options))
            {
                context.Trucks.Add(new Truck { Id = Guid.NewGuid(), Registration = "HG67JHH", GrossWeight = 5000 });
                context.Trucks.Add(new Truck { Id = Guid.NewGuid(), Registration = "KS69KIR", GrossWeight = 5000 });
                await context.SaveChangesAsync();
            }

            // Use a separate instance of the test database context to verify that the correct data was saved to the test database
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new RemoveTruckController(context);

                // Act - Get truck information
                var result = await controller.GetTrucks();

                // Assert
                var trucks = Assert.IsType<ActionResult<IEnumerable<Truck>>>(result);

                Assert.NotNull(trucks.Value); // Check that value is not null
                Assert.NotEmpty(trucks.Value); // Check that truck list is not empty
            }
        }

        [Fact]
        public async Task RemoveTruck_WithValidId_ReturnsOkResult()
        {
            // Arrange - use in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database2")
                .Options;

            var truckId = Guid.NewGuid();

            // Seed test database with test truck information
            using (var context = new ApplicationDbContext(options))
            {
                context.Trucks.Add(new Truck { Id = truckId, Registration = "ABC123", GrossWeight = 1000 });
                await context.SaveChangesAsync();
            }

            // Use a separate instance of the test database context to verify that the correct data was saved to the test database
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new RemoveTruckController(context);

                // Act
                var result = await controller.RemoveTruck(truckId);

                // Assert
                Assert.IsType<OkResult>(result);
            }
        }

        [Fact]
        public async Task RemoveTruck_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange - use in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database2")
                .Options;

            var truckId = Guid.NewGuid();

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new RemoveTruckController(context);

                // Act - Ensure truck is removed
                var result = await controller.RemoveTruck(truckId);

                // Assert - Check if NotFoundResult is the expected result
                Assert.IsType<NotFoundResult>(result);
            }
        }
    }
}
