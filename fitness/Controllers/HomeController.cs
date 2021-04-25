using fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace fitness.Controllers
{
    public class HomeController : Controller
    {
        fitnessandlifestyle db = new fitnessandlifestyle();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Team()
        {
            return View();
        }
        public ActionResult BMI()
        {
            return View();
        }

        [HttpPost]
        public JsonResult calculateBMI(BMI bmi)
        {
            if (bmi.Height != 0)
            {
                float weight = bmi.Weight;
                float height = (float)(bmi.Height)/100;
                float res = (weight / (height * height));
                string result = String.Format("{0:0.00}", res);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult listWorkOut(BMI_parameter bMI_Parameter)
        {
            
            bool proxyCreation = db.Configuration.ProxyCreationEnabled;
            try
            {
                //set ProxyCreation to false
                db.Configuration.ProxyCreationEnabled = false;

                var data = db.WorkOuts.Where(i => i.Category == 2).ToList();

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
            finally
            {
                //restore ProxyCreation to its original state
                db.Configuration.ProxyCreationEnabled = proxyCreation;
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}