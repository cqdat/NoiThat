﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoiThat.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int? id)
        {
            ViewBag.ID = id;
            return View();
        }

        public ActionResult Detail(int? id)
        {
            return View();
        }
    }
}