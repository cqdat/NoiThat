using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoiThat.Models.DataModels;

namespace NoiThat.Models
{
    public class MenuViewModel
    {
        public List<Category> menu_lstProducts { get; set; }
        public List<Category> menu_lstCollections { get; set; }
        public List<Category> menu_lstServices { get; set; }
        public List<Category> menu_lstTuVanDichVu { get; set; }
    }
}