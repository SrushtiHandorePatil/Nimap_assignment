using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nimap_assignment.Models
{
    public class Category
    {
        public int id { get; set; } 
        public string categoryname { get; set; }
        public string active { get; set; }
        public string productname { get; internal set; }
    }
}