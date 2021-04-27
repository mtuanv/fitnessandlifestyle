using fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace fitness.Controllers
{
    public class SearchController : Controller
    {
        private fitnessandlifestyle db = new fitnessandlifestyle();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SearchResult(string search)
        {
            SearchViewModel svm = new SearchViewModel();
            svm.search = search;
            string s = search.ToLower();
            string[] gain = {"gain", "increase", "rise", "addition", "accretion", "augmentation",
                "icrement", "buildup", "growth", "accrual", "addendum", "boost", "expansion", "plus",
                "proliferation", "raise", "step up", "supplement", "uptick", "accumulation", "upsurge",
                "upturn", "hike", "more", "up", "upping", "escalation", "development", "enlargement", "advance", "heavier"};
            string[] lose = {"loss", "lose", "slimming", "emaciation", "emaciating", "loosing", "reduction", "emaciate",
                "slim down", "reduce", "slim", "thin", "slenderise", "slenderize", "melt off", "thinner"};
            string[] sspl = s.Split(' ');
            int flag = 0;
            for(int i = 0; i < sspl.Length; i++)
            {
                for(int j = 0; j < gain.Length; j++)
                {
                    if (sspl[i].Contains(gain[j])){
                        flag = 1;
                    }
                }
            }
            for (int i = 0; i < sspl.Length; i++)
            {
                for (int j = 0; j < lose.Length; j++)
                {
                    if (sspl[i].Contains(lose[j]))
                    {
                        flag = 2;
                    }
                }
            }
            if (flag == 1)
            {
                svm.WorkOuts = db.WorkOuts.Where(w => w.Category == 1).ToList();
                svm.DietPlans = db.DietPlans.Where(d => d.Category == 1).ToList();
                return View(svm);
            }
            else if(flag == 2)
            {
                svm.WorkOuts = db.WorkOuts.Where(w => w.Category == 2).ToList();
                svm.DietPlans = db.DietPlans.Where(d => d.Category == 2).ToList();
                return View(svm);
            }
            else
            {
                svm.WorkOuts = db.WorkOuts.Where(w => w.Content.Contains(search) || w.Title.Contains(search) || search.Contains(w.WeightChange.ToString()) || search.Contains(w.minAge.ToString()) || search.Contains(w.maxAge.ToString())).ToList();
                svm.DietPlans = db.DietPlans.Where(d => d.Content.Contains(search) || d.Title.Contains(search)).ToList();
                return View(svm);
            }
            
        }
    }
}