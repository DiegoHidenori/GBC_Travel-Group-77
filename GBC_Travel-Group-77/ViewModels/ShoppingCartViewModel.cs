using GBC_Travel_Group_77.Models;

namespace GBC_Travel_Group_77.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IShoppingCart shoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
        public List<Car> Cars { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Flight> Flights { get; set; }
    }
}
