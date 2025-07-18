using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLyCuaHangMyPham.Models;

namespace QuanLyCuaHangMyPham.Database
{
    public class DBConnection
    {
        //Chuỗi kết nối
        private static readonly string connectionString = @"Server = ADMIN-PC; Database = QuanLyCuaHangMyPham; User Id = sa; Password =  12345678;";

        //Phương thức tĩnh để lấy kết nối
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        //Phương thức kiểm tra đăng nhập
        public TaiKhoan ValidateUser(string Account, string MatKhau)
        {
            TaiKhoan TK = null;
            //Sử dụng GetConnection() để lấy đối tượng SqlConnection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //Đảm bảo tên cột khớp với CSDL của bạn (ví dụ: Account, MatKhau, PhanQuyen)
                //và tham số (@Username, @Password) khớp với tên cột trong CSDL nếu cần.
                string query = "SELECT Account, MatKhau, PhanQuyen FROM TAIKHOAN WHERE Account = @AccountParam AND MatKhau = @PMatKhauParam";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AccountParam", Account);
                cmd.Parameters.AddWithValue("@MatKhauParam", MatKhau); // Nhắc nhở: Mật khẩu nên được băm và thêm "muối" để bảo mật tốt hơn

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TK = new TaiKhoan
                            {
                                //Đảm bảo tên cột trong reader khớp với tên cột trong CSDL
                                Account = reader["Account"].ToString(),
                                PhanQuyen = reader["PhanQuyen"].ToString(), //Lấy cả mật khẩu (chỉ để khớp với model, không nên sử dụng trực tiếp)
                                MatKhau = reader["MatKhau"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Ghi lại lỗi
                    System.Diagnostics.Debug.WriteLine("Lỗi cơ sở dữ liệu trong quá trình đăng nhập: " + ex.Message);
                    //Có thể ném lại lỗi hoặc xử lý xụ thể hơn tuỳ theo yêu cầu
                }

            }
            return TK;
        }

