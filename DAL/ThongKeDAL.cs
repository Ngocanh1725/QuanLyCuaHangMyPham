using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DAL
{
    public class ThongKeDAL
    {
        private static ThongKeDAL instance;
        public static ThongKeDAL Instance
        {
            get { if (instance == null) instance = new ThongKeDAL(); return instance; }
            private set { instance = value; }
        }
        private ThongKeDAL() { }

        public DataTable GetThongKeDonHang(DateTime fromDate, DateTime toDate)
        {
            string query = @"
                SELECT 
                    dh.MaDH, 
                    dh.TenKH, 
                    dh.SDTKH,
                    dh.DiaChi,
                    dh.NgayMua, 
                    dh.MaNV,
                    nv.TenNV, 
                    SUM(ct.SoLuong * ct.GiaBan) AS TongTien
                FROM DonHang AS dh
                JOIN NhanVien AS nv ON dh.MaNV = nv.MaNV
                JOIN ChiTietDonHang AS ct ON dh.MaDH = ct.MaDH
                WHERE dh.NgayMua BETWEEN @fromDate AND @toDate
                GROUP BY dh.MaDH, dh.TenKH, dh.SDTKH, dh.DiaChi, dh.NgayMua, dh.MaNV, nv.TenNV
                ORDER BY dh.NgayMua DESC";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { fromDate, toDate });
        }

        public DataTable GetTopSanPham(DateTime fromDate, DateTime toDate)
        {
            string query = @"
                SELECT TOP 5
                    sp.TenSP, 
                    SUM(ct.SoLuong) AS SoLuongBan
                FROM ChiTietDonHang AS ct
                JOIN SanPham AS sp ON ct.MaSP = sp.MaSP
                JOIN DonHang AS dh ON ct.MaDH = dh.MaDH
                WHERE dh.NgayMua BETWEEN @fromDate AND @toDate
                GROUP BY sp.TenSP
                ORDER BY SoLuongBan DESC";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { fromDate, toDate });
        }

        // Tối ưu: Thêm phương thức lấy doanh thu theo tháng
        public DataTable GetDoanhThuTheoThang(int year)
        {
            string query = @"
                SELECT 
                    MONTH(dh.NgayMua) AS Thang, 
                    SUM(ct.SoLuong * ct.GiaBan) AS DoanhThu
                FROM DonHang AS dh
                JOIN ChiTietDonHang AS ct ON dh.MaDH = ct.MaDH
                WHERE YEAR(dh.NgayMua) = @year
                GROUP BY MONTH(dh.NgayMua)
                ORDER BY Thang ASC";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { year });
        }
    }
}
