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
                return _appDbContext.Flights;
            }
        }

        public IEnumerable<Flight> FlightsHotDeals
        {
            get
            {
                return _appDbContext.Flights.Where(p => p.isHotDeal);
            }
        }

        public Flight? GetFlightById(int id)
        {
            return _appDbContext.Flights.FirstOrDefault(p => p.id == id);
        }
    }
}
