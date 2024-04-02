namespace GBC_Travel_Group_77.Models
{
    public class Hotel
    {
        public string category { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public int starRating { get; set; }
        public string description { get; set; }
        public int totalRooms { get; set; }
        public int availableRooms { get; set; }
        public string roomTypes { get; set; }
        public string contactInfo { get; set; }
        public double price { get; set; }
        public bool isHotDeal { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public string imageUrl { get; set; }
    }
}
