using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001230970_Trần_Lê_Thùy_Trâm_Buổi_10.Models;
namespace _2001230970_Trần_Lê_Thùy_Trâm_Buổi_10.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        QlBanSachDataContext db = new QlBanSachDataContext();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int ms, string strURL)
        {
            List<GioHang> lstGiohang = LayGioHang();
            GioHang SanPham = lstGiohang.Find(sp => sp.iMaSach == ms);
            if (SanPham == null)
            {
                SanPham = new GioHang(ms);
                lstGiohang.Add(SanPham);
                return Redirect(strURL);
            }
            else
            {
                SanPham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tsl += lstGioHang.Sum(sp => sp.iSoLuong);
            }
            return tsl;
        }
        private double TongThanhTien()
        {
            double ttt = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                ttt += lstGioHang.Sum(sp => sp.dThanhTien);
            }
            return ttt;
        }
        public ActionResult GioHang()
        {
            if(Session["GioHang"] == null)
            {
                return RedirectToAction("SachPartial", "Sach");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View(lstGioHang);
        }
        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return PartialView();
        }
        public ActionResult XoaGioHang(int MaSP)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.Single(s => s.iMaSach == MaSP);
            if(sp != null)
            {
                lstGioHang.RemoveAll(s => s.iMaSach == MaSP);
                return RedirectToAction("GioHang", "GioHang");
            }
            if(lstGioHang.Count == 0)
            {
                return RedirectToAction("SachPartial", "Sach");
            }
            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult XoaGioHang_All()
        {
            List<GioHang> lstGioHang = LayGioHang();
            lstGioHang.Clear();
            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult TangSL(int MaSP)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.Single(s => s.iMaSach == MaSP);
            if (sp != null)
            {
                sp.iSoLuong++;
            }
            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult GiamSL(int MaSP)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.Single(s => s.iMaSach == MaSP);
            if (sp != null)
            {
                if (sp.iSoLuong > 1)
                {
                    sp.iSoLuong--;
                }
            }
            return RedirectToAction("GioHang", "GioHang");
        }
	}
}