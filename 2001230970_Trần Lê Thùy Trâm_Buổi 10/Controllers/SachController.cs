using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhomAhoi_QLBanSach.Models;
namespace NhomAhoi_QLBanSach.Controllers
{
    public class SachController : Controller
    {
        //
        // GET: /Sach/
        QlBanSachDataContext db = new QlBanSachDataContext();
        public ActionResult SachPartial()
        {
            var ListSach = db.Saches.ToList();
            return View(ListSach);
        }
        public ActionResult XemChiTiet(int ms)
        {
            Sach sach = db.Saches.FirstOrDefault(s => s.MaSach == ms);
            if(sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }
        public ActionResult TimKiem(string Ten)
        {
            List<Sach> dss = db.Saches.Where(sp => sp.TenSach.Contains(Ten)).ToList();

            return View("SachPartial", dss);
        }
	}
}