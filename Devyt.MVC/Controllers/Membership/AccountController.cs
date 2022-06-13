using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using Devyt.Models.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace Devyt.MVC.Controllers.Membership
{
    public class AccountController : Controller
    {
        private Admin_TaiKhoanRepository _taiKhoan = new Admin_TaiKhoanRepository();
        private Admin_PhanQuyenRepository _phanQuyen = new Admin_PhanQuyenRepository();

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) return LogOut();
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Index(LoginViewModel model)
        {
            try
            {
                Admin_TaiKhoan nv = (await _taiKhoan.GetByAccount(model)).ResultObj;
                if (nv != null)
                {
                    Session.Add("Name", nv.HoTen);
                    Session.Add("Id", nv.Id);
                    Session.Add("Roles", _phanQuyen.GetById((int)nv.PhanQuyenId).ResultObj.TenPhanQuyen);
                    Session.Add("PhongBanID", nv.PhongBanId);
                    Session.Add("ChiNhanhId",await _taiKhoan.GetChiNhanhId((int)nv.PhongBanId));
                    FormsAuthentication.SetAuthCookie(nv.HoTen, true);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("LogOnError", "Tài khoản hoặc mật khẩu không đúng!.");
                    return View();
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("LogOnError", ex.Message);
                return View();
            }
        }

        [Authorize]
        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account", null);
        }
    }
}