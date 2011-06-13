using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Regiztry.Models
{
    public class Setting
    {
        public string RegiztryUser { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public List<string> Groups { get; set; } // Founder, Contributer, User/Observer
        public DateTime FirstIdentificationMade { get; set; }
    }
}