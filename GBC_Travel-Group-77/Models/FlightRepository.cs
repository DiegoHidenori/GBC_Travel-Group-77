using GBC_Travel_Group_77.Data;
using Microsoft.EntityFrameworkCore;

namespace GBC_Travel_Group_77.Models
{
    public class FlightRepository : IFlightRepository
    {
        public readonly AppDbContext _appDbContext;

        public FlightRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Flight> AllFlights
        {
            get
            {
                try
                {
                    return _appDbContext.Flights;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving all the flights: ", ex);
                }
                
            }
        }

        public IEnumerable<Flight> FlightsHotDeals
        {
            get
            {
                try
                {
                    return _appDbContext.Flights.Where(p => p.isHotDeal);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving the hot deals: ", ex);
                }
            }
        }

        public void AddFlight(Flight flight)
        {
            try
            {
                _appDbContext.Flights.Add(flight);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding a flight: ", ex);
            }
            
        }

        public void UpdateFlight(Flight flight)
        {
            try
            {
                _appDbContext.Flights.Update(flight);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating a flight: ", ex);
            }
            
        }

        public void DeleteFlight(Flight flight)
        {
            try
            {
                _appDbContext.Flights.Remove(flight);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting a flight: ", ex);
            }
            
        }

        public Flight? GetFlightById(int id)
        {
            try
            {
                return _appDbContext.Flights.FirstOrDefault(p => p.id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting a flight with the id: ", ex);
            }
            
        }
    }
}
