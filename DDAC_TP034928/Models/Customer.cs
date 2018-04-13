using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;

namespace DDAC_TP034928.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Customer Name is invalid")]
        [Display(Name = "Customer Name")]
        public string customerName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string customerEmail { get; set; }

        [Required]
        [RegularExpression("[0-9]{1,}", ErrorMessage = "Invalid Contact Number")]
        [MinLength(10, ErrorMessage = "Invalid Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(11, ErrorMessage = "Invalid Contact Number")]
        [Display(Name = "Contact Number")]
        public string contactNo { get; set; }

        
    }
}