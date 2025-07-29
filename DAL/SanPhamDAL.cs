using QuanLyCuaHangMyPham.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangMyPham.DAL
{
    public class SanPhamDAL
    {
        private static SanPhamDAL instance;

        public static SanPhamDAL Instance
        {
            get { if (instance == null) instance = new SanPhamDAL(); return instance; }
            private set { instance = value; }
        }

        private SanPhamDAL() { }

        public string GetLastMaSP()
        {
            string query = "SELECT TOP 1 MaSP FROM SanPham ORDER BY MaSP DESC";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result?.ToString();
        }

        public DataTable GetListSanPham()
        {
            string query = @"
                SELECT sp.MaSP, sp.TenSP, ncc.TenNCC AS HangSP, sp.XuatXu, sp.MaNCC, sp.DonGia, sp.HinhAnh, lsp.MaLoai, lsp.TenLoai 
                FROM SanPham AS sp
                LEFT JOIN LoaiSanPham AS lsp ON sp.MaLoai = lsp.MaLoai
                LEFT JOIN NhaCungCap AS ncc ON sp.MaNCC = ncc.MaNCC";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool InsertSanPham(SanPhamDTO sp)
        {
            string query = "INSERT INTO SanPham (MaSP, TenSP, XuatXu, MaLoai, MaNCC, DonGia, HinhAnh) VALUES ( @MaSP , @TenSP , @XuatXu , @MaLoai , @MaNCC , @DonGia , @HinhAnh )";
            SqlParameter imageParam = new SqlParameter("@HinhAnh", SqlDbType.VarBinary, -1)
            {
                Value = (sp.HinhAnh != null) ? (object)sp.HinhAnh : DBNull.Value
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { sp.MaSP, sp.TenSP, sp.XuatXu, sp.MaLoai, sp.MaNCC, sp.DonGia }, new SqlParameter[] { imageParam });
            return result > 0;
        }

        public bool UpdateSanPham(SanPhamDTO sp)
        {
            string query = "UPDATE SanPham SET TenSP = @TenSP, XuatXu = @XuatXu, MaLoai = @MaLoai, MaNCC = @MaNCC, DonGia = @DonGia, HinhAnh = @HinhAnh WHERE MaSP = @MaSP_Old";
            SqlParameter imageParam = new SqlParameter("@HinhAnh", SqlDbType.VarBinary, -1)
            {
                Value = (sp.HinhAnh != null) ? (object)sp.HinhAnh : DBNull.Value
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { sp.TenSP, sp.XuatXu, sp.MaLoai, sp.MaNCC, sp.DonGia, sp.MaSP }, new SqlParameter[] { imageParam });
            return result > 0;
        }

        public bool DeleteSanPham(string maSP)
        {
            DataProvider.Instance.ExecuteNonQuery("DELETE FROM KhoHang WHERE MaSP = @MaSP", new object[] { maSP });
            DataProvider.Instance.ExecuteNonQuery("DELETE FROM ChiTietDonHang WHERE MaSP = @MaSP", new object[] { maSP });

            string query = "DELETE FROM SanPham WHERE MaSP = @MaSP_Old";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSP });
            return result > 0;
        }

        public DataTable SearchSanPham(string keyword)
        {
            string query = @"
                SELECT sp.MaSP, sp.TenSP, ncc.TenNCC AS HangSP, sp.XuatXu, sp.MaNCC, sp.DonGia, sp.HinhAnh, lsp.MaLoai, lsp.TenLoai 
                FROM SanPham AS sp 
                LEFT JOIN LoaiSanPham AS lsp ON sp.MaLoai = lsp.MaLoai
                LEFT JOIN NhaCungCap AS ncc ON sp.MaNCC = ncc.MaNCC
                WHERE sp.TenSP LIKE @keyword OR sp.MaSP LIKE @keyword OR ncc.TenNCC LIKE @keyword";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { "%" + keyword + "%" });
        }
    }
}
