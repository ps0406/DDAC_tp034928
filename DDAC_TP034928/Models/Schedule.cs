using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DDAC_TP034928.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        
        [StringLength(100)]
        [Display(Name = "Vessel")]
        public Vessel vesselName { get; set; }

        [Required]
        public int vesselId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Origin")]
        public string origin { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Destination")]
        public string destination { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Departure Date")]
        public DateTime departureTime { get; set; }

        [Required]
        [Display(Name = "Arrival Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime arrivalTime { get; set; }
    }
}