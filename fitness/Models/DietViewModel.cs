using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fitness.Models
{
    public class DietViewModel
    {
        public DietPlan dietPlan { get; set; }
        public ICollection<DayPerWeek> dayPerWeeks { get; set; }
        public ICollection<Resource> resources { get; set; }
        public ICollection<WorkOut> workOuts { get; set; } 
    }
}