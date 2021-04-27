using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fitness.Models
{
    public class WorkoutModelIndex
    {
        public ICollection<WorkOut> WorkOuts { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}