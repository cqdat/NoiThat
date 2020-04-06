using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoiThat.Models.DataModels;

namespace NoiThat.Models
{
    public class HeaderViewModel
    {
        public string logo { get; set; }
        public List<Category> lstCategories { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}