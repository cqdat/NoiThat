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
        public List<Blog> lstBlogs { get; set; }
    }
}