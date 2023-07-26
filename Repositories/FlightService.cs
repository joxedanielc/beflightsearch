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

        public IEnumerable<Flight> GetFlights(string departureCity, string arrivalCity, DateTime? departureDate, DateTime? arrivalDate)
        {
            var flights = _context.Flights.AsQueryable();

            if (!string.IsNullOrEmpty(departureCity))
            {
                flights = flights.Where(f => f.DepartureCity.ToUpper().Contains(departureCity.ToUpper()));
            }

            if (!string.IsNullOrEmpty(arrivalCity))
            {
                flights = flights.Where(f => f.ArrivalCity.ToUpper().Contains(arrivalCity.ToUpper()));
            }

            if (departureDate.HasValue)
            {
                DateTime departureStartDate = departureDate.Value.Date;
                flights = flights.Where(f => f.DepartureDateTime >= departureStartDate);
            }

            if (arrivalDate.HasValue)
            {
                DateTime arrivalStartDate = arrivalDate.Value.Date;
                DateTime arrivalEndDate = arrivalStartDate.AddDays(1).AddTicks(-1);
                flights = flights.Where(f => f.ArrivalDateTime < arrivalEndDate);
            }
        
            return flights.ToList();
        }

        public Flight GetFlightById(int id)
        {
            return _context.Flights.Find(id);
        }

        public Flight CreateFlight(Flight flight)
        {
            if (flight == null)
                throw new ArgumentNullException(nameof(flight));

            _context.Flights.Add(flight);
            _context.SaveChanges();

            return flight;
        }
    }
}
