using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Models
{
    public class Organization
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Service> ServiceList { get; set; } 
    }
}
