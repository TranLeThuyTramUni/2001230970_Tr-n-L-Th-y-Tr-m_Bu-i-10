using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001230970_Trần_Lê_Thùy_Trâm_Buổi_10.Models;

namespace _2001230970_Trần_Lê_Thùy_Trâm_Buổi_10.Controllers
{
    public class ChuDeController : Controller
    {
        //
        // GET: /ChuDe/
        QlBanSachDataContext db = new QlBanSachDataContext();
        public ActionResult ChuDePartial()
        {
            var ListChuDe = db.ChuDes.Take(7).OrderBy(cd => cd.TenChuDe).ToList();
            return View(ListChuDe);
        }
        public ActionResult SachTheoCD(int MaCD)
        {
            var ListSachCD = db.Saches.Where(s => s.MaChuDe == MaCD).ToList();
            if(ListSachCD.Count() == 0)
            {
                ViewBag.TB = "Không có sách thuộc chủ đề này!";
            }
            return View(ListSachCD);
        }
	}
}