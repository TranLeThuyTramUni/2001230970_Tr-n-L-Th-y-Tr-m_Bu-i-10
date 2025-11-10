using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhomAhoi_QLBanSach.Models;
namespace NhomAhoi_QLBanSach.Controllers
{
    public class NguoiDungController : Controller
    {
        //
        // GET: /NguoiDung/
        public ActionResult DangKy()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult DangKy(KhachHang kh, FormCollection f)
        //{
        //    var hoten = f["HotenKH"];
        //}
	}
}