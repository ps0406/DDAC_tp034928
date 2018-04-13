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
    public class VesselController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vessels
        public ActionResult Index()
        {
            return View(db.Vessel.ToList());
        }

        

        // GET: Vessels/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Vessels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,vesselName,capacity")] Vessel vessel)
        {
            if (ModelState.IsValid)
            {
                db.Vessel.Add(vessel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vessel);
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
