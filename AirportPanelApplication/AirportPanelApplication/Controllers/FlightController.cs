using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportPanelApplication.Models;
using AirportPanelApplication.Models.Enteties;
using AirportPanelApplication.Models.Repositories;

namespace AirportPanelApplication.Controllers
{
    public class FlightController : Controller
    {
        private FlightRepository Repository = new FlightRepository();
        AirportContext db = new AirportContext();
        // GET: Flight
        public ActionResult Index(string searchString)
        {
            List<Flight> _flights;
            _flights = Repository.GetFlights();
            if (!string.IsNullOrEmpty(searchString))
            {
                _flights = _flights.Where(f => f.FlightNumber.ToLower().Contains(searchString.ToLower()) || f.Destination.ToLower().Contains(searchString.ToLower())
                || f.Origin.ToLower().Contains(searchString.ToLower())).ToList<Flight>();
            }

            return View(_flights);
            
            
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Flight flight)
        {
            if (ModelState.IsValid)
            {
                Repository.Add(flight);
                return RedirectToAction("Index", "Flight");
            }
            ViewBag.AirplaneId = new SelectList(db.Airplanes, "Id", "Name", flight.AirplaneId);
            return View(flight);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Repository.Delete(id);
            return RedirectToAction("Index", "Flight");
        }

        public ActionResult Details(int id)
        {
            
            var flight = Repository.GetFlightById(id);
            return View(flight);

        }
        public ActionResult Update(int id = 0)
        {
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.Passengers = db.Passengers.ToList();
            return View(flight);
        }

        [HttpPost]
        public ActionResult Update(Flight flight, int[] selectedCourses)
        {
            Flight newFlight = db.Flights.Find(flight.Id);
            newFlight.Passengers.Clear();
            if (selectedCourses != null)
            {                
                foreach (var c in db.Passengers.Where(co => selectedCourses.Contains(co.Id)))
                {
                    newFlight.Passengers.Add(c);
                }
            }

            db.Entry(newFlight).State = EntityState.Modified;
            db.Entry(newFlight).CurrentValues.SetValues(flight);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
