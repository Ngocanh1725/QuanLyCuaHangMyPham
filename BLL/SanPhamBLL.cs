using QuanLyCuaHangMyPham.DAL;
using QuanLyCuaHangMyPham.DTO;
using System;
using System.Data;
using System.Text.RegularExpressions;

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

        public string GenerateNextMaSP()
        {
            string lastMaSP = SanPhamDAL.Instance.GetLastMaSP();
            if (string.IsNullOrEmpty(lastMaSP))
            {
                return "SP001";
            }

            Match match = Regex.Match(lastMaSP, @"(\d+)$");
            if (match.Success)
            {
                int number = int.Parse(match.Value);
                number++;
                return "SP" + number.ToString("D3");
            }

            return "SP001";
        }

        public DataTable GetListSanPham()
        {
            return SanPhamDAL.Instance.GetListSanPham();
        }

        public bool InsertSanPham(string maSP, string tenSP, string xuatXu, string maLoai, string maNCC, float donGia, byte[] hinhAnh)
        {
            SanPhamDTO sp = new SanPhamDTO(maSP, tenSP, xuatXu, maLoai, maNCC, donGia, hinhAnh);
            return SanPhamDAL.Instance.InsertSanPham(sp);
        }

        public bool UpdateSanPham(string maSP, string tenSP, string xuatXu, string maLoai, string maNCC, float donGia, byte[] hinhAnh)
        {
            SanPhamDTO sp = new SanPhamDTO(maSP, tenSP, xuatXu, maLoai, maNCC, donGia, hinhAnh);
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
