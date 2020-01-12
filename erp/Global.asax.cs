using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace erp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();

        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);
        //}
       
        public partial class Sessions
        {
            public static int UserId { get; set;}
            public static int InstituteId { get; set; }
            //public static int UserId
            //{
            //    get { return GetFromSession<int>("id"); }
            //    set { SetInSession("id", value); }
            //}            
            //public static int InstituteId
            //{
            //    get { return GetFromSession<int>("ins"); }
            //    set { SetInSession("ins", value); }
            //}
            //public static int CurrentSessionId
            //{
            //    get { return GetFromSession<int>("SessionId"); }
            //    set { SetInSession("SessionId", value); }
            //}
            //public static object Temp
            //{
            //    get { return GetFromSession("temp"); }
            //    set { SetInSession("temp", value); }
            //}

            //static object GetFromSession(string key)
            //{
            //    return HttpContext.Current.Session[key];
            //}
            //static T GetFromSession<T>(string key)
            //{
            //    //key = "29";
            //    return (T)HttpContext.Current.Session[key];
            //}
            //static void SetInSession(string key, object value)
            //{
            //    HttpContext.Current.Session[key] = value;
            //}
        }
    }
}
