using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nimap_assignment.Models
{
    public class Product
    {
        public int categoryid { get; set; }
        public  string productname { get; set; }
        public string active { get; set; }
        public int id { get; set; }
        public string categoryname { get; set; }
    }
}