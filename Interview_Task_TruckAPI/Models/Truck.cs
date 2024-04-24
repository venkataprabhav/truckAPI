using System.ComponentModel.DataAnnotations;

namespace Interview_Task_TruckAPI.Models
{
    // Represents the structure of a Truck 
    public class Truck
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public string? Registration { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal TareWeight { get; set; }
        public decimal NettWeight { get; set; }
        public string? Haulier { get; set; }
    }
}
