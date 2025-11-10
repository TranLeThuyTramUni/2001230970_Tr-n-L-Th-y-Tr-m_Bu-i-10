using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2001230970_Trần_Lê_Thùy_Trâm_Buổi_10.Models
{
    public class GioHang
    {
        QlBanSachDataContext db = new QlBanSachDataContext();
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        public GioHang(int MaSach)
        {
            iMaSach = MaSach;
            Sach sach = db.Saches.Single(s => s.MaSach == iMaSach);
            sTenSach = sach.TenSach;
            sAnhBia = sach.AnhBia;
            dDonGia = double.Parse(sach.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}