        // Phương thức lấy danh sách sản phẩm (có tìm kiếm)
        public List<Models.SanPham> GetProduct(string searchTerm = "")
        {
            var products = new List<Models.SanPham>();
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT MaSP, MaNCC, TenSP, HangSP, XuatXu, TheLoai, GiaBan FROM SANPHAM";
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " WHERE TenSP LIKE @SearchTerm OR HangSP LIKE @SearchTerm OR TheLoai LIKE @SearchTerm";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                }
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Models.SanPham(
                            
                                reader["MaSP"].ToString(),
                                reader["MaNCC"].ToString(),
                                reader["TenSP"].ToString(),
                                reader["HangSP"].ToString(),
                                reader["XuatXu"].ToString(),
                                reader["TheLoai"].ToString(),
                                Convert.ToSingle(reader["GiaBan"])
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi CSDL GetProduct: " + ex.Message);
                }
            }
            return products;
        }
        // Phương thức thêm sản phẩm
        public bool AddProduct(Models.SanPham product)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "INSERT INTO SANPHAM (TenSP, HangSP, XuatXu, TheLoai, GiaBan) VALUES (@TenSP, @HangSP, @XuatXu, @TheLoai, @GiaBan)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", product.MaSP);
                cmd.Parameters.AddWithValue("@MaNCC", product.MaNCC);
                cmd.Parameters.AddWithValue("@TenSP", product.TenSP);
                cmd.Parameters.AddWithValue("@HangSP", product.HangSP);
                cmd.Parameters.AddWithValue("@XuatXu", product.XuatXu);
                cmd.Parameters.AddWithValue("@TheLoai", product.TheLoai);
                cmd.Parameters.AddWithValue("@GiaBan", product.GiaBan);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi CSDL AddProduct: " + ex.Message);
                    return false;
                }
            }
        }
        // Phương thức cập nhật sản phẩm
        public bool UpdateProduct(Models.SanPham product)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "UPDATE SANPHAM SET MaNCC = @MaNCC, TenSP = @TenSP, HangSP = @HangSP, XuatXu = @XuatXu, TheLoai = @TheLoai, GiaBan = @GiaBan WHERE MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", product.MaSP);
                cmd.Parameters.AddWithValue("@MaNCC", product.MaNCC);
                cmd.Parameters.AddWithValue("@TenSP", product.TenSP);
                cmd.Parameters.AddWithValue("@HangSP", product.HangSP);
                cmd.Parameters.AddWithValue("@XuatXu", product.XuatXu);
                cmd.Parameters.AddWithValue("@TheLoai", product.TheLoai);
                cmd.Parameters.AddWithValue("@GiaBan", product.GiaBan);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi CSDL UpdateProduct: " + ex.Message);
                    return false;
                }
            }
        }
        // Phương thức xóa sản phẩm
        public bool DeleteProduct(string MaSP)
        {
            using (SqlConnection conn = GetConnection())
            {
                // Lưu ý: Cần kiểm tra xem sản phẩm có trong hóa đơn nào không trước khi xóa
                string query = "DELETE FROM SANPHAM WHERE MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", MaSP);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi CSDL DeleteProduct: " + ex.Message);
                    return false;
                }
            }
        }
        // --- Các Phương thức Quản lý Đơn hàng ---

        // Phương thức thêm một đơn hàng mới 
        public bool AddDonHang(DonHang donHang)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"INSERT INTO DonHang (MaDH, TenKH, SDTKH, Diachi, NgayMua, MaNV, TongTien)
                                 VALUES (@MaDH, @TenKH, @SDTKH, @Diachi, @NgayMua, @MaNV, @TongTien);";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDH", donHang.MaDH);
                cmd.Parameters.AddWithValue("@TenKH", donHang.TenKH);
                cmd.Parameters.AddWithValue("@SDTKH", donHang.SDTKH);
                cmd.Parameters.AddWithValue("@Diachi", donHang.Diachi);
                cmd.Parameters.AddWithValue("@NgayMua", donHang.NgayMua);
                cmd.Parameters.AddWithValue("@MaNV", donHang.MaNV);
                cmd.Parameters.AddWithValue("@TongTien", donHang.TongTien);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi CSDL AddDonHang: " + ex.Message);
                    return false;
                }
            }
        }

        // Phương thức thêm các chi tiết đơn hàng (MACTDH không cần truyền, ThanhTien và GiaBan là float)
        public bool AddChiTietDonHang(ChiTietDonHang chiTiet)
        {
            using (SqlConnection conn = GetConnection())
            {
                // MACTDH sẽ được CSDL tự động tăng (IDENTITY), không cần truyền vào câu INSERT
                string query = @"INSERT INTO ChiTietDonHang (MaDH, MaSP, SoLuong, ThanhTien, GiaBan)
                                 VALUES (@MaDH, @MaSP, @SoLuong, @ThanhTien, @GiaBan);";
                SqlCommand cmd = new SqlCommand(query, conn);
                // cmd.Parameters.AddWithValue("@MACTDH", chiTiet.MACTDH); // KHÔNG truyền MACTDH nếu nó là IDENTITY
                cmd.Parameters.AddWithValue("@MaDH", chiTiet.MaDH);
                cmd.Parameters.AddWithValue("@MaSP", chiTiet.MaSP);
                cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                cmd.Parameters.AddWithValue("@ThanhTien", chiTiet.ThanhTien); // Tham số là float
                cmd.Parameters.AddWithValue("@GiaBan", chiTiet.GiaBan);       // Tham số là float

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi CSDL AddChiTietDonHang: " + ex.Message);
                    return false;
                }
            }
        }

        // Phương thức lấy tất cả đơn hàng (TongTien là float)
        public List<DonHang> GetAllDonHangs()
        {
            List<DonHang> donHangs = new List<DonHang>();
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT MaDH, TenKH, SDTKH, Diachi, NgayMua, MaNV, TongTien FROM DonHang";
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            donHangs.Add(new DonHang
                            {
                                MaDH = reader["MaDH"].ToString(),
                                TenKH = reader["TenKH"].ToString(),
                                SDTKH = reader["SDTKH"].ToString(),
                                Diachi = reader["Diachi"].ToString(),
                                NgayMua = Convert.ToDateTime(reader["NgayMua"]),
                                MaNV = reader["MaNV"].ToString(),
                                TongTien = Convert.ToSingle(reader["TongTien"]) // Chuyển sang float
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi CSDL GetAllDonHangs: " + ex.Message);
                }
            }
            return donHangs;
        }

        // Phương thức lấy chi tiết đơn hàng theo MaDH (MACTDH là int, ThanhTien, GiaBan là float)
        public List<ChiTietDonHang> GetChiTietDonHangByMaDH(string maDH)
        {
            List<ChiTietDonHang> chiTiets = new List<ChiTietDonHang>();
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT MACTDH, MaDH, MaSP, SoLuong, ThanhTien, GiaBan FROM ChiTietDonHang WHERE MaDH = @MaDH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDH", maDH);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            chiTiets.Add(new ChiTietDonHang
                            {
                                MACTDH = Convert.ToInt32(reader["MACTDH"]), // Chuyển sang int
                                MaDH = reader["MaDH"].ToString(),
                                MaSP = reader["MaSP"].ToString(),
                                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                ThanhTien = Convert.ToSingle(reader["ThanhTien"]), // Chuyển sang float
                                GiaBan = Convert.ToSingle(reader["GiaBan"])         // Chuyển sang float
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi CSDL GetChiTietDonHangByMaDH: " + ex.Message);
                }
            }
            return chiTiets;
        }

        // Phương thức cập nhật đơn hàng (TongTien là float)
        public bool UpdateDonHang(DonHang donHang)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"UPDATE DonHang SET TenKH = @TenKH, SDTKH = @SDTKH, Diachi = @Diachi,
                                 NgayMua = @NgayMua, MaNV = @MaNV, TongTien = @TongTien
                                 WHERE MaDH = @MaDH;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDH", donHang.MaDH);
                cmd.Parameters.AddWithValue("@TenKH", donHang.TenKH);
                cmd.Parameters.AddWithValue("@SDTKH", donHang.SDTKH);
                cmd.Parameters.AddWithValue("@Diachi", donHang.Diachi);
                cmd.Parameters.AddWithValue("@NgayMua", donHang.NgayMua);
                cmd.Parameters.AddWithValue("@MaNV", donHang.MaNV);
                cmd.Parameters.AddWithValue("@TongTien", donHang.TongTien); // Tham số là float

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi CSDL UpdateDonHang: " + ex.Message);
                    return false;
                }
            }
        }

        // Các phương thức xóa giữ nguyên như trước, vì chúng chỉ dựa vào MaDH hoặc MaSP
        public void DeleteChiTietDonHangByMaDH(string maDH)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "DELETE FROM ChiTietDonHang WHERE MaDH = @MaDH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDH", maDH);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi CSDL DeleteChiTietDonHangByMaDH: " + ex.Message);
                }
            }
        }

        public bool DeleteDonHang(string maDH)
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    SqlCommand cmdDeleteChiTiet = new SqlCommand("DELETE FROM ChiTietDonHang WHERE MaDH = @MaDH", conn, transaction);
                    cmdDeleteChiTiet.Parameters.AddWithValue("@MaDH", maDH);
                    cmdDeleteChiTiet.ExecuteNonQuery();

                    SqlCommand cmdDeleteDonHang = new SqlCommand("DELETE FROM DonHang WHERE MaDH = @MaDH", conn, transaction);
                    cmdDeleteDonHang.Parameters.AddWithValue("@MaDH", maDH);

                    int rowsAffected = cmdDeleteDonHang.ExecuteNonQuery();
                    transaction.Commit();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    System.Diagnostics.Debug.WriteLine("Lỗi CSDL DeleteDonHang: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
