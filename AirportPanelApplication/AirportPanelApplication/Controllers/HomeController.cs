using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportPanelApplication.Models;
using AirportPanelApplication.Models.Enteties;
using AirportPanelApplication.Models.Repositories;

namespace AirportPanelApplication.Controllers
{
    public class HomeController : Controller
    {
        private FlightRepository Repository = new FlightRepository();
        AirportContext db = new AirportContext();
        // GET: Flight
        public ActionResult Index(string searchString)
        {
            List<Flight> _flights;
            _flights = Repository.GetFlights();
 
            return View(_flights);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}