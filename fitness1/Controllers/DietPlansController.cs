using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fitness.Models;

namespace fitness.Controllers
{
    [Authorize]
    public class DietPlansController : Controller
    {
        private fitnessandlifestyle db = new fitnessandlifestyle();

        // GET: DietPlans
        public ActionResult Index()
        {
            return View(db.DietPlans.ToList());
        }

        // GET: DietPlans/Details/5
        public ActionResult Details(int? id)
        {
            DietViewModel dvm = new DietViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietPlan dietPlan = db.DietPlans.Find(id);
            if (dietPlan == null)
            {
                return HttpNotFound();
            }
            dvm.dietPlan = dietPlan;
            int category = db.DietPlans.Find(id).Category;
            IList<WorkOut> workOut = db.WorkOuts.Where(w=> w.Category == category).ToList();
            dvm.workOuts = workOut;
            IList<DayPerWeek> dayPerWeeks = db.DayPerWeeks.ToList();
            dvm.dayPerWeeks = dayPerWeeks;
            IList<Resource> resources = db.Resources.ToList();
            dvm.resources = resources;
            return View(dvm);
        }

        // GET: DietPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DietPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,Link,Category")] DietPlan dietPlan)
        {
            if (ModelState.IsValid)
            {
                db.DietPlans.Add(dietPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dietPlan);
        }

        // GET: DietPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietPlan dietPlan = db.DietPlans.Find(id);
            if (dietPlan == null)
            {
                return HttpNotFound();
            }
            return View(dietPlan);
        }

        // POST: DietPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,Link,Category")] DietPlan dietPlan, int id)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(dietPlan).State = EntityState.Modified;
                Order orderchange = db.Orders.Find(id);
                orderchange.timestamp = DateTime.Now;
                db.SaveChanges();
               
                return RedirectToAction("Index");
            }
            return View(dietPlan);
        }

        // GET: DietPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietPlan dietPlan = db.DietPlans.Find(id);
            if (dietPlan == null)
            {
                return HttpNotFound();
            }
            return View(dietPlan);
        }

        // POST: DietPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DietPlan dietPlan = db.DietPlans.Find(id);
            db.DietPlans.Remove(dietPlan);
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
