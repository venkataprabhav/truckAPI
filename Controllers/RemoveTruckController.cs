using Interview_Task_TruckAPI.Data;
using Interview_Task_TruckAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interview_Task_TruckAPI.Controllers
{
    [ApiController]             // This attribute indicates that this Controller handles HTTP API requests
    [Route("[controller]")]     // This attribute specifies the base route for this Controller based on the controller's name
    public class RemoveTruckController : Controller
    {
        // Declaration of Dependency, field to hold database context
        private readonly ApplicationDbContext _context;

        // Constructor with Dependency Injection, injecting ApplicationDbContext into the Controller
        public RemoveTruckController(ApplicationDbContext context)
        {
            // Dependency assigned to _context
            _context = context;
        }
        
        public async Task<ActionResult<IEnumerable<Truck>>> GetTrucks()
        {
            // Retrieves information of all trucks from the Trucks database
            return await _context.Trucks.ToListAsync();
        }

        // HTTP DELETE request for /RemoveTruck with a route parameter for Truck ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTruck(Guid id)
        {
            if (id == Guid.Empty)
            {
                // Return BadRequest if Truck ID is empty or missing
                return BadRequest("Truck ID is required."); 
            }

            // Find the Truck in the database through its ID
            var truckToRemove = await _context.Trucks.FindAsync(id);
            if (truckToRemove == null)
            {
                // Return Truck not found if ID does not match any truck in the database
                return NotFound(); 
            }

            // Utilization of Injected Dependency, Remove truck from the Trucks table in the database
            _context.Trucks.Remove(truckToRemove);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Truck removed successfully
            return Ok(); 
        }

        /*
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}
