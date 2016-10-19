using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirportPanelApplication.Models.Enteties
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100), Required]
        public string FirstName { get; set; }

        [MaxLength(100), Required]
        public string LastName { get; set; }

        [MaxLength(100), Required]
        public string Nationality { get; set; }

        [MaxLength(5), Required]
        public string PassportSeries { get; set; }

        [MaxLength(20), Required]
        public string PassportId { get; set; }

        public DateTime Birthdate { get; set; }
        public Sex Sex { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

        public Passenger()
        {
            Flights = new List<Flight>();
        }
    }

    public enum Sex : byte
    {
        Male = 1,
        Female
    }
}