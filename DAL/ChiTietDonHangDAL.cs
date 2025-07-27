using QuanLyCuaHangMyPham.DTO;
using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DAL
{
    public class ChiTietDonHangDAL
    {
        private static ChiTietDonHangDAL instance;
        public static ChiTietDonHangDAL Instance
        {
            get { if (instance == null) instance = new ChiTietDonHangDAL(); return instance; }
            private set { instance = value; }
        }
        private ChiTietDonHangDAL() { }

        public bool InsertChiTietDonHang(ChiTietDonHangDTO ctdh)
        {
            string query = "INSERT INTO ChiTietDonHang (MaDH, MaSP, SoLuong, GiaBan) VALUES ( @MaDH , @MaSP , @SoLuong , @GiaBan )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ctdh.MaDH, ctdh.MaSP, ctdh.SoLuong, ctdh.GiaBan });
            return result > 0;
        }

        public DataTable GetListChiTietDonHang(string maDH)
        {
            string query = @"
                SELECT 
                    ct.MaSP,
                    sp.TenSP,
                    ct.SoLuong,
                    ct.GiaBan,
                    (ct.SoLuong * ct.GiaBan) AS ThanhTien
                FROM ChiTietDonHang AS ct
                JOIN SanPham AS sp ON ct.MaSP = sp.MaSP
                WHERE ct.MaDH = @MaDH";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { maDH });
        }
    }
}
