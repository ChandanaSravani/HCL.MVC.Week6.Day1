using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HCL.MVC.Week6.Day1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");//trace file

            routes.MapMvcAttributeRoutes();
            //routes.MapRoute(
            //    name:"own",
            //    url:/*"{controller}/{action}/{id}/{name}"*/  "ByOwnStatement/{id}/{Name}", defaults:new{controller="Home",action="checking"}
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
