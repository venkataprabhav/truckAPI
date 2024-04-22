using Interview_Task_TruckAPI.Data;
using Interview_Task_TruckAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interview_Task_TruckAPI.Controllers
{
    [ApiController]             // This attribute indicates that this Controller handles HTTP API requests
    [Route("[controller]")]     // This attribute specifies the base route for this Controller based on the controller's name
    public class TrucksController : Controller
    {
        // Declaration of Dependency, field to hold database context
        private readonly ApplicationDbContext _context;

        // Constructor with Dependency Injection, injecting ApplicationDbContext into the Controller
        public TrucksController(ApplicationDbContext context)
        {
            // Dependency assigned to _context
            _context = context;
        }

        // HTTP GET request for /Trucks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Truck>>> GetTrucks()
        {
            // Retrieves information of all trucks from the Trucks database
            return await _context.Trucks.ToListAsync();
        }
        /*
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}
