using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoiThat.Models.DataModels;

namespace NoiThat.Models
{
    public class NewsViewModel
    {
        public Blog blogdetail { get; set; }
        public List<Blog> lstBlogsNewest { get; set; }
        public List<Category> lstServices { get; set; }
        public List<Advertise> LeftPromote { get; set; }
        public Category category { get; set; }
        public string Title { get; set; }
        public string TitleUrl { get; set; }
        public string SEOTitle { get; set; }
        public string SEOKeywords { get; set; }
        public string SEOMetadescription { get; set; }
    }

    public class ServiceViewModel
    {
        //public string Title { get; set; }
        public List<Blog> blogs { get; set; }
        public bool? HasID { get; set; }
        public string SEOTitle { get; set; }
        public string SEOKeywords { get; set; }
        public string SEOMetadescription { get; set; }
    }
}