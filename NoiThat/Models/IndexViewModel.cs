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
        public List<Advertise> lstBannerPro { get; set; }
        public List<Blog> lstAboutUsMore { get; set; }
        public List<Product> lstLastProducts { get; set; }
        public List<Product> lstBestSellerproducts { get; set; }
        public List<ProductGroup> lstSanPhamNoiBat { get; set; }
        public List<Blog> lstNews { get; set; }

    }

    public class SearchViewModel
    {
        public List<Product> products { get; set; }
        public string TuKhoa { get; set; }
        public List<Category> categories { get; set; }
    }

}