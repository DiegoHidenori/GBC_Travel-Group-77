using GBC_Travel_Group_77.Models;

namespace GBC_Travel_Group_77.ViewModels
{
    public class FlightListViewModel
    {
        public IEnumerable<Flight> Flights { get; }
        public string? currentCategory { get; }

        public FlightListViewModel(IEnumerable<Flight> flights, string? category)
        {
            Flights = flights;
            currentCategory = category;
        }
    }
}
