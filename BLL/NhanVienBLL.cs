using QuanLyCuaHangMyPham.DAL;
using QuanLyCuaHangMyPham.DTO;
using System;
using System.Data;

namespace QuanLyCuaHangMyPham.BLL
{
    public class NhanVienBLL
    {
        private static NhanVienBLL instance;

        public static NhanVienBLL Instance
        {
            get { if (instance == null) instance = new NhanVienBLL(); return instance; }
            private set { instance = value; }
        }

        private NhanVienBLL() { }

        public DataTable GetListNhanVien()
        {
            return NhanVienDAL.Instance.GetListNhanVien();
        }

        public bool InsertNhanVien(string maNV, string tenNV, string sdt, string queQuan, string email, string tenTK, string matKhau, string phanQuyen)
        {
            if (TaiKhoanDAL.Instance.GetAccountByUserName(tenTK) != null) return false;
            if (NhanVienDAL.Instance.GetNhanVienByMaNV(maNV) != null) return false;

            TaiKhoanDTO tk = new TaiKhoanDTO(tenTK, matKhau, phanQuyen);
            NhanVienDTO nv = new NhanVienDTO(maNV, tenNV, sdt, queQuan, email, tenTK);

            return NhanVienDAL.Instance.InsertNhanVienWithAccount(nv, tk);
        }

        public bool UpdateNhanVien(string maNV, string tenNV, string sdt, string queQuan, string email, string tenTK, string matKhau, string phanQuyen)
        {
            NhanVienDTO nv = new NhanVienDTO(maNV, tenNV, sdt, queQuan, email, tenTK);
            return NhanVienDAL.Instance.UpdateNhanVienAndAccount(nv, matKhau, phanQuyen);
        }

        public bool DeleteNhanVien(string maNV)
        {
            return NhanVienDAL.Instance.DeleteNhanVienAndAccount(maNV);
        }

        public DataTable SearchNhanVien(string keyword)
        {
            return NhanVienDAL.Instance.SearchNhanVien(keyword);
        }
    }
}
