using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Transnet.Models;

namespace Transnet.Controllers
{
    public class CrainsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Crains
        public ActionResult Index()
        {
            return View(db.crains.ToList());
        }

        // GET: Crains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crains crains = db.crains.Find(id);
            if (crains == null)
            {
                return HttpNotFound();
            }
            return View(crains);
        }

        // GET: Crains/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Crains crains)
        {
            if (ModelState.IsValid)
            {
                crains.totTimepC = crains.TotCr();
                crains.totTime = crains.TotTime();
                crains.noHoursPD = crains.HoursPH();
                crains.noHoursEx = crains.HoursExPH();
                crains.noHoursonWk = crains.HoursWnd();
                db.crains.Add(crains);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crains);
        }

        // GET: Crains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crains crains = db.crains.Find(id);
            if (crains == null)
            {
                return HttpNotFound();
            }
            return View(crains);
        }

        // POST: Crains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CrainId,strtDate,endDate,Days,noShiftonHd,noShiftphrHD,noDaysPD,noHoursPD,noShiftonEx,noShifpHrEx,noDaysEx,noHoursEx,noShiftonWk,noShiftpHrWk,noDaysonWk,noHoursonWk,NoCrains,totTimepC,totTime")] Crains crains)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crains).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crains);
        }

        // GET: Crains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crains crains = db.crains.Find(id);
            if (crains == null)
            {
                return HttpNotFound();
            }
            return View(crains);
        }

        // POST: Crains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crains crains = db.crains.Find(id);
            db.crains.Remove(crains);
            db.SaveChanges();
            return RedirectToAction("Index");
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
