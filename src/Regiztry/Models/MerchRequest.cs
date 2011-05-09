using System;

namespace Regiztry.Models
{
    public class MerchRequest
    {
        public int Id { get; set; }
       
        public Startup Requestor { get; set; }
        public Guid Identifier { get; set; }
        public DateTime RequestedOn { get; set; }
        public string Description { get; set; }
    }
}