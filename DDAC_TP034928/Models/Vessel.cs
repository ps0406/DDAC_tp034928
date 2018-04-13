using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDAC_TP034928.Models
{
    public class Vessel
    {
        
        [Display(Name = "Vessel ID")]
        public int Id { get; set; }

        [Display(Name = "Vessel Name")]
        [Required]
        [StringLength(50, ErrorMessage = "Vessel Name Cannot exceed 50 characters")]
        public string vesselName { get; set; }

        [Display(Name = "Capacity")]
        [Range(10, 1000)]
        [Required]
        public int capacity { get; set; }
        
    }
}