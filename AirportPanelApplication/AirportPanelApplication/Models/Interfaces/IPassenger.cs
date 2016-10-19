using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportPanelApplication.Models.Enteties;

namespace AirportPanelApplication.Models.Interfaces
{
    interface IPassenger
    {
        List<Passenger> GetPassengers();
        Passenger GetPassengerById(int id);
        void Add(Passenger passenger);
        void Update(Passenger passenger, int[] selectedFlight);
        void Delete(int id);
    }
}
