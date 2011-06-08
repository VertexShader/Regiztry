using System;

namespace Regiztry.Models
{
    public class YeIdentity
    {
        public Guid SisoId { get; set; }
        public string UsedName { get; set; }
        public string FullName { get; set; }
        public DateTime FirstLogin { get; set; }
        public string[] Involvement { get; set; }
    }
}