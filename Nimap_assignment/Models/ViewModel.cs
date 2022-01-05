using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nimap_assignment.Models
{
    public class ViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
      
    }
}