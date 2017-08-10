using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PipelinesOM.Models
{
    public class Component
    {
        public List<Property> Properties { get; set; } = new List<Property>();
        public string Name { get; set; }
    }
}