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
    public class PassengerController : Controller
    {
        private PassengerRepository Repository = new PassengerRepository();
        AirportContext db = new AirportContext(); 
        // GET: Passenger
        public ActionResult Index(string searchString)
        {
            List<Passenger> _passenger;
            _passenger = Repository.GetPassengers();
            if (!string.IsNullOrEmpty(searchString))
            {
                _passenger = _passenger.Where(p => p.FirstName.ToLower().Contains(searchString.ToLower()) || p.LastName.ToLower().Contains(searchString.ToLower())
                || p.PassportId.ToLower().Contains(searchString.ToLower()) || p.PassportSeries.ToLower().Contains(searchString.ToLower()) || (p.PassportSeries.ToString() + p.PassportId.ToString()).Equals(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList<Passenger>();
            }
            return View(_passenger);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                Repository.Add(passenger);
                return RedirectToAction("Index", "Passenger");
            }
            //ViewBag.AirplaneId = new SelectList(Repository.GetAirplanes().Where(a => a.Id == flight.AirplaneId));
            //ViewBag.Id = new SelectList(db.TimeTables, "Id", "Id", flight.Id);
            return View(passenger);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Repository.Delete(id);
            return RedirectToAction("Index", "Passenger");
        }

        public ActionResult Details(int id)
        {

            var passenger = Repository.GetPassengerById(id);
            return View(passenger);

        }

        public ActionResult Update(int id = 0)
        {
            Passenger passenger = db.Passengers.Find(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            ViewBag.Flights = db.Flights.ToList();
            return View(passenger);
        }

        [HttpPost]
        public ActionResult Update(Passenger passenger, int[] selectedCourses)
        {
            Passenger newPassenger = db.Passengers.Find(passenger.Id);
            newPassenger.Flights.Clear();

            if (selectedCourses != null)
            {
                foreach (var c in db.Flights.Where(co => selectedCourses.Contains(co.Id)))
                {
                    newPassenger.Flights.Add(c);
                }
            }

            db.Entry(newPassenger).State = EntityState.Modified;
            db.Entry(newPassenger).CurrentValues.SetValues(passenger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
