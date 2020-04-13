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
        public Category category { get; set; }
    }

    public class ServiceViewModel
    {
        public string Title { get; set; }
        public List<Blog> blogs { get; set; }
        public bool? HasID { get; set; }
    }
}