﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Haber.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
name: "Default2",
url: "home/{slug}",

defaults: new { controller = "Home", action = "Details" },
namespaces: new[] { "Haber.Web.Controllers" }
);


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Haber.Web.Controllers" }
            );
        }
    }
}
