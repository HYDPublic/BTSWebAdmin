using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PipelinesOM.Models
{
    public class Stage
    {
        public List<Component> Components { get; set; } = new List<Component>();
        public string CategoryId { get; set; }
    }
}