using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoiThat.Models.DataModels;

namespace NoiThat.Models
{
    public class FooterViewModel
    {
        public List<Blog> lstAboutus { get; set; }
        public List<Blog> lstWebsite { get; set; }
        public List<Blog> lstAboutus_more { get; set; }
        public List<Blog> lstAddress { get; set; }
    }
}