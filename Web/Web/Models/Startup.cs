using System;
using System.Collections.Generic;

namespace Web.Models
{
    public class Startup
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string State { get; set; }

        public List<NeededStuff> Needs
        {
            get;
            set;
        }
    }

    public class NeededStuff
    {
        public string TheThing { get; set; }
        public string Description { get; set; }
        public DateTime NeedBy { get; set; }
    }
}