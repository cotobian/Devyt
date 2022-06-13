using System.Web.Mvc;

namespace Devyt.MVC.Areas.NhapXuat
{
    public class NhapXuatAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NhapXuat";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NhapXuat_default",
                "NhapXuat/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}