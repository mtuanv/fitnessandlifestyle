using fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fitness.Controllers
{
    public class ProfileController : Controller
    {
        private fitnessandlifestyle db = new fitnessandlifestyle();
        // GET: Profile
        public ActionResult UserDiagram()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            AspNetUser user = db.AspNetUsers.Where(u => u.Email.Equals(username)).First();
            return View(user);
        }

        public ActionResult UserPlan()
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            AspNetUser user = db.AspNetUsers.Where(u => u.Email.Equals(username)).First();
            var listOrder = db.Orders.Where(o => o.UserId == user.Id && o.timestamp != null).ToList();
            return View(listOrder);
        }

        public ActionResult UserBMI()
        {
            return View();
        }
        public ActionResult UserOrder()
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            AspNetUser user = db.AspNetUsers.Where(u => u.Email.Equals(username)).First();
            var listOrder = db.Orders.Where(o => o.UserId == user.Id && o.timestamp == null).ToList();
            return View(listOrder);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProfile(string id, string firstName, string lastName, int gender, int age, string email, string phone, int weight, int height )
        {
            AspNetUser user = db.AspNetUsers.Find(id);
            user.UserName = firstName + lastName;
            user.UserAge = age;
            user.Gender = gender;
            user.Email = email;
            user.UserWeight = weight;
            user.UserHeight = height;
            db.SaveChanges();
            return View();
        }


        /*/Profile/GetListProgress*/
        public JsonResult GetListProgress(string searchTerm)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var list = db.GoalProgesses.ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}