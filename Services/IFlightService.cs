using System.Collections.Generic;

namespace beflightsearch.Models
{
    public interface IFlightService
    {
        IEnumerable<Flight> GetFlights(string? departureCity, string? arrivalCity, DateTime? departureDate, DateTime? arrivalDate);
        Flight GetFlightById(int id);
        void CreateFlight(Flight flight);
    }
}