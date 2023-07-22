using System;
namespace beflightsearch.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightName { get; set; }
        public int AirlineId { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public decimal Price { get; set; }
        public int Scales { get; set; }
    }

}

