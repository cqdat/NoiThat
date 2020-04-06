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
                pageSize = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogNews).ToList().Count;
            }
            ViewBag.PageSize = pageSize;

            var lstnews = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogNews).ToList();

            lstnews = lstnews.OrderBy(s => s.Created).ToList();
            ViewBag.STT = pageNumber * pageSize - pageSize + 1;
            int count = lstnews.ToList().Count();
            ViewBag.TotalRow = count;
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/News/_PartialNewsLst.cshtml", lstnews.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));
            }
            return View(lstnews.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));
        }
    }
}