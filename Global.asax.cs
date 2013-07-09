using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace HMSAPI
{
    public class Global : System.Web.HttpApplication
    {
        public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");

                base.OnActionExecuting(filterContext);
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {

            RouteTable.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{UID}",
              defaults: new { UID = System.Web.Http.RouteParameter.Optional }
              );

            //----JSON
            //GlobalConfiguration.Configuration.Formatters.Insert(0, new JsonpMediaTypeFormatter());
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            GlobalConfiguration.Configuration.Formatters.Insert(0, new JsonpFormatter());
            //var config = GlobalConfiguration.Configuration;
            //config.Formatters.Insert(0, new JsonpMediaTypeFormatter());

           
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}