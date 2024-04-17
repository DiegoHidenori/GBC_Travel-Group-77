using GBC_Travel_Group_77.Data;

namespace GBC_Travel_Group_77.Models
{
    public class HotelRepository : IHotelRepository
    {
        public readonly AppDbContext _appDbContext;

        public HotelRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Hotel> AllHotels
        {
            get
            {
                try
                {
                    return _appDbContext.Hotels;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving all the hotels: ", ex);
                }
            }
        }

        public IEnumerable<Hotel> HotelsHotDeals
        {
            get
            {
                try
                {
                    return _appDbContext.Hotels.Where(p => p.isHotDeal);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving the hot deals: ", ex);
                }
            }
        }

        public void AddHotel(Hotel hotel)
        {
            try
            {
                _appDbContext.Hotels.Add(hotel);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding a hotel: ", ex);
            }
        }

        public void UpdateHotel(Hotel hotel)
        {
            try
            {
                _appDbContext.Hotels.Update(hotel);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating a hotel: ", ex);
            }
        }

        public void DeleteHotel(Hotel hotel)
        {
            try
            {
                _appDbContext.Hotels.Remove(hotel);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting hotel: ", ex);
            }
            
        }

        public Hotel? GetHotelById(int id)
        {
            try
            {
                return _appDbContext.Hotels.FirstOrDefault(p => p.id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting a hotel with the id: ", ex);
            }
            
        }
    }
}
