using QuanLyCuaHangMyPham.DTO;
using System;
using System.Data;

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

        public DataTable GetListSanPham()
        {
            string query = "SELECT MaSP, TenSP, HangSP, XuatXu, TheLoai, MaNCC FROM SanPham";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool InsertSanPham(SanPhamDTO sp)
        {
            string query = "INSERT INTO SanPham (MaSP, TenSP, HangSP, XuatXu, TheLoai, MaNCC) VALUES ( @MaSP , @TenSP , @HangSP , @XuatXu , @TheLoai , @MaNCC )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { sp.MaSP, sp.TenSP, sp.HangSP, sp.XuatXu, sp.TheLoai, sp.MaNCC });
            return result > 0;
        }

        public bool UpdateSanPham(SanPhamDTO sp)
        {
            string query = "UPDATE SanPham SET TenSP = @TenSP , HangSP = @HangSP , XuatXu = @XuatXu , TheLoai = @TheLoai , MaNCC = @MaNCC WHERE MaSP = @MaSP_Old";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { sp.TenSP, sp.HangSP, sp.XuatXu, sp.TheLoai, sp.MaNCC, sp.MaSP });
            return result > 0;
        }

        public bool DeleteSanPham(string maSP)
        {
            // Trước khi xóa sản phẩm, cần xóa các tham chiếu ở bảng KhoHang và ChiTietDonHang
            DataProvider.Instance.ExecuteNonQuery("DELETE FROM KhoHang WHERE MaSP = @MaSP", new object[] { maSP });
            DataProvider.Instance.ExecuteNonQuery("DELETE FROM ChiTietDonHang WHERE MaSP = @MaSP", new object[] { maSP });

            string query = "DELETE FROM SanPham WHERE MaSP = @MaSP_Old";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSP });
            return result > 0;
        }

        public DataTable SearchSanPham(string keyword)
        {
            string query = "SELECT MaSP, TenSP, HangSP, XuatXu, TheLoai, MaNCC FROM SanPham WHERE TenSP LIKE @keyword OR MaSP LIKE @keyword";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { "%" + keyword + "%" });
        }
    }
}
