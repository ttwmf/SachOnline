using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;
using PagedList;
using PagedList.Mvc;

namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        // GET: SachOnline
        SachOnlineDbContext data = new SachOnlineDbContext();
        public ActionResult Index(int ? page)
        {
            int iSize = 6;
            int iPageNum = (page ?? 1);
            var listSachMoi = data.SACHes.OrderByDescending(n => n.NgayCapNhat).ToList();
            return View(listSachMoi.ToPagedList(iPageNum, iSize));
        }

        public ActionResult LogoutLogin()
        {
            return PartialView();
        }

        public ActionResult SachTheoChuDe(int iMaCD, int? page)
        {
            ViewBag.MaCD = iMaCD;
            int iSize = 2;
            int iPageNum = (page ?? 1);
            var sach = from s in data.SACHes where s.MaCD == iMaCD select s;
            sach = sach.OrderBy(s => s.MaSach);
            return View(sach.ToPagedList(iPageNum, iSize));
        }

        public ActionResult SachTheoNXB(int idNXB, int ? page)
        {
            ViewBag.MaNXB = idNXB;
            int iSize = 2;
            int iPageNum = (page ?? 1);
            var ListSachTheoNXB = from sach in data.SACHes where idNXB == sach.MaNXB select sach;
            ListSachTheoNXB = ListSachTheoNXB.OrderBy(s => s.MaSach);
            return View(ListSachTheoNXB.ToPagedList(iPageNum, iSize));
        }
        public ActionResult ChiTietSach(int MaSach)
        {
            var ChiTietSach = from sach in data.SACHes where MaSach == sach.MaSach select sach;
            return View(ChiTietSach.Single());
        }
        public ActionResult ChuDePartial()
        {
            var ListChuDe = from cd in data.CHUDEs select cd;
            return PartialView(ListChuDe);
        }
        public ActionResult NavPartial()
        {
            ViewBag.TongSoLuong = 0;
            return PartialView();
        }
        public ActionResult SliderPartial()
        {
            return PartialView();
        }
        public ActionResult NhaXuatBanPartial()
        {
            var ListNXB = from nxb in data.NHAXUATBANs select nxb;
            return PartialView(ListNXB);
        }
        public ActionResult SachBanNhieuPartial()
        {
            var ListSachBanNhieu = LaySachBanNhieu(6);
            return PartialView(ListSachBanNhieu);
        }

        private List<SACH> LaySachBanNhieu(int soluong)
        {
            return data.SACHes.OrderBy(n => n.SoLuongBan).Take(6).ToList();
        }

        



    }
}