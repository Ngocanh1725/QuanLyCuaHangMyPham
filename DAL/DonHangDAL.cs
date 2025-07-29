using QuanLyCuaHangMyPham.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

        public string GetLastMaDH()
        {
            // Sửa lỗi: Chỉ tìm các mã có định dạng 'DH' theo sau là 3 chữ số để tránh lỗi tràn số
            // với các mã cũ có định dạng ngày giờ.
            string query = "SELECT TOP 1 MaDH FROM DonHang WHERE MaDH LIKE 'DH[0-9][0-9][0-9]' ORDER BY MaDH DESC";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result?.ToString();
        }

        public bool InsertDonHang(DonHangDTO dh)
        {
            string query = "INSERT INTO DonHang (MaDH, TenKH, SDTKH, DiaChi, NgayMua, MaNV) VALUES ( @MaDH , @TenKH , @SDTKH , @DiaChi , @NgayMua , @MaNV )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { dh.MaDH, dh.TenKH, dh.SDTKH, dh.DiaChi, dh.NgayMua, dh.MaNV });
            return result > 0;
        }

        public bool DeleteDonHang(string maDH)
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.Instance.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // Bước 1: Lấy danh sách chi tiết đơn hàng để hoàn trả số lượng
                    string getDetailsQuery = "SELECT MaSP, SoLuong FROM ChiTietDonHang WHERE MaDH = @MaDH_get";
                    SqlCommand getDetailsCmd = new SqlCommand(getDetailsQuery, conn, transaction);
                    getDetailsCmd.Parameters.AddWithValue("@MaDH_get", maDH);

                    List<Tuple<string, int>> productsToReturn = new List<Tuple<string, int>>();
                    using (SqlDataReader reader = getDetailsCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productsToReturn.Add(new Tuple<string, int>(reader["MaSP"].ToString(), (int)reader["SoLuong"]));
                        }
                    } // SqlDataReader is automatically closed here

                    // Bước 2: Hoàn trả số lượng sản phẩm vào kho
                    foreach (var product in productsToReturn)
                    {
                        string updateKhoQuery = "UPDATE KhoHang SET SoLuong = SoLuong + @SoLuong WHERE MaSP = @MaSP";
                        SqlCommand updateKhoCmd = new SqlCommand(updateKhoQuery, conn, transaction);
                        updateKhoCmd.Parameters.AddWithValue("@SoLuong", product.Item2);
                        updateKhoCmd.Parameters.AddWithValue("@MaSP", product.Item1);
                        updateKhoCmd.ExecuteNonQuery();
                    }

                    // Bước 3: Xóa các chi tiết đơn hàng
                    string deleteDetailsQuery = "DELETE FROM ChiTietDonHang WHERE MaDH = @MaDH_del_details";
                    SqlCommand deleteDetailsCmd = new SqlCommand(deleteDetailsQuery, conn, transaction);
                    deleteDetailsCmd.Parameters.AddWithValue("@MaDH_del_details", maDH);
                    deleteDetailsCmd.ExecuteNonQuery();

                    // Bước 4: Xóa đơn hàng
                    string deleteOrderQuery = "DELETE FROM DonHang WHERE MaDH = @MaDH_del_order";
                    SqlCommand deleteOrderCmd = new SqlCommand(deleteOrderQuery, conn, transaction);
                    deleteOrderCmd.Parameters.AddWithValue("@MaDH_del_order", maDH);
                    deleteOrderCmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
