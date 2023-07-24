using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using beflightsearch.Models;
using beflightsearch.Data;

namespace beflightsearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public IActionResult GetFlights(string? departureCity, string? arrivalCity, DateTime? departureDate, DateTime? arrivalDate)
        {
            var flights = _flightService.GetFlights(departureCity, arrivalCity, departureDate, arrivalDate);
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public IActionResult GetFlightById(int id)
        {
            var flight = _flightService.GetFlightById(id);
            if (flight == null)
                return NotFound();

            return Ok(flight);
        }

        [HttpPost]
        public IActionResult CreateFlight([FromBody] Flight flight)
        {
            if (flight == null)
                return BadRequest();

            _flightService.CreateFlight(flight);

            return CreatedAtAction(nameof(GetFlightById), new { id = flight.Id }, flight);
        }
    }
}
