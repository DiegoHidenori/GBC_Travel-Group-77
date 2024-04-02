namespace GBC_Travel_Group_77.Models
{
    public interface IFlightRepository
    {
        IEnumerable<Flight> AllFlights { get; }
        IEnumerable<Flight> FlightsHotDeals { get; }
        Flight? GetFlightById(int flightId);
    }
}
