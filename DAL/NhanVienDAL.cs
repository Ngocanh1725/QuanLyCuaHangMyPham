using QuanLyCuaHangMyPham.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangMyPham.DAL
{
    public class NhanVienDAL
    {
        private static NhanVienDAL instance;

        public static NhanVienDAL Instance
        {
            get { if (instance == null) instance = new NhanVienDAL(); return instance; }
            private set { instance = value; }
        }

        private NhanVienDAL() { }

        public DataTable GetListNhanVien()
        {
            string query = @"
                SELECT nv.MaNV, nv.TenNV, nv.SDT, nv.QueQuan, nv.Email, nv.TenTK, tk.MatKhau, tk.PhanQuyen
                FROM NhanVien AS nv
                LEFT JOIN TaiKhoan AS tk ON nv.TenTK = tk.TenTK";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public NhanVienDTO GetNhanVienByMaNV(string maNV)
        {
            string query = "SELECT * FROM NhanVien WHERE MaNV = @maNV";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maNV });
            if (data.Rows.Count > 0)
            {
                return new NhanVienDTO(data.Rows[0]);
            }
            return null;
        }

        public bool InsertNhanVienWithAccount(NhanVienDTO nv, TaiKhoanDTO tk)
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.Instance.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // Thêm tài khoản
                    string tkQuery = "INSERT INTO TaiKhoan (TenTK, MatKhau, PhanQuyen) VALUES (@TenTK, @MatKhau, @PhanQuyen)";
                    SqlCommand tkCommand = new SqlCommand(tkQuery, conn, transaction);
                    tkCommand.Parameters.AddWithValue("@TenTK", tk.TenTK);
                    tkCommand.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
                    tkCommand.Parameters.AddWithValue("@PhanQuyen", tk.PhanQuyen);
                    tkCommand.ExecuteNonQuery();

                    // Thêm nhân viên
                    string nvQuery = "INSERT INTO NhanVien (MaNV, TenNV, SDT, QueQuan, Email, TenTK) VALUES (@MaNV, @TenNV, @SDT, @QueQuan, @Email, @TenTK_nv)";
                    SqlCommand nvCommand = new SqlCommand(nvQuery, conn, transaction);
                    nvCommand.Parameters.AddWithValue("@MaNV", nv.MaNV);
                    nvCommand.Parameters.AddWithValue("@TenNV", nv.TenNV);
                    nvCommand.Parameters.AddWithValue("@SDT", nv.SDT);
                    nvCommand.Parameters.AddWithValue("@QueQuan", nv.QueQuan);
                    nvCommand.Parameters.AddWithValue("@Email", nv.Email);
                    nvCommand.Parameters.AddWithValue("@TenTK_nv", nv.TenTK);
                    nvCommand.ExecuteNonQuery();

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

        public bool UpdateNhanVienAndAccount(NhanVienDTO nv, string newMatKhau, string phanQuyen)
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.Instance.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // Cập nhật nhân viên
                    string nvQuery = "UPDATE NhanVien SET TenNV = @TenNV, SDT = @SDT, QueQuan = @QueQuan, Email = @Email WHERE MaNV = @MaNV";
                    SqlCommand nvCommand = new SqlCommand(nvQuery, conn, transaction);
                    nvCommand.Parameters.AddWithValue("@TenNV", nv.TenNV);
                    nvCommand.Parameters.AddWithValue("@SDT", nv.SDT);
                    nvCommand.Parameters.AddWithValue("@QueQuan", nv.QueQuan);
                    nvCommand.Parameters.AddWithValue("@Email", nv.Email);
                    nvCommand.Parameters.AddWithValue("@MaNV", nv.MaNV);
                    nvCommand.ExecuteNonQuery();

                    // Cập nhật tài khoản (cả mật khẩu và phân quyền)
                    string tkQuery = "UPDATE TaiKhoan SET MatKhau = @MatKhau, PhanQuyen = @PhanQuyen WHERE TenTK = @TenTK";
                    SqlCommand tkCommand = new SqlCommand(tkQuery, conn, transaction);
                    tkCommand.Parameters.AddWithValue("@MatKhau", newMatKhau);
                    tkCommand.Parameters.AddWithValue("@PhanQuyen", phanQuyen);
                    tkCommand.Parameters.AddWithValue("@TenTK", nv.TenTK);
                    tkCommand.ExecuteNonQuery();

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

        public bool DeleteNhanVienAndAccount(string maNV)
        {
            NhanVienDTO nv = GetNhanVienByMaNV(maNV);
            if (nv == null) return false;

            using (SqlConnection conn = new SqlConnection(DataProvider.Instance.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // Xóa nhân viên
                    string nvQuery = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                    SqlCommand nvCommand = new SqlCommand(nvQuery, conn, transaction);
                    nvCommand.Parameters.AddWithValue("@MaNV", maNV);
                    nvCommand.ExecuteNonQuery();

                    // Xóa tài khoản
                    string tkQuery = "DELETE FROM TaiKhoan WHERE TenTK = @TenTK";
                    SqlCommand tkCommand = new SqlCommand(tkQuery, conn, transaction);
                    tkCommand.Parameters.AddWithValue("@TenTK", nv.TenTK);
                    tkCommand.ExecuteNonQuery();

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

        public DataTable SearchNhanVien(string keyword)
        {
            string query = @"
                SELECT nv.MaNV, nv.TenNV, nv.SDT, nv.QueQuan, nv.Email, nv.TenTK, tk.MatKhau, tk.PhanQuyen
                FROM NhanVien AS nv
                JOIN TaiKhoan AS tk ON nv.TenTK = tk.TenTK
                WHERE nv.TenNV LIKE @keyword OR nv.MaNV LIKE @keyword OR nv.Email LIKE @keyword OR nv.SDT LIKE @keyword";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { "%" + keyword + "%" });
        }
    }
}
