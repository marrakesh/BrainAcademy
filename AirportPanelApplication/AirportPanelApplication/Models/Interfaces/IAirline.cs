using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportPanelApplication.Models.Enteties;

namespace AirportPanelApplication.Models.Interfaces
{
    interface IAirline
    {
        List<Airline> GetAirlines();
        Airline GeAirlineById(int id);
        void Add(Airline airline);
        void Update(Airline airline);
        void Delete(int id);
    }
}
