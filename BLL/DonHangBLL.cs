// Đảm bảo các using directive này được khai báo ở đầu file
using QuanLyCuaHangMyPham.DAL; // Cần thiết để sử dụng KhoHangDAL, DataProvider, ...
using QuanLyCuaHangMyPham.DTO; // Cần thiết để sử dụng các lớp DTO
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; // Cần thiết cho SqlTransaction

namespace QuanLyCuaHangMyPham.BLL
{
    public class DonHangBLL
    {
        private static DonHangBLL instance;
        public static DonHangBLL Instance
        {
            get { if (instance == null) instance = new DonHangBLL(); return instance; }
            private set { instance = value; }
        }
        private DonHangBLL() { }

        public List<SanPhamKhoDTO> GetListSanPhamTrongKho()
        {
            List<SanPhamKhoDTO> list = new List<SanPhamKhoDTO>();
            // Lời gọi này yêu cầu using QuanLyCuaHangMyPham.DAL;
            DataTable data = KhoHangDAL.Instance.GetListSanPhamTrongKho();
            foreach (DataRow item in data.Rows)
            {
                if ((int)item["SoLuong"] > 0)
                {
                    list.Add(new SanPhamKhoDTO(item));
                }
            }
            return list;
        }

        public List<NhanVienDTO> GetListNhanVien()
        {
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            // Lời gọi này yêu cầu NhanVienBLL phải tồn tại và public
            DataTable dataTable = NhanVienBLL.Instance.GetListNhanVien();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new NhanVienDTO(row));
            }
            return list;
        }

        public bool CreateDonHang(DonHangDTO dh, List<ChiTietDonHangDTO> listChiTiet)
        {
            // Lời gọi này yêu cầu using QuanLyCuaHangMyPham.DAL;
            using (SqlConnection conn = new SqlConnection(DataProvider.Instance.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Thêm đơn hàng
                    string dhQuery = "INSERT INTO DonHang (MaDH, TenKH, SDTKH, DiaChi, NgayMua, MaNV) VALUES ( @MaDH , @TenKH , @SDTKH , @DiaChi , @NgayMua , @MaNV )";
                    SqlCommand dhCommand = new SqlCommand(dhQuery, conn, transaction);
                    dhCommand.Parameters.AddWithValue("@MaDH", dh.MaDH);
                    dhCommand.Parameters.AddWithValue("@TenKH", dh.TenKH);
                    dhCommand.Parameters.AddWithValue("@SDTKH", dh.SDTKH);
                    dhCommand.Parameters.AddWithValue("@DiaChi", dh.DiaChi);
                    dhCommand.Parameters.AddWithValue("@NgayMua", dh.NgayMua);
                    dhCommand.Parameters.AddWithValue("@MaNV", dh.MaNV);

                    if (dhCommand.ExecuteNonQuery() == 0)
                    {
                        transaction.Rollback();
                        return false;
                    }

                    // 2. Thêm chi tiết đơn hàng và cập nhật kho
                    foreach (var item in listChiTiet)
                    {
                        // 2.1. Thêm chi tiết
                        string ctdhQuery = "INSERT INTO ChiTietDonHang (MaDH, MaSP, SoLuong, GiaBan) VALUES ( @MaDH_ct , @MaSP_ct , @SoLuong_ct , @GiaBan_ct )";
                        SqlCommand ctdhCommand = new SqlCommand(ctdhQuery, conn, transaction);
                        ctdhCommand.Parameters.AddWithValue("@MaDH_ct", item.MaDH);
                        ctdhCommand.Parameters.AddWithValue("@MaSP_ct", item.MaSP);
                        ctdhCommand.Parameters.AddWithValue("@SoLuong_ct", item.SoLuong);
                        ctdhCommand.Parameters.AddWithValue("@GiaBan_ct", item.GiaBan);

                        if (ctdhCommand.ExecuteNonQuery() == 0)
                        {
                            transaction.Rollback();
                            return false;
                        }

                        // 2.2. Cập nhật kho
                        string khQuery = "UPDATE KhoHang SET SoLuong = SoLuong - @soLuongBan WHERE MaSP = @maSP";
                        SqlCommand khCommand = new SqlCommand(khQuery, conn, transaction);
                        khCommand.Parameters.AddWithValue("@soLuongBan", item.SoLuong);
                        khCommand.Parameters.AddWithValue("@maSP", item.MaSP);

                        if (khCommand.ExecuteNonQuery() == 0)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }

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
