using GBC_Travel_Group_77.Models;

namespace GBC_Travel_Group_77.ViewModels
{
    public class HotelListViewModel
    {
        public IEnumerable<Hotel> Hotels { get; }
        public string? currentCategory { get; }

        public HotelListViewModel(IEnumerable<Hotel> hotels, string? category)
        {
            Hotels = hotels;
            currentCategory = category;
        }
    }
}
