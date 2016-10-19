using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AirportPanelApplication.Models.Enteties;
using AirportPanelApplication.Models.Interfaces;

namespace AirportPanelApplication.Models.Repositories
{
    public class PassengerRepository : IPassenger
    {
        private AirportContext _db;

        public PassengerRepository()
        {
            _db = new AirportContext();
        }

        public void Add(Passenger passenger)
        {
            _db.Passengers.Add(passenger);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var passenger = GetPassengerById(id);
            _db.Passengers.Remove(passenger);
            _db.SaveChanges();
        }

        public List<Passenger> GetPassengers()
        {
            return _db.Passengers.ToList<Passenger>();
        }

        public Passenger GetPassengerById(int id)
        {
            return _db.Passengers.First(f => f.Id == id);
        }

        public void Update(Passenger passenger, int[] selectedFlight)
        {
            var _passenger = _db.Passengers.Find(passenger.Id);
            if (_passenger != null)
            {
                if (selectedFlight != null)
                {
                    //получаем выбранные курсы
                    foreach (var c in _db.Flights.Where(co => selectedFlight.Contains(co.Id)))
                    {
                        _passenger.Flights.Add(c);
                    }
                }
                _db.Entry(_passenger).CurrentValues.SetValues(passenger);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Current entity can not be updated");
            }
            
        }

        public List<Flight> GetFlights()
        {
            return _db.Flights.ToList<Flight>();
        }
    }


}
