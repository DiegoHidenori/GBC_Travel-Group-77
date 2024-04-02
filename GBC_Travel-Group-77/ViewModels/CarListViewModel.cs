using GBC_Travel_Group_77.Models;

namespace GBC_Travel_Group_77.ViewModels
{
    public class CarListViewModel
    {
        public IEnumerable<Car> Cars { get; }
        public string? currentCategory { get; }

        public CarListViewModel(IEnumerable<Car> cars, string? category)
        {
            Cars = cars;
            currentCategory = category;
        }
    }
}
