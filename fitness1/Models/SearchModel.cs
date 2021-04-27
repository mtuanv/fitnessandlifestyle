using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fitness.Models
{
    public class SearchModel
    {
        public ICollection<WorkOut> WorkOuts { get; set; }
        public ICollection<DietPlan> DietPlans { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
        public ICollection<Daily_Diet> Daily_Diets { get; set; }
    }
}