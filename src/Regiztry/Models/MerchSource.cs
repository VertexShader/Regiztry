using System;

namespace Regiztry.Models
{
    public class MerchSource
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        public Uri WebSite { get; set; }
        public string Instructions { get; set; }
        public string Description { get; set; }
    }
}