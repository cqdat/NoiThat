using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoiThat.Models;
using NoiThat.Models.DataModels;
using NoiThat.Utilities;

namespace NoiThat.Models
{
    public class AboutUsViewModel
    {
        public Blog aboutus { get; set; }
        public List<Blog> lstLeftMenu { get; set; }
    }
}