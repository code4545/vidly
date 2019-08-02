using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes(); //Using this we can directly include the following code in Controller/Action method.
            //We add new Custom Route before the existing Maproute which is below this code 
            //because the system checks from the most specific to most generic
            //This routing is outdated because this becomes messier when you have many routes and you have to change names in many places
            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new {controller="Movies",action="ByReleaseDate"},
            //   // new {year = @"\d{4}",month = @"\d{2}"}
            //   new { year = @"2018|2019", month = @"\d{2}" }
            //    );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
