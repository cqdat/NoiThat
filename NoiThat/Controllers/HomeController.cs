using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoiThat.Models.DataModels;
using NoiThat.Utilities;
using NoiThat.Models;
using System.Net;

namespace NoiThat.Controllers
{
    public class HomeController : Controller
    {
        private TanThoiEntities db = new TanThoiEntities();
        Helpers h = new Helpers();

        /// <summary>
        /// Load các function chính ở Home Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.PhoneAndEmail = db.Information.Where(a => a.InfoID == 2 || a.InfoID == 3).ToList();
            model.lstSlideHomePage = db.Slides.Where(a => a.CategoryID == 0).ToList();
            model.lstAboutUsMore = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs_more && b.IsActive == true).ToList();
            model.lstLastProducts = db.Products.Where(p => p.IsProduct == true && p.IsActive == true).OrderByDescending(p => p.ProductID).Take(4).ToList();
            model.lstBestSellerproducts = db.Products.Where(p => p.IsProduct == true && p.IsActive == true).OrderBy(p => Guid.NewGuid()).Take(6).ToList();
            model.lstNews = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogNews && b.IsActive == true).OrderByDescending(c => c.LastModify).Take(3).ToList();
            return View(model);
        }

        #region _partial

        /// <summary>
        /// Menu
        /// </summary>
        /// <returns></returns>
        public PartialViewResult loadMenu()
        {
            //var model = db.MENUs.Where(q => q.IdCha == 0).OrderBy(o => o.ThuTu);

            MenuViewModel model = new MenuViewModel();
            model.menu_lstProducts = db.Categories.Where(c => c.Parent == 0 && c.IsActive == true && c.TypeCate == WebConstants.CategoryProduct).ToList();
            model.menu_lstCollections = db.Categories.Where(c => c.Parent == 0 && c.IsActive == true && c.TypeCate == WebConstants.CategoryCollection).ToList();
            model.menu_lstTuVanDichVu = db.Categories.Where(c => c.Parent == 0 && c.IsActive == true && c.TypeCate == WebConstants.CategoryNews).ToList();

            var gt = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs && b.BlogID == 3 && b.IsActive == true).FirstOrDefault();
            ViewBag.URLGioiThieu = gt.SEOUrlRewrite + "-" + gt.BlogID;
            return PartialView("_menusHomePage", model);
        }

        /// <summary>
        /// Load header Home Page
        /// </summary>
        /// <returns></returns>
        public PartialViewResult loadHeader()
        {
            //var model = db.MENUs.Where(q => q.IdCha == 0).OrderBy(o => o.ThuTu);

            HeaderViewModel model = new HeaderViewModel();
            model.logo = "";
            model.lstCategories = db.Categories.Where(c => c.Parent == 0 && c.IsActive == true && c.TypeCate == WebConstants.CategoryProduct).ToList();
            model.Phone = db.Information.Where(a => a.InfoID == 2).FirstOrDefault().InfoContent;
            model.Email = db.Information.Where(a => a.InfoID == 4).FirstOrDefault().InfoContent;

            return PartialView("_header", model);
        }

        /// <summary>
        /// Load Collections
        /// </summary>
        /// <returns></returns>
        public PartialViewResult loadColections()
        {
            //var model = db.MENUs.Where(q => q.IdCha == 0).OrderBy(o => o.ThuTu);

            CollectionsViewModel model = new CollectionsViewModel();
            model.lstCollection1 = db.Products.Where(p => p.IsProduct == false && p.IsActive == true).OrderBy(p => Guid.NewGuid()).Take(3).ToList();

            return PartialView("_lstCollection", model);
        }

        /// <summary>
        /// Load List logos customers
        /// </summary>
        /// <returns></returns>
        public PartialViewResult loadCustomersFooter()
        {
            //var model = db.MENUs.Where(q => q.IdCha == 0).OrderBy(o => o.ThuTu);

            var model = db.Customers.Where(c => c.IsActive == true).ToList();
            return PartialView("_logosCustomers", model);
        }

        /// <summary>
        /// Load list about us
        /// </summary>
        /// <returns></returns>
        public PartialViewResult loadFooter()
        {
            FooterViewModel model = new FooterViewModel();
            //var model = db.MENUs.Where(q => q.IdCha == 0).OrderBy(o => o.ThuTu);

            model.lstAboutus = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs).OrderBy(c => c.Sort).ToList();
            model.lstAboutus_more = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs_more).OrderBy(c => c.Sort).ToList();
            return PartialView("_footer", model);
        }
        #endregion
        /// <summary>
        /// Load Menu
        /// </summary>
        /// <returns></returns>


        public ActionResult About(int? id)
        {
            if (id == null)
            {
                return View("NotFound", "Home");
            }
            AboutUsViewModel model = new AboutUsViewModel();
            model.aboutus = db.Blogs.Where(b => b.IsActive == true && b.BlogID == id && (b.TypeBlog == WebConstants.BlogAboutUs || b.TypeBlog == WebConstants.BlogAboutUs_more)).FirstOrDefault();
            model.lstLeftMenu = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs).OrderBy(c => c.Sort).ToList();
            ViewBag.Title = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs && b.BlogID == 3 && b.IsActive == true).FirstOrDefault().BlogName;
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult NotFound()
        {
            ViewBag.Message = "Không tìm thấy trang như ý muốn của bạn!";

            return View();
        }
    }
}