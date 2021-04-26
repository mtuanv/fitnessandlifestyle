using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fitness.Servies
{
    public class notification : Hub
    {
        public string Hello()
        {
            return "notification testing";
        }
    }
}