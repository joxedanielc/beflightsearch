using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using beflightsearch.Models;
using beflightsearch.Data;
using beflightsearch.Exceptions;

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
            {
                throw new NotFoundException($"Flight with ID {id} not found.");
            }

            return Ok(flight);
        }

        [HttpPost]
        public IActionResult CreateFlight([FromBody] Flight flight)
        {
            if (flight == null)
            {
                return BadRequest("Invalid request body. Flight data is missing.");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                var errorResponse = new ErrorResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Invalid data",
                };
                return BadRequest(errorResponse);
            }

            flight.Id = 0;

            var createdFlight = _flightService.CreateFlight(flight);
            return CreatedAtAction(nameof(GetFlightById), new { id = createdFlight.Id }, createdFlight);
        }    
    }
}
