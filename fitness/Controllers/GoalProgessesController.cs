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
    public class GoalProgessesController : Controller
    {
        private fitnessandlifestyle db = new fitnessandlifestyle();

        // GET: GoalProgesses
        public ActionResult Index()
        {
            var goalProgesses = db.GoalProgesses.Include(g => g.Goal);
            return View(goalProgesses.ToList());
        }

        // GET: GoalProgesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoalProgess goalProgess = db.GoalProgesses.Find(id);
            if (goalProgess == null)
            {
                return HttpNotFound();
            }
            return View(goalProgess);
        }

        // GET: GoalProgesses/Create
        public ActionResult Create()
        {
            ViewBag.GoalId = new SelectList(db.Goals, "Id", "UserId");
            return View();
        }

        // POST: GoalProgesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CurrentWeight,CurrentHeight,GoalId")] GoalProgess goalProgess)
        {
            if (ModelState.IsValid)
            {
                db.GoalProgesses.Add(goalProgess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GoalId = new SelectList(db.Goals, "Id", "UserId", goalProgess.GoalId);
            return View(goalProgess);
        }

        // GET: GoalProgesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoalProgess goalProgess = db.GoalProgesses.Find(id);
            if (goalProgess == null)
            {
                return HttpNotFound();
            }
            ViewBag.GoalId = new SelectList(db.Goals, "Id", "UserId", goalProgess.GoalId);
            return View(goalProgess);
        }

        // POST: GoalProgesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CurrentWeight,CurrentHeight,GoalId")] GoalProgess goalProgess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goalProgess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GoalId = new SelectList(db.Goals, "Id", "UserId", goalProgess.GoalId);
            return View(goalProgess);
        }

        // GET: GoalProgesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoalProgess goalProgess = db.GoalProgesses.Find(id);
            if (goalProgess == null)
            {
                return HttpNotFound();
            }
            return View(goalProgess);
        }

        // POST: GoalProgesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GoalProgess goalProgess = db.GoalProgesses.Find(id);
            db.GoalProgesses.Remove(goalProgess);
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
