using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fitness.Models
{
    public class WorkOutViewModel
    {
        public WorkOut workOut { get; set; }
        public ICollection<DietPlan> dietPlans { get; set; }
    }
}