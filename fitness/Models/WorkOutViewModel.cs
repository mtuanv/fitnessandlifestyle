using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fitness.Models
{
    public class WorkOutViewModel
    {
        public WorkOut WorkOut { get; set; }
        public ICollection<DietPlan> DietPlans { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
        public ICollection<DayPerWeek> DayPerWeeks { get; set; }
    }
}