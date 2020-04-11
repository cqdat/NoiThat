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

namespace NoiThat.Controllers
{
    public class NewsController : Controller
    {
        private TanThoiEntities db = new TanThoiEntities();
        Helpers h = new Helpers();
        // GET: News
        //[ActionName("tin-tuc")]
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult _PartialNewsLst(int? pageNumber, int? pageSize)
        {
            
            if (pageSize == -1)
            {
                pageSize = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogNews && b.IsActive == true).ToList().Count;
            }
            ViewBag.PageSize = pageSize;

            var lstnews = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogNews && b.IsActive == true).ToList();

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

            NewsViewModel model = new NewsViewModel();
            model.blogdetail = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogNews && b.BlogID == id && b.IsActive == true).FirstOrDefault();
            model.lstBlogsNewest = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogNews && b.IsActive == true && b.BlogID != id).OrderByDescending(c => c.LastModify).ToList();
            ViewBag.Title = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs && b.BlogID == 3 && b.IsActive == true).FirstOrDefault().BlogName;
            return View(model);
        }
    }
}