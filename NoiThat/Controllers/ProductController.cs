﻿using NoiThat.Models;
using NoiThat.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoiThat.Controllers
{
    public class ProductController : Controller
    {
        TanThoiEntities db = new TanThoiEntities();
        // GET: Product
        public ActionResult Index()
        {
            ListProductViewModel model = new ListProductViewModel();
            model.Title = "Tất cả sản phẩm";
            model.categories = db.Categories.Where(q => q.IsActive == true && q.TypeCate == 1 && q.Parent == 0).ToList();
            model.slides = db.Slides.Where(q => q.IsActive == true && q.CategoryID == -1).ToList();
            model.products = db.Products.Where(q => q.IsActive == true).ToList();
            return View(model);
        }

        public ActionResult List(int? id)
        {
            ListProductViewModel2 model = new ListProductViewModel2();

            var cate = db.Categories.Find(id);

            if(cate.Parent > 0)
            {
                var p = db.Categories.Find(cate.Parent);
                model.TitleParent = p.CategoryName;
                model.LinkParent = "/san-pham/" + p.SEOUrlRewrite + "-" + p.CategoryID;
            }
            else
            {
                model.TitleParent = "Tất cả sản phẩm";
                model.LinkParent = "/san-pham/tat-ca";
            }


            model.Title = cate.CategoryName;
            model.categories = db.Categories.Where(q => q.IsActive == true && q.TypeCate == 1 && q.Parent == 0).ToList();
            var slide = db.Slides.Where(q => q.IsActive == true && q.CategoryID == id).ToList();

            if(slide.Count == 0)
            {
                model.slides = db.Slides.Where(q => q.IsActive == true && q.CategoryID == -1).ToList();
            }
            else
            {
                model.slides = slide;
            }
            
            model.products = db.Products.Where(q => q.IsActive == true).ToList();
            return View(model);
        }

        public ActionResult Detail(int? id)
        {
            return View();
        }
    }
}