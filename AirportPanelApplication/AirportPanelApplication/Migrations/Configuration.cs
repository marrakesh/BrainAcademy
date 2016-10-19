using AirportPanelApplication.Models.Enteties;

namespace AirportPanelApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AirportPanelApplication.Models.AirportContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AirportPanelApplication.Models.AirportContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var airline1 = new Airline { CompanyName = "Airbus", Address = "asd", PhoneNumber = "+1236548795" };
            var airplane1 = new Airplane { Manufacturer = "Airbus", Model = "123" };
            var flight1 = new Flight { Airplane = airplane1, Id = 2, DepartureTime = DateTime.Now.AddHours(2), ArrivalTime = DateTime.Now.AddHours(4), FlightStatus = FlightStatus.Boarding, FlightNumber = "PK765123", Destination = "Lviv", Origin = "Kiev", Direction = Direction.Departures, Terminal = Terminal.A };
            var passenger1 = new Passenger
            {
                FirstName = "Alex",
                LastName = "Ozerov",
                Sex = Sex.Male,
                Birthdate = DateTime.Now.AddHours(1),
                Nationality = "Ukrainian",
                PassportSeries = "ME",
                PassportId = "123456",
                Id = 1
            };

            context.Flights.Add(flight1);
            context.Airlines.Add(airline1);
            context.Airplanes.Add(airplane1);
            context.Passengers.Add(passenger1);
            context.SaveChanges();
        }
    }
}
