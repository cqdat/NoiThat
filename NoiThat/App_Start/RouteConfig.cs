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


            routes.MapRoute(
             name: "search",
             url: "tim-kiem",
             defaults: new { controller = "search", action = "result", id = UrlParameter.Optional }
         );

            routes.MapRoute(
              name: "product",
              url: "san-pham",
              defaults: new { controller = "product", action = "index", id = UrlParameter.Optional }
          );
            //Bộ sưu tập
            routes.MapRoute(
              name: "Collections",
              url: "bo-suu-tap/{url}-{id}",
              defaults: new { controller = "Collections", action = "index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Collections2",
              url: "bo-suu-tap",
              defaults: new { controller = "Collections", action = "index", id = UrlParameter.Optional }
          );

            //Bộ sưu tập
            routes.MapRoute(
              name: "CollectionsDetail",
              url: "chi-tiet-bo-suu-tap/{url}-{id}",
              defaults: new { controller = "Collections", action = "Details", id = UrlParameter.Optional }
          );


            //create new route Tin Tức
            routes.MapRoute(
                name: "News",
                url: "tin-tuc",
                defaults: new { controller = "News", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "News6",
               url: "tin-tuc/{url}-{id}",
               defaults: new { controller = "News", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "dichvu",
              url: "dich-vu",
              defaults: new { controller = "News", action = "Service", id = UrlParameter.Optional }
          );

            routes.MapRoute(
               name: "News2",
               url: "dich-vu/{url}-{id}",
               defaults: new { controller = "News", action = "Service", id = UrlParameter.Optional }
           );


            routes.MapRoute(
              name: "News3",
              url: "chi-tiet-dich-vu/{url}-{id}",
              defaults: new { controller = "News", action = "Details", id = UrlParameter.Optional }
          );


            //create new route Tin tức details
            routes.MapRoute(
                name: "NewsDetails",
                url: "chi-tiet-tin-tuc/{url}-{id}",
                defaults: new { controller = "News", action = "Details", id = UrlParameter.Optional }
            );

            //create new route About Us
            routes.MapRoute(
                name: "ContactUs",
                url: "lien-he",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );
            //create new route About Us
            routes.MapRoute(
                name: "AboutUs",
                url: "{url}-{id}",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );

           

            routes.MapRoute(
               name: "product2",
               url: "san-pham/{url}-{id}",
               defaults: new { controller = "product", action = "list", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "product3",
              url: "chi-tiet-san-pham/{url}-{id}",
              defaults: new { controller = "product", action = "detail", id = UrlParameter.Optional }
          );

           


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );




            
        }
    }
}
