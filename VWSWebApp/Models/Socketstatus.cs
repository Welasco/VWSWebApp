using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VWSWebApp.Tools;

namespace VWSWebApp.Models
{
    public class Socketstatus
    {
        public int OpenSockets { get; set; }
        public int ClosedSockets { get; set; }

    }
}