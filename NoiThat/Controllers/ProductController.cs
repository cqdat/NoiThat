using NoiThat.Models;
using NoiThat.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoiThat.Utilities;
using PagedList;

namespace NoiThat.Controllers
{
    public class ProductController : Controller
    {
        TanThoiEntities db = new TanThoiEntities();
        // GET: Product
        public ActionResult Index()
        {
            ListProductViewModel2 model = new ListProductViewModel2();
            model.Title = "Tất cả sản phẩm";
            model.categories = db.Categories.Where(q => q.IsActive == true && q.TypeCate == 1 && q.Parent == 0).ToList();
            model.slides = db.Slides.Where(q => q.IsActive == true && q.CategoryID == -1).ToList();
            model.products = db.Products.Where(q => q.IsActive == true && q.IsProduct==true).ToList();
            model.LeftPromote = db.Advertises.Where(a => a.IsActive == true && a.Location == WebConstants.PromoteLeft).ToList();
            model.listviewed = GetListProduct();

            model.SEOTitle = model.Title;
            model.SEOKeywords = "";
            model.SEOMetadescription = "";

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
                model.LinkParent = "/san-pham";
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
            
            if(cate.Parent == 0)
            {
                model.products = db.Products.Where(q => q.IsActive == true && q.IsProduct == true && q.CategoryIDParent == id).ToList();
            }
            else
            {
                model.products = db.Products.Where(q => q.IsActive == true && q.IsProduct == true && q.CategoryID == id).ToList();
            }

            model.LeftPromote = db.Advertises.Where(a => a.IsActive == true && a.Location == WebConstants.PromoteLeft).ToList();
            model.listviewed = GetListProduct();

            model.SEOTitle = cate.SEOTitle;
            model.SEOKeywords = cate.SEOKeywords;
            model.SEOMetadescription = cate.SEOMetadescription;

            return View(model);
        }

        public ActionResult _grid(int? pageNumber, int? pageSize, string SanPham)
        {

            if (pageSize == -1)
            {
                pageSize = db.Products.Where(q => q.IsActive == true && q.IsProduct == true).ToList().Count;
            }
            ViewBag.PageSize = pageSize;

            var lstprod = db.Products.Where(q => q.IsActive == true && q.IsProduct == true).ToList();
            if (!string.IsNullOrEmpty(SanPham))
            {
                lstprod = lstprod.Where(s => s.ProductName.ToUpper().Contains(SanPham.ToUpper())).ToList();
            }
            ViewBag.SanPham = SanPham;

            lstprod = lstprod.OrderByDescending(s => s.ProductID).ToList();

            ViewBag.STT = pageNumber * pageSize - pageSize + 1;
            int count = lstprod.ToList().Count();
            ViewBag.TotalRow = count;
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Product/_grid.cshtml", lstprod.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));
            }
            return View(lstprod.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));
        }

        public List<Product> GetListProduct()
        {
            var list = new List<Product>();

            if(Session["listviewed"] != null)
            {
                list = Session["listviewed"] as List<Product>;
            }

            return list;
        }

        public void AddList(Product p)
        {
            var list = new List<Product>();

            if (Session["listviewed"] != null)
            {
                list = Session["listviewed"] as List<Product>;

                var x = list.FirstOrDefault(q => q.ProductID == p.ProductID);
                if(x == null)
                {
                    list.Add(p);
                }
            }
            else
            {
                list.Add(p);
            }   
            Session["listviewed"] = list;
        }

        public ActionResult Detail(int? id)
        {
            ProductDetailViewModel model = new ProductDetailViewModel();
            model.product = db.Products.Find(id);
            var cate = db.Categories.Find(model.product.CategoryID);
            model.CategoryName = cate.CategoryName;
            model.CategoryLink = "/san-pham/" + cate.SEOUrlRewrite + "-" + cate.CategoryID;
            model.listimage = db.ProductImages.Where(q => q.ProductID == id).Select(s => new ListImage { 
                ImageURL = s.URLImage,
                URLThumb = s.ImagesThumb
            }).ToList();
            model.relate = db.Products.Where(q => q.IsActive == true && q.ProductID != id && q.IsProduct == true && q.CategoryID == cate.CategoryID).ToList();
            model.upsell = db.Products.Where(q => q.IsActive == true && q.ProductID != id && q.IsProduct == true).ToList();

            ListImage l = new ListImage();
            l.URLThumb = model.product.ImagesThumb;
            l.ImageURL = model.product.Images;

            model.listimage.Add(l);

            AddList(model.product);

            return View(model);
        }

        public PartialViewResult GetQuickView(int? id)
        {
            QuickViewModel model = new QuickViewModel();

            model.listimage = db.ProductImages.Where(q => q.ProductID == id).Select(s => new ListImage
            {
                ImageURL = s.URLImage,
                URLThumb = s.ImagesThumb
            }).ToList();



            model.product = db.Products.Find(id);

            ListImage l = new ListImage();
            l.URLThumb = model.product.ImagesThumb;
            l.ImageURL = model.product.Images;

            model.listimage.Add(l);

            return PartialView("_quickview", model);
        }
    }
}