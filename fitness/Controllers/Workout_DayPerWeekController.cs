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
    public class Workout_DayPerWeekController : Controller
    {
        private fitnessandlifestyle db = new fitnessandlifestyle();

        // GET: Workout_DayPerWeek
        public ActionResult Index()
        {
            var workout_DayPerWeek = db.Workout_DayPerWeek.Include(w => w.DayPerWeek).Include(w => w.WorkOut);
            return View(workout_DayPerWeek.ToList());
        }

        // GET: Workout_DayPerWeek/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout_DayPerWeek workout_DayPerWeek = db.Workout_DayPerWeek.Find(id);
            if (workout_DayPerWeek == null)
            {
                return HttpNotFound();
            }
            return View(workout_DayPerWeek);
        }

        // GET: Workout_DayPerWeek/Create
        public ActionResult Create()
        {
            ViewBag.DayPerWeekId = new SelectList(db.DayPerWeeks, "Id", "Day");
            ViewBag.WorkOutId = new SelectList(db.WorkOuts, "Id", "Content");
            return View();
        }

        // POST: Workout_DayPerWeek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DayPerWeekId,WorkOutId")] Workout_DayPerWeek workout_DayPerWeek)
        {
            if (ModelState.IsValid)
            {
                db.Workout_DayPerWeek.Add(workout_DayPerWeek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DayPerWeekId = new SelectList(db.DayPerWeeks, "Id", "Day", workout_DayPerWeek.DayPerWeekId);
            ViewBag.WorkOutId = new SelectList(db.WorkOuts, "Id", "Content", workout_DayPerWeek.WorkOutId);
            return View(workout_DayPerWeek);
        }

        // GET: Workout_DayPerWeek/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout_DayPerWeek workout_DayPerWeek = db.Workout_DayPerWeek.Find(id);
            if (workout_DayPerWeek == null)
            {
                return HttpNotFound();
            }
            ViewBag.DayPerWeekId = new SelectList(db.DayPerWeeks, "Id", "Day", workout_DayPerWeek.DayPerWeekId);
            ViewBag.WorkOutId = new SelectList(db.WorkOuts, "Id", "Content", workout_DayPerWeek.WorkOutId);
            return View(workout_DayPerWeek);
        }

        // POST: Workout_DayPerWeek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DayPerWeekId,WorkOutId")] Workout_DayPerWeek workout_DayPerWeek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workout_DayPerWeek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DayPerWeekId = new SelectList(db.DayPerWeeks, "Id", "Day", workout_DayPerWeek.DayPerWeekId);
            ViewBag.WorkOutId = new SelectList(db.WorkOuts, "Id", "Content", workout_DayPerWeek.WorkOutId);
            return View(workout_DayPerWeek);
        }

        // GET: Workout_DayPerWeek/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout_DayPerWeek workout_DayPerWeek = db.Workout_DayPerWeek.Find(id);
            if (workout_DayPerWeek == null)
            {
                return HttpNotFound();
            }
            return View(workout_DayPerWeek);
        }

        // POST: Workout_DayPerWeek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workout_DayPerWeek workout_DayPerWeek = db.Workout_DayPerWeek.Find(id);
            db.Workout_DayPerWeek.Remove(workout_DayPerWeek);
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
