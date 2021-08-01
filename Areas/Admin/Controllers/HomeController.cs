using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;

namespace SachOnline.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        SachOnlineDbContext db = new SachOnlineDbContext();
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var sTenDN = collection["TenDN"];
            var sMatKhau = collection["MatKhau"];
            ViewBag.TenDN = "";
            if (String.IsNullOrEmpty(sTenDN))
            {
                ViewData["Err1"] = "Bạn chưa nhập tên đăng nhập";
                return View();
            }
            else if (String.IsNullOrEmpty(sMatKhau))
            {
                ViewData["Err2"] = "Phải nhập mật khẩu";
                return View();
            }
            else
            {
                Console.WriteLine("ok");
                ADMIN ad = db.ADMINs.SingleOrDefault(n => n.TenDN == sTenDN && n.MatKhau == sMatKhau);
                if (ad != null)
                {
                    ViewBag.ThongBao = "Chúc mừng đăng nhập thành công  ";
                    Session["Admin"] = ad;
                    return RedirectToAction("Index", "Sach");

                }
                else
                {
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không chính xác";
                    return View();
                }
            }

        }

    }
}
