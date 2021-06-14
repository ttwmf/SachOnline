using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;

namespace SachOnline.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        SachOnlineDbContext data = new SachOnlineDbContext();
        public List<GioHang> LayGiohang()
        {
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if(listGioHang == null)
            {
                listGioHang = new List<GioHang>();
                Session["GioHang"] = listGioHang;
            }

            return listGioHang;
        }
        public  ActionResult ThemGioHang(int ms, string url)
        {
            List<GioHang> listGioHang = LayGiohang();
            GioHang sp = listGioHang.Find(n => n.iMaSach == ms);
            if(sp == null)
            {
                sp = new GioHang(ms);
                listGioHang.Add(sp);
            }
            else
            {
                sp.iSoLuong++;
            }
            return Redirect(url);
        }
        private int TongSoLuong()
        { 

            int iTongSoLuong = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if(listGioHang != null)
            {
                iTongSoLuong = listGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if(listGioHang != null)
            {
                dTongTien = listGioHang.Sum(n => n.dThanhTien);
            }
            return dTongTien;
        }
        public ActionResult GioHang()
        {
            List<GioHang> listGioHang = LayGiohang();
            if(listGioHang.Count == 0)
            {
                return RedirectToAction("Index", "SachOnline");
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(listGioHang);
        }
        public ActionResult PartialGioHang()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            return PartialView();
        }
        [HttpGet]
        public ActionResult DatHang()
        {
            if(Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }
            if(Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "SachOnline");
            }
            List<GioHang> lstGioHang = LayGiohang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }

        
    }
}