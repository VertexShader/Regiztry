using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Regiztry.Models
{
    public class Individuals
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public List< Uri> WebPresence { get; set; }
        public string About { get; set; }
        public DateTime StartedHelping { get; set; }
    }
}