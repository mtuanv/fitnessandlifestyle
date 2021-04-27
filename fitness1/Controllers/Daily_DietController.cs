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
    public class Daily_DietController : Controller
    {
        private fitnessandlifestyle db = new fitnessandlifestyle();

        // GET: Daily_Diet
        public ActionResult Index()
        {
            var daily_Diet = db.Daily_Diet.Include(d => d.Diet_DayPerWeek);
            return View(daily_Diet.ToList());
        }

        // GET: Daily_Diet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Daily_Diet daily_Diet = db.Daily_Diet.Find(id);
            if (daily_Diet == null)
            {
                return HttpNotFound();
            }
            return View(daily_Diet);
        }

        // GET: Daily_Diet/Create
        public ActionResult Create()
        {
            ViewBag.DDId = new SelectList(db.Diet_DayPerWeek, "Id", "Id");
            return View();
        }

        // POST: Daily_Diet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Content,Link,DDId")] Daily_Diet daily_Diet)
        {
            if (ModelState.IsValid)
            {
                db.Daily_Diet.Add(daily_Diet);
                db.SaveChanges();
                return View("Create");
            }

            ViewBag.DDId = new SelectList(db.Diet_DayPerWeek, "Id", "Id", daily_Diet.DDId);
            return View(daily_Diet);
        }

        // GET: Daily_Diet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Daily_Diet daily_Diet = db.Daily_Diet.Find(id);
            if (daily_Diet == null)
            {
                return HttpNotFound();
            }
            ViewBag.DDId = new SelectList(db.Diet_DayPerWeek, "Id", "Id", daily_Diet.DDId);
            return View(daily_Diet);
        }

        // POST: Daily_Diet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Content,Link,DDId")] Daily_Diet daily_Diet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(daily_Diet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DDId = new SelectList(db.Diet_DayPerWeek, "Id", "Id", daily_Diet.DDId);
            return View(daily_Diet);
        }

        // GET: Daily_Diet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Daily_Diet daily_Diet = db.Daily_Diet.Find(id);
            if (daily_Diet == null)
            {
                return HttpNotFound();
            }
            return View(daily_Diet);
        }

        // POST: Daily_Diet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Daily_Diet daily_Diet = db.Daily_Diet.Find(id);
            db.Daily_Diet.Remove(daily_Diet);
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
