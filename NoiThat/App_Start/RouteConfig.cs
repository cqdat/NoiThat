using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NoiThat
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //create new route About Us
            routes.MapRoute(
                name: "News",
                url: "tin-tuc/{url}-{id}",
                defaults: new { controller = "Index", action = "News", id = UrlParameter.Optional }
            );
            //create new route About Us
            routes.MapRoute(
                name: "AboutUs",
                url: "{url}-{id}",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );

            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
