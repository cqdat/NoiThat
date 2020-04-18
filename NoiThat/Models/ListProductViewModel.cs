using NoiThat.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoiThat.Models
{
    public class ListProductViewModel
    {
        public string Title { get; set; }
        public List<Category> categories { get; set; }
        public List<Product> products { get; set; }
        public List<Slide> slides { get; set; }
    }

    public class ListProductViewModel2
    {
        public string Title { get; set; }
        public List<Category> categories { get; set; }
        public List<Product> products { get; set; }
        public List<Slide> slides { get; set; }
        public List<Advertise> LeftPromote { get; set; }
        public string TitleParent { get; set; }
        public string LinkParent { get; set; }
    }

    public class ProductDetailViewModel
    {
        public string CategoryName { get; set; }
        public string CategoryLink { get; set; }
        public Product product { get; set; }
        public List<ListImage> listimage { get; set; }
        public List<Product> relate { get; set; }
        public List<Product> upsell { get; set; }
    }

    public class ListImage
    {
        public string ImageURL { get; set; }
        public string URLThumb { get; set; }
    }

    public class QuickViewModel
    {
        public Product product { get; set; }
        public List<ListImage> listimage { get; set; }
    }

}