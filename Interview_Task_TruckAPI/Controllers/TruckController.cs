using Interview_Task_TruckAPI.Data;
using Interview_Task_TruckAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interview_Task_TruckAPI.Controllers
{
    [ApiController]             // This attribute indicates that this Controller handles HTTP API requests
    [Route("[controller]")]     // This attribute specifies the base route for this Controller based on the controller's name
    public class TruckController : Controller
    {
        // Declaration of Dependency, field to hold database context
        private readonly ApplicationDbContext _context;     

        // Constructor with Dependency Injection, injecting ApplicationDbContext into the Controller
        public TruckController(ApplicationDbContext context)
        {
            // Dependency assigned to _context
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Truck>>> GetTrucks()
        {
            // Retrieves information of all trucks from the Trucks database
            return await _context.Trucks.ToListAsync();
        }

        // HTTP POST request for /Truck
        [HttpPost]
        public async Task<ActionResult<Truck>> PostTruck([FromBody] Truck truck)
        {
            if (truck == null)
                return BadRequest("Truck data is required");    // Returns BadRequest if no data for Truck is entered

            // Utilization of Injected Dependency, Adds new Truck to the Truck table in the database
            _context.Trucks.Add(truck);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the created truck and its information data
            return CreatedAtAction(nameof(GetTrucks), new { id = truck.Id }, truck);
        }
        /*
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}
