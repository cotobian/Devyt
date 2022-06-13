using System;
using Devyt.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Devyt.MVC.Controllers.Membership
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        DevytEntities db = new DevytEntities();
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User == null) return false;
            string controller = httpContext.Request.RequestContext.RouteData.GetRequiredString("controller");
            string action = httpContext.Request.RequestContext.RouteData.GetRequiredString("action");
            Roles = string.Join(",", db.Admin_GetPhanQuyenMethod(controller, action).ToArray());
            return Roles.Contains(httpContext.Session["Roles"].ToString());
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RedirectToRouteResult routeData = null;

            if (HttpContext.Current.User == null)
            {
                routeData = new RedirectToRouteResult
                    (new System.Web.Routing.RouteValueDictionary
                    (new
                    {
                        controller = "Account",
                        action = "Index",
                    }
                    ));
            }
            else
            {
                routeData = new RedirectToRouteResult
                (new System.Web.Routing.RouteValueDictionary
                 (new
                 {
                     controller = "Error",
                     action = "AccessDenied"
                 }
                 ));
            }

            filterContext.Result = routeData;
        }
    }
}