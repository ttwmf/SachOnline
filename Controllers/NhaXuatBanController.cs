using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;
namespace SachOnline.Controllers
{
    public class NhaXuatBanController : Controller
    {
        // GET: NhaXuatBan
        SachOnlineDbContext data = new SachOnlineDbContext();
        public ActionResult Index()
        {
            var ListNhaXuatBan = from nxb in data.NHAXUATBANs select nxb;
            return View(ListNhaXuatBan);
        }
        public ActionResult Details()
        {
            int manxb = int.Parse(Request.QueryString["id"]);
            var ChiTietNhaXuatBan = from nxb in data.NHAXUATBANs where nxb.MaNXB == manxb select nxb;
            return View(ChiTietNhaXuatBan.Single());
        }
    }
}