using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportPanelApplication.Models.Enteties;
using AirportPanelApplication.Models.Repositories;

namespace AirportPanelApplication.Controllers
{
    public class ArrivalDepartureController : Controller
    {
        private FlightRepository Repository = new FlightRepository();
        // GET: ArrivalDeparture
        public ActionResult Index()
        {
            List<Flight> _flights;
            _flights = Repository.GetFlights();
            return View(_flights);
        }
    }
}