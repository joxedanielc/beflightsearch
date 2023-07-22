using System;
using System.Collections.Generic;
using System.Linq;
using beflightsearch.Data;

namespace beflightsearch.Models
{
    public class FlightService : IFlightService
    {
        private readonly AppDbContext _context;

        public FlightService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Flight> GetFlights()
        {
            return _context.Flights.ToList();
        }

        public Flight GetFlightById(int id)
        {
            return _context.Flights.Find(id);
        }

        public void CreateFlight(Flight flight)
        {
            if (flight == null)
                throw new ArgumentNullException(nameof(flight));

            _context.Flights.Add(flight);
            _context.SaveChanges();
        }
    }
}
