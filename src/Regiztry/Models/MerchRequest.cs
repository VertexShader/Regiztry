using System;

namespace Regiztry.Models
{
    public class MerchRequest
    {
        public Startup Requestor { get; set; }
        public Guid Identifier { get; set; }
        public DateTime RequestedOn { get; set; }
        public string Description { get; set; }
    }
}