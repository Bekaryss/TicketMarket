using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Models
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ServiceCategory() { }
        public ServiceCategory(int _id, string _name, string _description)
        {
            Id = _id;
            Name = _name;
            Description = _description;
        }
    }
}
