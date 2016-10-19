using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportPanelApplication.Models;
using AirportPanelApplication.Models.Enteties;

namespace AirportPanelApplication.Controllers
{
    public class AirlineController : Controller
    {
        AirportContext db = new AirportContext();

        // GET: Airline
        public ActionResult Index()
        {
            List<Airline> airlines = db.Airlines.ToList<Airline>();
            return View(airlines);
        }
     
    }
}