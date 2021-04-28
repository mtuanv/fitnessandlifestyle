using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fitness.Models;
using Microsoft.AspNet.Identity;

namespace fitness.Controllers
{
    public class OrdersController : Controller
    {
        private fitnessandlifestyle db = new fitnessandlifestyle();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.AspNetUser).Include(o => o.DietPlan).Include(o => o.WorkOut);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.DietplanId = new SelectList(db.DietPlans, "Id", "Title");
            ViewBag.WorkoutId = new SelectList(db.WorkOuts, "Id", "Content");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,WorkoutId,DietplanId")] Order order)
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            AspNetUser user = db.AspNetUsers.Where(u => u.Email.Equals(username)).First();
            order.UserId = user.Id;
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Indexz");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", order.UserId);
            ViewBag.DietplanId = new SelectList(db.DietPlans, "Id", "Title", order.DietplanId);
            ViewBag.WorkoutId = new SelectList(db.WorkOuts, "Id", "Content", order.WorkoutId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", order.UserId);
            ViewBag.DietplanId = new SelectList(db.DietPlans, "Id", "Title", order.DietplanId);
            ViewBag.WorkoutId = new SelectList(db.WorkOuts, "Id", "Content", order.WorkoutId);
            return RedirectToAction("UserPlan", "Profile");
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,WorkoutId,DietplanId")] Order order, int id)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(order).State = EntityState.Modified;
                Order orderchange = db.Orders.Find(id);
                orderchange.timestamp = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("UserPlan", "Profile");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", order.UserId);
            ViewBag.DietplanId = new SelectList(db.DietPlans, "Id", "Title", order.DietplanId);
            ViewBag.WorkoutId = new SelectList(db.WorkOuts, "Id", "Content", order.WorkoutId);
            return RedirectToAction("UserPlan", "Profile");
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("UserOrder", "Profile");
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("UserOrder", "Profile");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult UserOrder(OrderVM orderVMs)
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            AspNetUser user = db.AspNetUsers.Where(u => u.Email.Equals(username)).First();
            Order order1 = new Order();
            order1.UserId = user.Id;
            if(orderVMs.dietid == 0)
            {
                order1.DietplanId = null;
            }
            else
            {
                order1.DietplanId = orderVMs.dietid;
            }
            if (orderVMs.wkid == 0)
            {
                order1.WorkoutId = null;
            }
            else
            {
                order1.WorkoutId = orderVMs.wkid;
            }
            db.Orders.Add(order1);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
