using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportPanelApplication.Models.Enteties;
using AirportPanelApplication.Models.Interfaces;

namespace AirportPanelApplication.Models.Repositories
{
    public class FlightRepository : IFlight
    {
        private AirportContext _db;

        public FlightRepository()
        {
            _db = new AirportContext();
        }

        public Flight GetFlightById(int id)
        {
            return _db.Flights.First(f => f.Id == id);
        }

        public List<Flight> GetFlights()
        {
            return _db.Flights.ToList<Flight>();
        }

        public void Add(Flight flight)
        {
            _db.Flights.Add(flight);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var flight = GetFlightById(id);
            _db.Flights.Remove(flight);
            _db.SaveChanges();
        }

        public void Update(Flight flight)
        {
            var _flight = _db.Flights.Find(flight.Id);
            if (_flight != null)
            {
                _db.Entry(_flight).CurrentValues.SetValues(flight);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Current entity can not be updated");
            }
        }

        public List<Airplane> GetAirplanes()
        {
            return _db.Airplanes.ToList<Airplane>();
        }

        public List<Passenger> GetPassengers()
        {
            return _db.Passengers.ToList<Passenger>();
        }
    }
}