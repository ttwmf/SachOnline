using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;
namespace SachOnline.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        SachOnlineDbContext db = new SachOnlineDbContext();
        public ActionResult Search(string strSearch)
        {
            ViewBag.Search = strSearch;
            if (!string.IsNullOrEmpty(strSearch))
            {
                bool check = strSearch.All(c => c >= '0' && c <= '9');
                int tmp = 0;
                if(check == true)
                {
                    tmp = int.Parse(strSearch);
                }
                //var kq = from s in db.SACHes where s.TenSach.Contains(strSearch) select s;
                //var kq = from s in db.SACHes where s.MaCD == tmp select s;
                //var kq = from s in db.SACHes where  s.SoLuongBan >= 5 && s.SoLuongBan <= 10 select s;
                //var kq = from s in db.SACHes where (s.MaCD == tmp || s.MaNXB == tmp || s.TenSach.Equals(strSearch))  select s;
                // var kq = from s in db.SACHes where s.SoLuongBan >= 5 && s.SoLuongBan <= 10 orderby s.SoLuongBan select s;
                //var kq = from s in db.SACHes where s.SoLuongBan >= 5 && s.SoLuongBan <= 10 orderby s.SoLuongBan descending select s;
                //var kq = db.SACHes.Where(s => s.TenSach.Contains(strSearch)).Select(s => s);
                //var kq = db.SACHes.Where(s => s.MaCD == tmp).Select(s => s);
                //var kq = db.SACHes.Where(s => s.SoLuongBan >= 5 && s.SoLuongBan <= 10);
                /*if (check == true)
                {
                    var kq = db.SACHes.Where(s => s.SoLuongBan ==tmp || s.MaCD == tmp || s.MaNXB == tmp || s.TenSach.Equals(strSearch) || s.MoTa.Contains(strSearch));
                    return View(kq);
                }
                else
                {
                    var kq = db.SACHes.Where(s => s.TenSach.Equals(strSearch) || s.MoTa.Contains(strSearch) );
                    return View(kq);
                }*/
                
                //var kq = db.SACHes.Where(s => s.SoLuongBan >= 5 && s.SoLuongBan <= 10).OrderBy(s => s.SoLuongBan);
                if(check == true)
                {
                    var kq = db.SACHes.Where(s => s.MaCD == tmp).OrderByDescending(s => s.SoLuongBan);
                    return View(kq);
                }

               
            }
            return View();
        }  
        public ActionResult Group()
        {
            var kq = from s in db.SACHes group s by s.MaCD ;
            return View(kq);
        }
        public ActionResult ThongKe()
        {
            var kq = (from s in db.SACHes
                      group s by s.MaCD into g
                      select new
                      {
                          a = g.Key.ToString(),
                          b = g.Count(),
                          c = g.Sum(n => n.SoLuongBan)
                      }).AsEnumerable().Select(x => new ReportInfo
                      {
                          Id = x.a,
                          Count = x.b,
                          Sum = x.c

                      }).ToList();
            var kq2 = (from s in db.SACHes
                      group s by s.MaCD into g
                      select new ReportInfo()
                      {
                          Id = g.Key.ToString(),
                          Count = g.Count(),
                          Sum = g.Sum(n => n.SoLuongBan)
                      });




            return View(kq);
        }

    }

}