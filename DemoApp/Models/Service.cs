using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Models
{
    public class Service
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public ServiceCategory Category { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
