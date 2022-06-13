using System.Web.Mvc;

namespace Devyt.MVC.Areas.VanTai
{
    public class VanTaiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "VanTai";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "VanTai_default",
                "VanTai/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}