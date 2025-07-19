using QuanLyCuaHangMyPham.DTO;
using System;

namespace QuanLyCuaHangMyPham.DAL
{
    public class DonHangDAL
    {
        private static DonHangDAL instance;
        public static DonHangDAL Instance
        {
            get { if (instance == null) instance = new DonHangDAL(); return instance; }
            private set { instance = value; }
        }
        private DonHangDAL() { }

        public bool InsertDonHang(DonHangDTO dh)
        {
            string query = "INSERT INTO DonHang (MaDH, TenKH, SDTKH, DiaChi, NgayMua, MaNV) VALUES ( @MaDH , @TenKH , @SDTKH , @DiaChi , @NgayMua , @MaNV )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { dh.MaDH, dh.TenKH, dh.SDTKH, dh.DiaChi, dh.NgayMua, dh.MaNV });
            return result > 0;
        }
    }
}
