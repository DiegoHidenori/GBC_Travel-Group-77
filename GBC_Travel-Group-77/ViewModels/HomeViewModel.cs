using GBC_Travel_Group_77.Models;

namespace GBC_Travel_Group_77.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Flight> flightsHotDeals { get; }
        public IEnumerable<Hotel> hotelsHotDeals { get; }
        public IEnumerable<Car> carsHotDeals { get; }

        public HomeViewModel(IEnumerable<Flight> flightsHotDeals, IEnumerable<Hotel> hotelsHotDeals, IEnumerable<Car> carsHotDeals)
        {
            this.flightsHotDeals = flightsHotDeals;
            this.hotelsHotDeals = hotelsHotDeals;
            this.carsHotDeals = carsHotDeals;
        }
    }
}
