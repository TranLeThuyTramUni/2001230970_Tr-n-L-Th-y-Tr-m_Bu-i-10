using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhomAhoi_QLBanSach.Models;
namespace NhomAhoi_QLBanSach.Controllers
{
    public class NhaXuatBanController : Controller
    {
        //
        // GET: /NhaXuatBan/
        QlBanSachDataContext db = new QlBanSachDataContext();
        public ActionResult NhaXBPartial()
        {
            var ListNhaXB = db.NhaXuatBans.Take(7).OrderBy(xb => xb.TenNXB).ToList();
            return View(ListNhaXB);
        }
        public ActionResult SachTheoNXB(int Manxb)
        {
            var ListSachNXB = db.Saches.Where(s => s.MaNXB == Manxb).ToList();
            if (ListSachNXB.Count() == 0)
            {
                ViewBag.TB = "Không có sách của nhà xuất bản này!";
            }
            return View(ListSachNXB);
        }
	}
}