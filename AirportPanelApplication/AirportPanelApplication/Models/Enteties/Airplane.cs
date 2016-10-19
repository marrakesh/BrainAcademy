using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirportPanelApplication.Models.Enteties
{
    public class Airplane
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100), Required]
        public string Manufacturer { get; set; }

        [MaxLength(100), Required]
        public string Model { get; set; }

        public virtual ICollection<Flight> Flight { get; set; }

        public int? AirlineId { get; set; }

        public virtual Airline Airline { get; set; }
    }
}