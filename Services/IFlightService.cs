using System.Collections.Generic;

namespace beflightsearch.Models
{
    public interface IFlightService
    {
        IEnumerable<Flight> GetFlights();
        Flight GetFlightById(int id);
        void CreateFlight(Flight flight);
    }
}