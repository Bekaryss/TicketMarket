using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Models
{
    public class TicketDeteil
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
