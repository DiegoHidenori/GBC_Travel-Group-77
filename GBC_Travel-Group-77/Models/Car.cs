using System.ComponentModel.DataAnnotations;

namespace GBC_Travel_Group_77.Models
{
    public class Car
    {
        public string category { get; set; }
        public int id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string type { get; set; }
        public int yearManufactured { get; set; }
        public string color { get; set; }
        public string licensePlate { get; set; }
        public int seatCapacity { get; set; }
        public bool isAvailable { get; set; }
        public double price { get; set; }
        public bool isHotDeal { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public string imageUrl { get; set; }
    }
}
