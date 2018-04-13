using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDAC_TP034928.Models;
using DDAC_TP034928.ViewModels;

namespace DDAC_TP034928.Controllers
{
    public class ScheduleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Schedules
        public ActionResult Index()
        {
            var schedule = db.Schedule.Include(s => s.vesselName);
            return View(schedule.ToList());
        }

        // GET: Schedules/Create
        public ActionResult Create()
        {
            var vessel = db.Vessel.ToList();

            ScheduleViewModel viewModel = new ScheduleViewModel
            {
                vesselList = vessel
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult saveSchedule(Schedule schedule)
        {

            if (ModelState.IsValid)
            {
                db.Schedule.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schedule);
        }


        public ActionResult Edit(int id)
        {
            var schedule = db.Schedule.SingleOrDefault(c => c.Id == id);

            if (schedule == null)
            {

                return HttpNotFound();

            }

            var viewModel = new ScheduleViewModel
            {
                schedule = schedule,

                vesselList = db.Vessel.ToList()


            };

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult editSchedule(Schedule schedule)
        {

            var ScheduleInDb = db.Schedule.Single(c => c.Id == schedule.Id);

            if (ScheduleInDb == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                ScheduleInDb.vesselId = schedule.vesselId;
                ScheduleInDb.origin = schedule.origin;
                ScheduleInDb.destination = schedule.destination;
                ScheduleInDb.departureTime = schedule.departureTime;
                ScheduleInDb.arrivalTime = schedule.arrivalTime;

                db.SaveChanges();

                return RedirectToAction("Index", "Schedule");
            }
            else
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
