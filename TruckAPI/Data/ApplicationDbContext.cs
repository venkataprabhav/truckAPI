using Microsoft.EntityFrameworkCore;
using Interview_Task_TruckAPI.Models;

namespace Interview_Task_TruckAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        // ApplicationDbContext represents the database context for interacting with the database
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext() : base()
        {
        }

        // Represents Trucks in the database
        public virtual DbSet<Truck> Trucks { get; set; }
        
        //public DbSet<Truck> RemovedTrucks { get; set; }
    }
}
 