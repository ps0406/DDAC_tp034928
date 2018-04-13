using DDAC_TP034928.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDAC_TP034928.ViewModels
{
    public class ScheduleViewModel
    {
        public Schedule schedule { get; set; }

        public IEnumerable<Vessel> vesselList { get; set; }

    }
}