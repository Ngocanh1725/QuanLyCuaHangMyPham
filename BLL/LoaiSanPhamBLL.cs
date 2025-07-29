using QuanLyCuaHangMyPham.DAL;
using System;
using System.Data;

namespace QuanLyCuaHangMyPham.BLL
{
    public class LoaiSanPhamBLL
    {
        private static LoaiSanPhamBLL instance;

        public static LoaiSanPhamBLL Instance
        {
            get { if (instance == null) instance = new LoaiSanPhamBLL(); return instance; }
            private set { instance = value; }
        }

        private LoaiSanPhamBLL() { }

        public DataTable GetListLoaiSanPham()
        {
            return LoaiSanPhamDAL.Instance.GetListLoaiSanPham();
        }
    }
}