﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace NoiThat.Utilities
{
    public static class WebConstants
    {
        public static string ImgSlideHomePage = ConfigurationManager.AppSettings["ImgSlideHomePage"];

        public static string DateFormatVI = "dd/MM/yyyy";
        public static string DatetimeFormatVI = "dd/MM/yyyy HH:mm";

        public static int CategoryProduct = 1;
        public static int CategoryCollection = 2;
        public static int CategoryNews = 3;
        public static int CategoryAboutUs = 4;

        public static int BlogNews = 1;
        public static int BlogCollection = 2;
        public static int BlogAboutUs = 4;
    }
}