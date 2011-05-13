using System;

namespace Regiztry.Models
{
    public class Startup
    {
        public Guid SisoId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Uri WebSite { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}