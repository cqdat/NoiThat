using NoiThat.Models;
using NoiThat.Models.DataModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoiThat.Controllers
{
    public class CollectionsController : Controller
    {
        TanThoiEntities db = new TanThoiEntities();
        // GET: Collections
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _PartialIndex(int? pageNumber, int? pageSize)
        {
            
            pageNumber = pageNumber ?? 1;
            pageSize = pageSize ?? 10;

            if (pageSize == -1)
            {
                pageSize = db.Products.Where(p => p.IsProduct == false).ToList().Count;
            }
            ViewBag.PageSize = pageSize;

            var lstprod = db.Products.Where(p => p.IsProduct == false).ToList();


            lstprod = lstprod.OrderBy(s => s.Created).ToList();
            ViewBag.STT = pageNumber * pageSize - pageSize + 1;
            int count = lstprod.ToList().Count();
            ViewBag.TotalRow = count;
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Collections/_partialIndex.cshtml", lstprod.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));
            }
            return View(lstprod.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("NotFound", "Home");
            }
            CollectionsViewModel model = new CollectionsViewModel();
            model.detail = db.Products.Where(p => p.IsActive == true && p.IsProduct == false && p.ProductID == id).FirstOrDefault();
            model.lstImages = db.ProductImages.Where(i=>i.ProductID == id).ToList();
            var cateid = db.Products.Where(p => p.IsActive == true && p.IsProduct == false && p.ProductID == id).FirstOrDefault().CategoryID;
            model.lstCollection1 = db.Products.Where(p => p.IsActive == true && p.IsProduct == false && p.CategoryID == cateid && p.ProductID != id).OrderByDescending(p=>p.ProductID).Take(4).ToList();


            return View(model);
        }
    }
}