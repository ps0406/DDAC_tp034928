using DDAC_TP034928.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DDAC_TP034928.ViewModels;

namespace DDAC_TP034928.Controllers
{
    public class BookingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Schedule
        public ActionResult Index()
        {
            var scheduleList = db.Schedule.Include(s => s.vesselName).ToList();
            return View(scheduleList);
        }

        public ActionResult viewBooking()
        {
            var booking = db.Booking.Include(b => b.customerData)
                                    .Include(b => b.scheduleData);
            return View(booking);
        }

        public ActionResult adminViewBooking()
        {
            var booking = db.Booking.Include(b => b.customerData)
                                    .Include(b => b.scheduleData);
            return View(booking);
        }

        // GET: Booking/Create
        public ActionResult Create(int id)
        {
            var selectSchedule = db.Schedule.Include(s => s.vesselName).SingleOrDefault(s => s.Id == id);
            var customer = db.Customer.ToList();

            var viewModel = new BookingViewModel
            {
                schedule = selectSchedule,
                customerList = customer
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult createBooking(BookingViewModel bookViewModel)
        {
            BookingViewModel book = new BookingViewModel
            {
                schedule = db.Schedule.SingleOrDefault(s => s.Id == bookViewModel.schedule.Id),
                customerList = db.Customer.ToList()
            };

            var booking1 = new Booking
            {
                customerId = bookViewModel.booking.customerId,
                cargoWeight = bookViewModel.booking.cargoWeight,
                amount = bookViewModel.booking.amount,
                scheduleId = bookViewModel.schedule.Id

            };

            if (ModelState.IsValid)
            {
                db.Booking.Add(booking1);
                db.SaveChanges();
                return RedirectToAction("viewBooking");
                
            }
            else
            {
                return View("Create", book);
            }

            
            
        }

    }
}