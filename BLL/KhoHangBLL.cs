using QuanLyCuaHangMyPham.DAL;
using QuanLyCuaHangMyPham.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyCuaHangMyPham.BLL
{
    public class KhoHangBLL
    {
        private static KhoHangBLL instance;
        public static KhoHangBLL Instance
        {
            get { if (instance == null) instance = new KhoHangBLL(); return instance; }
            private set { instance = value; }
        }
        private KhoHangBLL() { }

        public DataTable GetListSanPhamTrongKho()
        {
            return KhoHangDAL.Instance.GetListSanPhamTrongKho();
        }

        public bool DeleteFromKho(string maSP)
        {
            return KhoHangDAL.Instance.DeleteFromKho(maSP);
        }

        public bool NhapHang(string maSP, int soLuong, DateTime ngayNhap)
        {
            if (soLuong <= 0) return false;
            return KhoHangDAL.Instance.NhapHang(maSP, soLuong, ngayNhap);
        }

        public DataTable GetAllSanPham()
        {
            // Lấy tất cả sản phẩm để có thể nhập hàng cho sản phẩm mới
            return SanPhamDAL.Instance.GetListSanPham();
        }
    }
}
