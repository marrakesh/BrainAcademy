using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportPanelApplication.Models.Enteties;

namespace AirportPanelApplication.Models.Interfaces
{
    interface IAirplane
    {
        List<Airplane> GetAirplanes();
        Airplane GeAirplaneById(int id);
        void Add(Airplane airplane);
        void Update(Airplane airplane);
        void Delete(int id);
    }
}
