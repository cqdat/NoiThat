using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoiThat.Models.DataModels;

namespace NoiThat.Models
{
    public class IndexViewModel
    {
        public string logo { get; set; }
        public List<Information> PhoneAndEmail { get; set; }
        public List<Slide> lstSlideHomePage { get; set; }
        public List<Blog> lstAboutUsMore { get; set; }
        public List<Product> lstLastProducts { get; set; }
        public List<Blog> lstNews { get; set; }

    }
}