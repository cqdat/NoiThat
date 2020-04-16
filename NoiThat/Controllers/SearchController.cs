using NoiThat.Models;
using NoiThat.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoiThat.Controllers
{
    public class SearchController : Controller
    {
        TanThoiEntities db = new TanThoiEntities();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Result()
        {
            string tukhoa = Request.QueryString[0].ToString().Trim();

            string theloai = Request.QueryString[1].ToString();

            string[] cate = theloai.Split('-');

            int cateid = Convert.ToInt32(cate[cate.Length - 1]);

            SearchViewModel model = new SearchViewModel();

            var products = db.Products.Where(q => q.IsActive == true && q.ProductName.Contains(tukhoa)).ToList();

            //string[] key = tukhoa.Split(' ');

            //for(int i = 0; i < key.Length; i++)
            //{

            //}

            if(cateid > 0)
            {
                products = products.Where(q => q.CategoryID == cateid).ToList();
            }

            model.TuKhoa = tukhoa;
            model.categories = db.Categories.Where(q => q.IsActive == true && q.TypeCate == 1 && q.Parent == 0).ToList();
            model.products = products;

            return View(model);
        }
    }
}