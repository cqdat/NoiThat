using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoiThat.Models.DataModels;

namespace NoiThat.Models
{
    public class CollectionsViewModel
    {
        public Product detail { get; set; }
        public List<ProductImage> lstImages { get; set; }
        public List<Product> lstCollection1 { get; set; }
        public List<Product> lstCollection2 { get; set; }
        public List<Product> lstCollection3 { get; set; }
    }
}