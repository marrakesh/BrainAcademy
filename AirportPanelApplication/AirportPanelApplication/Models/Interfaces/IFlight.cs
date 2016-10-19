using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportPanelApplication.Models.Enteties;

namespace AirportPanelApplication.Models.Interfaces
{
    public interface IFlight
    {
        List<Flight> GetFlights();
        Flight GetFlightById(int id);
        void Add(Flight flight);
        void Update(Flight flight);
        void Delete(int id);
    }
}
