using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fitness.Models
{
    public class ResultOrder
    {
        public int WorkoutID { get; set; }
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Image { get; set; }
    }
}