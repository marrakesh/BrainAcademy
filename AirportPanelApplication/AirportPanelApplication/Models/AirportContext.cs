using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AirportPanelApplication.Models.Enteties;

namespace AirportPanelApplication.Models
{
    public class AirportContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Airline> Airlines { get; set; }
    }
}