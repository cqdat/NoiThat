﻿using System;
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
            model.lstBannerPro = db.Advertises.Where(a => a.IsActive == true && a.Location == 1).ToList();
            model.lstAboutUsMore = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs_more && b.IsActive == true && b.BlogID !=3).ToList();
            //model.lstLastProducts = db.Products.Where(p => p.IsProduct == true && p.IsActive == true).OrderByDescending(p => p.ProductID).Take(4).ToList();
            model.lstLastProducts = db.ProductGroups.Where(p => p.GroupCode ==WebConstants.ProductMoi).OrderByDescending(p => p.ProductID).Take(4).ToList();
            //model.lstBestSellerproducts = db.Products.Where(p => p.IsProduct == true && p.IsActive == true).OrderBy(p => Guid.NewGuid()).Take(6).ToList();
            model.lstBestSellerproducts = db.ProductGroups.Where(g => g.GroupCode == WebConstants.ProductBanChay).OrderByDescending(b=>b.ProductID).Take(8).ToList();
            model.lstSanPhamNoiBat = db.ProductGroups.Where(g => g.GroupCode == WebConstants.ProductNoiBat).ToList();
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
            model.menu_lstProducts = db.Categories.Where(c => c.Parent == 0 && c.DisplayMenu == true && c.IsActive == true && c.TypeCate == WebConstants.CategoryProduct).ToList();
            model.menu_lstCollections = db.Categories.Where(c => c.Parent == 0 && c.DisplayMenu == true && c.IsActive == true && c.TypeCate == WebConstants.CategoryCollection).ToList();
            model.menu_lstTuVanDichVu = db.Categories.Where(c => c.Parent == 0 && c.IsActive == true && c.TypeCate == WebConstants.CategoryNews).ToList();
            model.menu_lstServices = db.Categories.Where(c => c.Parent == 0 && c.IsActive == true && c.TypeCate == WebConstants.CategoryService).ToList();
            var gt = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs_more && b.BlogID == 3 && b.IsActive == true).FirstOrDefault();
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
            model.Email = db.Information.Where(a => a.InfoID == 3).FirstOrDefault().InfoContent;

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
            model.lstCollection2 = db.Products.Where(p => p.IsProduct == false && p.IsActive == true).OrderBy(p => Guid.NewGuid()).Take(3).ToList();
            model.lstCollection3 = db.Products.Where(p => p.IsProduct == false && p.IsActive == true).OrderBy(p => Guid.NewGuid()).Take(3).ToList();

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

            model.lstAboutus = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs && b.IsActive == true).OrderBy(c => c.Sort).ToList();
            model.lstAboutus_more = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs_more && b.IsActive == true).OrderBy(c => c.Sort).ToList();
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
            model.lstLeftMenu = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs && b.IsActive == true).OrderBy(c => c.Sort).ToList();
            model.lstAbout_more = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs_more && b.IsActive == true).OrderBy(c => c.Sort).ToList();
            ViewBag.Title = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs_more && b.BlogID == 3 && b.IsActive == true).FirstOrDefault().SEOTitle;
            return View(model);
        }

        public ActionResult Contact()
        {
            AboutUsViewModel model = new AboutUsViewModel();
            
            model.lstLeftMenu = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs).OrderBy(c => c.Sort).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult CustomerContact(FormCollection f)
        {
            CustomerContact c = new CustomerContact();
            c.CustomerName = f["txtFullname"];
            c.CustomerEmail = f["txtEmail"];
            c.CustomerPhone = f["txtPhone"];
            c.CustomerContent = f["txtContent"];
            c.Created = DateTime.Now;
            db.CustomerContacts.Add(c);
            db.SaveChanges();
            ViewBag.Message = "Thông tin của bạn đã được hệ thống ghi nhận, chúng tôi sẽ phản hồi bạn trong thời gian sớm nhất";

            //return View("Contact","Home");
            return Redirect("/lien-he");
        }
        public ActionResult NotFound()
        {
            ViewBag.Message = "Không tìm thấy trang như ý muốn của bạn!";

            return View();
        }
    }
}