using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fitness.Models
{
    public class SearchViewModel
    {
        public ICollection<DietPlan> DietPlans { get; set; }
        public ICollection<WorkOut> WorkOuts { get; set; }
        public string search { get; set; }

    }
}