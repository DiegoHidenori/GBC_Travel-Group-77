namespace GBC_Travel_Group_77.Models
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> AllHotels { get; }
        IEnumerable<Hotel> HotelsHotDeals { get; }
        Hotel? GetHotelById(int hotelId);
    }
}
