using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace mcga_api
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            //routes.MapRoute(
            //    name: "echouser",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "account", action = "echouser", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute("DefaultApiWithId", "{controller}/{id}", new { id = RouteParameter.Optional }, new { id = @"\d+" });
            //routes.MapRoute("DefaultApiWithAction", "{controller}/{action}");
            //routes.MapRoute("DefaultApiGet", "{controller}", new { action = "Get" }, new { httpMethod = new HttpMethodConstraint("Get") });
            //routes.MapRoute("DefaultApiPost", "{controller}", new { action = "Post" }, new { httpMethod = new HttpMethodConstraint("Post") });

//            context.Routes.MapHttpRoute(
//       name: "GetAllCeremonies",
//       routeTemplate: "api/{controller}",
//       defaults: new { action = "GetCeremonies" }
//);

//            context.Routes.MapHttpRoute(
//                   name: "GetSingleCeremony",
//                   routeTemplate: "api/{controller}/{id}",
//                   defaults: new { action = "GetCeremony", id = UrlParameter.Optional }
//            );

        }
    }
}
