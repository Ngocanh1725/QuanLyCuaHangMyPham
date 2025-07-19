using QuanLyCuaHangMyPham.DAL;
using QuanLyCuaHangMyPham.DTO;
using System;
using System.Data;

namespace QuanLyCuaHangMyPham.BLL
{
    public class SanPhamBLL
    {
        private static SanPhamBLL instance;

        public static SanPhamBLL Instance
        {
            get { if (instance == null) instance = new SanPhamBLL(); return instance; }
            private set { instance = value; }
        }

        private SanPhamBLL() { }

        public DataTable GetListSanPham()
        {
            return SanPhamDAL.Instance.GetListSanPham();
        }

        public bool InsertSanPham(string maSP, string tenSP, string hangSP, string xuatXu, string theLoai, string maNCC)
        {
            SanPhamDTO sp = new SanPhamDTO(maSP, tenSP, hangSP, xuatXu, theLoai, maNCC);
            return SanPhamDAL.Instance.InsertSanPham(sp);
        }

        public bool UpdateSanPham(string maSP, string tenSP, string hangSP, string xuatXu, string theLoai, string maNCC)
        {
            SanPhamDTO sp = new SanPhamDTO(maSP, tenSP, hangSP, xuatXu, theLoai, maNCC);
            return SanPhamDAL.Instance.UpdateSanPham(sp);
        }

        public bool DeleteSanPham(string maSP)
        {
            return SanPhamDAL.Instance.DeleteSanPham(maSP);
        }

        public DataTable SearchSanPham(string keyword)
        {
            return SanPhamDAL.Instance.SearchSanPham(keyword);
        }
    }
}
