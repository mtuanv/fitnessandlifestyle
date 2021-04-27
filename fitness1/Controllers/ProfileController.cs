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
        public ActionResult UpdateProfile(string firstname, string lastname, int gender, int age, int weight, int height, int desire_weight )
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            AspNetUser user = db.AspNetUsers.Where(u => u.Email.Equals(username)).First();

            user.FirstName = firstname;
            user.LastName = lastname;
            user.UserAge = age;
            user.Gender = gender;
            user.UserWeight = weight;
            user.UserHeight = height;
            db.SaveChanges();

            int category = 0;
            if(desire_weight >= weight)
            {
                category = 1;
            } else
            {
                category = 2;
            }

            Goal goal = new Goal();
            goal.WeightDesired = desire_weight;
            goal.UserId = user.Id;
            goal.Category = category;
            goal.StatusGoal = 0;
            db.Goals.Add(goal);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        /*/Profile/GetListProgress*/
        public JsonResult GetListProgress(string searchTerm)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var list = db.GoalProgesses.ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserInputInfo()
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            AspNetUser user = db.AspNetUsers.Where(u => u.Email.Equals(username)).First();
            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateProgess(int weight, int height)
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            AspNetUser user = db.AspNetUsers.Where(u => u.Email.Equals(username)).First();

            Goal userGoal = db.Goals.Find("UserId = " + user.Id);
            int goalId = userGoal.Id;

            GoalProgess progess = new GoalProgess();
            progess.CurrentHeight = height;
            progess.CurrentWeight = weight;
            progess.GoalId = goalId;
            progess.timestamp = DateTime.Now;
            db.GoalProgesses.Add(progess);
            db.SaveChanges();

            return RedirectToAction("UserPlan", "Profile");
        }
    }
}