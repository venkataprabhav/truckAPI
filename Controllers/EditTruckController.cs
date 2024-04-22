using Interview_Task_TruckAPI.Data;
using Interview_Task_TruckAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interview_Task_TruckAPI.Controllers
{
    [ApiController]             // This attribute indicates that this Controller handles HTTP API requests
    [Route("[controller]")]     // This attribute specifies the base route for this Controller based on the controller's name
    public class EditTruckController : Controller
    {
        // Declaration of Dependency, field to hold database context
        private readonly ApplicationDbContext _context;

        // Constructor with Dependency Injection, injecting ApplicationDbContext into the Controller
        public EditTruckController(ApplicationDbContext context)
        {
            // Dependency assigned to _context
            _context = context;
        }

        // HTTP PATCH request for /EditTruck with a route parameter for Truck ID
        [HttpPatch("{id}")]
        public async Task<IActionResult> EditTruck(Guid id, [FromBody] Truck updatedTruck)
        {
            if (id == Guid.Empty)
            {
                // Return BadRequest if Truck ID is empty or missing
                return BadRequest("Truck ID is required."); 
            }

            // Find the Truck in the database through its ID
            var existingTruck = await _context.Trucks.FindAsync(id);
            if (existingTruck == null)
            {
                // Return Truck not found if ID does not match any truck in the database
                return NotFound(); 
            }

            // Update the Truck's information with newly provided updated truck information
            // Updates truck information only if new truck information is provided, information remains unchanged otherwise
            existingTruck.Registration = updatedTruck.Registration ?? existingTruck.Registration;
            existingTruck.GrossWeight = updatedTruck.GrossWeight != 0 ? updatedTruck.GrossWeight : existingTruck.GrossWeight;
            existingTruck.TareWeight = updatedTruck.TareWeight != 0 ? updatedTruck.TareWeight : existingTruck.TareWeight;
            existingTruck.NettWeight = updatedTruck.NettWeight != 0 ? updatedTruck.NettWeight : existingTruck.NettWeight;
            existingTruck.Haulier = updatedTruck.Haulier ?? existingTruck.Haulier;

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Truck updated successfully
            return Ok();
        }
    }
    /*
    public IActionResult Index()
    {
        return View();
    }
    */
}

