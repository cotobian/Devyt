using Devyt.MVC.Controllers.Membership;
using System.Web.Mvc;

namespace Devyt.MVC.Controllers
{
    [CustomAuthorize]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}