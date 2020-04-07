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
        public string TitleParent { get; set; }
        public string LinkParent { get; set; }
    }

}