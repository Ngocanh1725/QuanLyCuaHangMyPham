using QuanLyCuaHangMyPham.DAL;
using System;
using System.Data;

namespace QuanLyCuaHangMyPham.BLL
{
    public class ChiTietDonHangBLL
    {
        private static ChiTietDonHangBLL instance;

        public static ChiTietDonHangBLL Instance
        {
            get { if (instance == null) instance = new ChiTietDonHangBLL(); return instance; }
            private set { instance = value; }
        }

        private ChiTietDonHangBLL() { }

        public DataTable GetListChiTietDonHang(string maDH)
        {
            return ChiTietDonHangDAL.Instance.GetListChiTietDonHang(maDH);
        }
    }
}
