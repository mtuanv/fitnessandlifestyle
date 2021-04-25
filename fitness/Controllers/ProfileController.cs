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
        // GET: Profile
        public ActionResult UserDiagram()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            return View();
        }

        public ActionResult UserPlan()
        {
            return View();
        }

        public ActionResult UserBMI()
        {
            return View();
        }
    }
}