using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DDAC_TP034928.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 1000)]
        [Display(Name = "Cargo Weight")]
        public int cargoWeight { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "Container Amount")]
        public int amount { get; set; }

        public Customer customerData { get; set; }

        public int customerId { get; set; }

        public Schedule scheduleData { get; set; }

        public int scheduleId { get; set; }
       
    }
}