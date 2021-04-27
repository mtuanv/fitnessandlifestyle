using fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fitness.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private fitnessandlifestyle db = new fitnessandlifestyle();
        // GET: Profile
        public ActionResult UserDiagram()
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            AspNetUser user = db.AspNetUsers.Where(u => u.Email.Equals(username)).First();
            Goal goal = db.Goals.Where(n => n.UserId == user.Id).FirstOrDefault();
            if (goal != null)
            {
                string listProgess = "";
                ViewBag.GoalID = goal.Id;
                var list = db.GoalProgesses.Where(n => n.GoalId == goal.Id).OrderByDescending(n => n.timestamp).ToList();
                for(int i = 0; i < list.Count(); i++)
                {
                    listProgess += list[i].timestamp + "-" + list[i].CurrentWeight + "--";
                }
                ViewBag.progess = listProgess;
            }
            return View(user);
        }
        [Authorize]
        public ActionResult UserProfile()
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            AspNetUser user = db.AspNetUsers.Where(u => u.Email.Equals(username)).First();

            //Goal goal = db.Goals.Find("UserId = '"+ user.Id + "'");
            Goal goal = db.Goals.Where(n => n.UserId == user.Id).FirstOrDefault();
            if(goal != null)
            {
                ViewBag.Goal = goal.WeightDesired;
            }
            return View(user);
        }
        [Authorize]
        public ActionResult UserPlan()
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            AspNetUser user = db.AspNetUsers.Where(u => u.Email.Equals(username)).First();
            var listOrder = db.Orders.Where(o => o.UserId == user.Id && o.timestamp != null).ToList();
            Goal goal = db.Goals.Where(n => n.UserId == user.Id).FirstOrDefault();
            if (goal != null)
            {
                GoalProgess lastProgess = db.GoalProgesses.Where(g => g.GoalId == goal.Id).OrderByDescending(g => g.timestamp).FirstOrDefault();
                if(lastProgess != null)
                {
                    ViewBag.currentResult = lastProgess.CurrentWeight - user.UserWeight;
                }
                else
                {
                    ViewBag.currentResult = user.UserWeight;
                }
                
            }
            ViewBag.name = user.FirstName + " " + user.LastName;
            ViewBag.email = user.Email;

            return View(listOrder);
        }
        [Authorize]
        public ActionResult UserBMI()
        {
            return View();
        }
        [Authorize]
        public ActionResult UserOrder()
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            AspNetUser user = db.AspNetUsers.Where(u => u.Email.Equals(username)).First();
            var listOrder = db.Orders.Where(o => o.UserId == user.Id && o.timestamp == null).ToList();
            ViewBag.name = user.FirstName + " " + user.LastName;
            ViewBag.email = user.Email;
            return View(listOrder);
        }
        [Authorize]
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

            Goal goal = db.Goals.Where(n => n.UserId == user.Id).FirstOrDefault();
            if(goal != null)
            {
                goal.WeightDesired = desire_weight;
                goal.UserId = user.Id;
                goal.Category = category;
                goal.StatusGoal = 0;
                db.SaveChanges();
            } else
            {
                Goal newGoal = new Goal();
                newGoal.WeightDesired = desire_weight;
                newGoal.UserId = user.Id;
                newGoal.Category = category;
                newGoal.StatusGoal = 0;
                db.Goals.Add(newGoal);
                db.SaveChanges();
            }
            
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        /*/Profile/GetListProgress*/
        public JsonResult GetListProgress(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            //var list = db.GoalProgesses.ToList();
            var list = db.GoalProgesses.Where(n => n.GoalId == id).ToList();
            //var list = from progess in db.GoalProgesses where progess.GoalId == userGoal.Id select progess;
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult UserInputInfo()
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            AspNetUser user = db.AspNetUsers.Where(u => u.Email.Equals(username)).First();
            return View(user);
        }
        [Authorize]
        [HttpPost]
        public ActionResult UpdateProgess(int weight, int height)
        {

            var username = System.Web.HttpContext.Current.User.Identity.Name;
            AspNetUser user = db.AspNetUsers.Where(u => u.Email.Equals(username)).First();

            Goal userGoal = db.Goals.Where(n => n.UserId == user.Id).FirstOrDefault();
            if (userGoal != null)
            {
                int goalId = userGoal.Id;

                GoalProgess progess = new GoalProgess();
                progess.CurrentHeight = height;
                progess.CurrentWeight = weight;
                progess.GoalId = goalId;
                progess.timestamp = DateTime.Now;
                db.GoalProgesses.Add(progess);
                db.SaveChanges();

                return RedirectToAction("UserPlan", "Profile");
            } else
            {
                return RedirectToAction("UserProfile", "Profile");
            }
            
        }
    }
}