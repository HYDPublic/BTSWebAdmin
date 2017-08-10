using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PipelinesOM.Models
{
    public class Pipeline
    {

        public List<Stage> Stages { get; set; } = new List<Stage>();
    }
}