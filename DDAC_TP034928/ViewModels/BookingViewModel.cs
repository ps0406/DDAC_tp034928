using DDAC_TP034928.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDAC_TP034928.ViewModels
{
    public class BookingViewModel
    {
        public Booking booking { get; set; }

        public Schedule schedule { get; set; }

        public List<Customer> customerList { get; set; }

    }
}