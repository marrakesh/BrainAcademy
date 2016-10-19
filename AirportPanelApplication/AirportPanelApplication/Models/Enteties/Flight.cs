using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportPanelApplication.Models.Enteties
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100), Required]
        public string FlightNumber { get; set; }

        [MaxLength(100), Required]
        public string Origin { get; set; }

        [MaxLength(100), Required]
        public string Destination { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public FlightStatus FlightStatus { get; set; }
        public Direction Direction { get; set; }
        public Terminal Terminal { get; set; }

        public int? AirplaneId { get; set; }
        public virtual Airplane Airplane { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
        public virtual IEnumerable<SelectListItem> Airplanes { get; set; } 

        public Flight()
        {
            Passengers = new List<Passenger>();
        }
    }


   
    
    public enum FlightStatus : byte
    {
        Departed = 1,
        Arrived,
        Expected,
        Boarding,
        Delay,
        Planned
    }

    public enum Terminal : byte
    {
        A = 1, B, C, D
    }

    public enum Direction
    {
        Arrivals = 1,
        Departures
    }


}