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
    [Authorize]
    public class WorkOutsController : Controller
    {
        private fitnessandlifestyle db = new fitnessandlifestyle();

        // GET: WorkOuts
        public ActionResult Index()
        {
            WorkoutModelIndex model = new WorkoutModelIndex();
            model.Exercises = db.Exercises.ToList();
            model.WorkOuts = db.WorkOuts.ToList();
            model.Schedules = db.Schedules.ToList();
            return View(model);
        }

        // GET: WorkOuts/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOut workOut = db.WorkOuts.Find(id);
            if (workOut == null)
            {
                return HttpNotFound();
            }
            WorkOutViewModel model = new WorkOutViewModel();
            model.WorkOut = workOut;
            int category = db.WorkOuts.Find(id).Category;
            model.DietPlans = db.DietPlans.Where(d => d.Category == category).ToList();
            model.Exercises = db.Exercises.ToList();
            model.DayPerWeeks = db.DayPerWeeks.ToList();
            model.Schedules = db.Schedules.ToList();
            model.Resources = db.Resources.ToList();
            return View(model);
        }

        // GET: WorkOuts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkOuts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,Title,WeightChange,minAge,maxAge,Category,ForGender,ProgressTime,Link")] WorkOut workOut)
        {
            if (ModelState.IsValid)
            {
                db.WorkOuts.Add(workOut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workOut);
        }

        // GET: WorkOuts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOut workOut = db.WorkOuts.Find(id);
            if (workOut == null)
            {
                return HttpNotFound();
            }
            return View(workOut);
        }

        // POST: WorkOuts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,Title,WeightChange,minAge,maxAge,Category,ForGender,ProgressTime,Link")] WorkOut workOut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workOut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workOut);
        }

        // GET: WorkOuts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOut workOut = db.WorkOuts.Find(id);
            if (workOut == null)
            {
                return HttpNotFound();
            }
            return View(workOut);
        }

        // POST: WorkOuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkOut workOut = db.WorkOuts.Find(id);
            db.WorkOuts.Remove(workOut);
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
