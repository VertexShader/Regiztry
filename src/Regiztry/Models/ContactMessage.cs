using System;

namespace Regiztry.Models
{
    public class ContactMessage
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime Sent { get; set; }
    }
}