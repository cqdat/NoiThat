using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoiThat.Models.DataModels;
using NoiThat.Utilities;
using NoiThat.Models;
using System.Net;
using PagedList;
using System.Data.Entity;

namespace NoiThat.Controllers
{
    public class NewsController : Controller
    {
        private TanThoiEntities db = new TanThoiEntities();
        Helpers h = new Helpers();
        // GET: News
        //[ActionName("tin-tuc")]
        public ActionResult Index(int? id)
        {
            NewsViewModel model = new NewsViewModel();
            model.lstBlogsNewest= db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogNews && b.IsActive == true).OrderByDescending(c => c.LastModify).Take(6).ToList();
            model.lstServices = db.Categories.Where(c => c.Parent == 0 && c.IsActive == true && c.TypeCate == WebConstants.CategoryService).ToList();
            model.LeftPromote = db.Advertises.Where(a => a.IsActive == true && a.Location == WebConstants.PromoteLeft).ToList();

            model.category = db.Categories.Find(id);
            if (id > 0)
            {                
                model.Title = model.category.CategoryName;
                model.SEOTitle = model.category.SEOTitle;
                model.SEOKeywords = model.category.SEOKeywords;
                model.SEOMetadescription = model.category.SEOMetadescription;
            }
            else
            {
                model.Title = "Tin tức";
            }
            return View(model);
        }

        public ActionResult _PartialNewsLst(int? pageNumber, int? pageSize, int? categoryid)
        {
            
            if (pageSize == -1)
            {
                pageSize = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogNews && b.IsActive == true).ToList().Count;
            }
            ViewBag.PageSize = pageSize;

            var lstnews = new List<Blog>();

            if (categoryid > 0)
            {
                lstnews = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogNews && b.IsActive == true && b.CategoryID == categoryid).OrderByDescending(b => b.LastModify).ToList();
            }
            else
            {
                lstnews = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogNews && b.IsActive == true).OrderByDescending(b => b.LastModify).ToList();
            }
            

            lstnews = lstnews.OrderBy(s => s.LastModify).ToList();

            ViewBag.STT = pageNumber * pageSize - pageSize + 1;
            int count = lstnews.ToList().Count();
            ViewBag.TotalRow = count;
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/News/_PartialNewsLst.cshtml", lstnews.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));
            }
            return View(lstnews.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("NotFound", "Home");
            }
            var blog = db.Blogs.Find(id);
            blog.CountView = blog.CountView + 1;
            db.Entry(blog).State = EntityState.Modified;
            db.SaveChanges();

            NewsViewModel model = new NewsViewModel();
            model.blogdetail = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogNews && b.BlogID == id && b.IsActive == true).FirstOrDefault();
            model.lstBlogsNewest = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogNews && b.IsActive == true && b.BlogID != id).OrderByDescending(c => c.LastModify).Take(5).ToList();
            ViewBag.Title = model.blogdetail.SEOTitle;
            int parent = model.blogdetail.CategoryID.Value;
            model.category = db.Categories.Find(parent);

            //model.SEOTitle = blog.SEOTitle;
            //model.SEOKeywords = blog.SEOKeywords;
            //model.SEOMetadescription = blog.SEOMetadescription;

            if (model.category.TypeCate == 5)
            {
                model.Title = "Dịch Vụ";
                model.TitleUrl = "/dich-vu";
            }
            else
            {
                model.Title = "Tin Tức";
                model.TitleUrl = "/tin-tuc";
            }

            return View(model);
        }

        public ActionResult Service(int? id)
        {
            ServiceViewModel model = new ServiceViewModel();

            if(id != null)
            {
                model.HasID = true;
                var cate = db.Categories.Find(id);
                
                model.blogs = db.Blogs.Where(q => q.IsActive == true && q.CategoryID == id).ToList();

                model.SEOTitle = cate.SEOTitle;
                model.SEOKeywords = cate.SEOKeywords;
                model.SEOMetadescription = cate.SEOMetadescription;
            }
            else
            {
                model.HasID = false;
                model.SEOTitle = "Dịch Vụ";
                model.blogs = db.Blogs.Where(q => q.IsActive == true && q.Category.TypeCate == 5).ToList();
            }

            return View(model);
        }
    }
}