using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirportPanelApplication.Models.Enteties
{
    public class Airline
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100), Required]
        public string CompanyName { get; set; }

        [MaxLength(200), Required]
        public string Address { get; set; }

        [MaxLength(50), Required]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Airplane> Airplane { get; set; }
    }
}