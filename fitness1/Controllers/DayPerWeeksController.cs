using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fitness.Models;

namespace fitness.Controllers
{
    public class DayPerWeeksController : Controller
    {
        private fitnessandlifestyle db = new fitnessandlifestyle();

        // GET: DayPerWeeks
        public ActionResult Index()
        {
            return View(db.DayPerWeeks.ToList());
        }

        // GET: DayPerWeeks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayPerWeek dayPerWeek = db.DayPerWeeks.Find(id);
            if (dayPerWeek == null)
            {
                return HttpNotFound();
            }
            return View(dayPerWeek);
        }

        // GET: DayPerWeeks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DayPerWeeks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Day")] DayPerWeek dayPerWeek)
        {
            if (ModelState.IsValid)
            {
                db.DayPerWeeks.Add(dayPerWeek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dayPerWeek);
        }

        // GET: DayPerWeeks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayPerWeek dayPerWeek = db.DayPerWeeks.Find(id);
            if (dayPerWeek == null)
            {
                return HttpNotFound();
            }
            return View(dayPerWeek);
        }

        // POST: DayPerWeeks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Day")] DayPerWeek dayPerWeek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dayPerWeek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dayPerWeek);
        }

        // GET: DayPerWeeks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayPerWeek dayPerWeek = db.DayPerWeeks.Find(id);
            if (dayPerWeek == null)
            {
                return HttpNotFound();
            }
            return View(dayPerWeek);
        }

        // POST: DayPerWeeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DayPerWeek dayPerWeek = db.DayPerWeeks.Find(id);
            db.DayPerWeeks.Remove(dayPerWeek);
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
