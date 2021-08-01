using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;


namespace SachOnline.Areas.Admin.Controllers
{
    public class ChuDeController : Controller
    {
        SachOnlineDbContext db = new SachOnlineDbContext();
        // GET: Admin/ChuDe
        public ActionResult Index()
        {
            var lst = from s in db.SACHes
                       join cd in db.CHUDEs on s.MaCD equals cd.MaCD
                       group s by new { cd.MaCD, cd.TenChuDe } into g
                       select new ReportInfo
                       {
                           Name = g.Key.TenChuDe,
                           Count = g.Count(),
                           Sum = g.Sum(n => n.SoLuongBan)
                       };
            return View(lst);
        }
    }
}