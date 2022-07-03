using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LAZABDU.Models;

namespace LAZABDU
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start()
        {
            Session["IsLogin"] = true;
            Session["CustomerUsername"] = null;
            Session["CustomerFullrname"] = null;
            Session["NumberOfTimesIPLogin"] = 0;
            Session["ShoppingCart"] = new ShoppingCart();
            Session["CountProductsCart"] = 0;
        }
    }
}
