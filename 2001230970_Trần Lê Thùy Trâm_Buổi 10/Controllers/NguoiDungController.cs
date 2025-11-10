using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001230970_Trần_Lê_Thùy_Trâm_Buổi_10.Models;
namespace _2001230970_Trần_Lê_Thùy_Trâm_Buổi_10.Controllers
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