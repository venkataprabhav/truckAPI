using Xunit;
using Moq;
using Interview_Task_TruckAPI.Controllers;
using Interview_Task_TruckAPI.Data;
using Interview_Task_TruckAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Interview_Task_TruckAPITests
{
    public class TrucksControllerTests  // Unit test for the endpoint - /Trucks
    {
        [Fact]
        public async Task GetTrucks_ReturnsTruckInformation()
        {
            // Arrange - Setting up in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            // Seed the database with test data
            using (var context = new ApplicationDbContext(options))
            {
                context.Trucks.Add(new Truck { Id = Guid.NewGuid(), Registration = "HG67JHH", GrossWeight = 5000 });
                context.Trucks.Add(new Truck { Id = Guid.NewGuid(), Registration = "KS69KIR", GrossWeight = 5000 });
                await context.SaveChangesAsync();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new TrucksController(context);

                // Act
                var result = await controller.GetTrucks();

                // Assert
                var trucks = Assert.IsType<ActionResult<IEnumerable<Truck>>>(result);

                // Checking if NotNull is returned
                Assert.NotNull(trucks.Value); 

                // Checking if information of 2 trucks is returned
                Assert.Equal(2, trucks.Value.Count()); 
            }
        }
    }
}
