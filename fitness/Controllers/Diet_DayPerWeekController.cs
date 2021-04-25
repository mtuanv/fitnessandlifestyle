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
    public class Diet_DayPerWeekController : Controller
    {
        private fitnessandlifestyle db = new fitnessandlifestyle();

        // GET: Diet_DayPerWeek
        public ActionResult Index()
        {
            var diet_DayPerWeek = db.Diet_DayPerWeek.Include(d => d.DayPerWeek).Include(d => d.DietPlan);
            return View(diet_DayPerWeek.ToList());
        }

        // GET: Diet_DayPerWeek/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet_DayPerWeek diet_DayPerWeek = db.Diet_DayPerWeek.Find(id);
            if (diet_DayPerWeek == null)
            {
                return HttpNotFound();
            }
            return View(diet_DayPerWeek);
        }

        // GET: Diet_DayPerWeek/Create
        public ActionResult Create()
        {
            ViewBag.DayPerWeekId = new SelectList(db.DayPerWeeks, "Id", "Day");
            ViewBag.DietID = new SelectList(db.DietPlans, "Id", "Title");
            return View();
        }

        // POST: Diet_DayPerWeek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DayPerWeekId,DietID")] Diet_DayPerWeek diet_DayPerWeek)
        {
            if (ModelState.IsValid)
            {
                db.Diet_DayPerWeek.Add(diet_DayPerWeek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DayPerWeekId = new SelectList(db.DayPerWeeks, "Id", "Day", diet_DayPerWeek.DayPerWeekId);
            ViewBag.DietID = new SelectList(db.DietPlans, "Id", "Title", diet_DayPerWeek.DietID);
            return View(diet_DayPerWeek);
        }

        // GET: Diet_DayPerWeek/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet_DayPerWeek diet_DayPerWeek = db.Diet_DayPerWeek.Find(id);
            if (diet_DayPerWeek == null)
            {
                return HttpNotFound();
            }
            ViewBag.DayPerWeekId = new SelectList(db.DayPerWeeks, "Id", "Day", diet_DayPerWeek.DayPerWeekId);
            ViewBag.DietID = new SelectList(db.DietPlans, "Id", "Title", diet_DayPerWeek.DietID);
            return View(diet_DayPerWeek);
        }

        // POST: Diet_DayPerWeek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DayPerWeekId,DietID")] Diet_DayPerWeek diet_DayPerWeek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diet_DayPerWeek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DayPerWeekId = new SelectList(db.DayPerWeeks, "Id", "Day", diet_DayPerWeek.DayPerWeekId);
            ViewBag.DietID = new SelectList(db.DietPlans, "Id", "Title", diet_DayPerWeek.DietID);
            return View(diet_DayPerWeek);
        }

        // GET: Diet_DayPerWeek/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet_DayPerWeek diet_DayPerWeek = db.Diet_DayPerWeek.Find(id);
            if (diet_DayPerWeek == null)
            {
                return HttpNotFound();
            }
            return View(diet_DayPerWeek);
        }

        // POST: Diet_DayPerWeek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diet_DayPerWeek diet_DayPerWeek = db.Diet_DayPerWeek.Find(id);
            db.Diet_DayPerWeek.Remove(diet_DayPerWeek);
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
