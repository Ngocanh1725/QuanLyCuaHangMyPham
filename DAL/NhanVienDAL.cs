using QuanLyCuaHangMyPham.DTO;
using System;
using System.Data;

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
            // Lấy thông tin nhân viên cùng với mật khẩu từ bảng TaiKhoan
            string query = @"
                SELECT nv.MaNV, nv.TenNV, nv.SDT, nv.QueQuan, nv.Email, nv.TenTK, tk.MatKhau
                FROM NhanVien AS nv
                JOIN TaiKhoan AS tk ON nv.TenTK = tk.TenTK";
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

        public bool InsertNhanVien(NhanVienDTO nv)
        {
            string query = "INSERT INTO NhanVien (MaNV, TenNV, SDT, QueQuan, Email, TenTK) VALUES ( @MaNV , @TenNV , @SDT , @QueQuan , @Email , @TenTK )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { nv.MaNV, nv.TenNV, nv.SDT, nv.QueQuan, nv.Email, nv.TenTK });
            return result > 0;
        }

        public bool UpdateNhanVien(NhanVienDTO nv)
        {
            string query = "UPDATE NhanVien SET TenNV = @TenNV , SDT = @SDT , QueQuan = @QueQuan , Email = @Email WHERE MaNV = @MaNV";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { nv.TenNV, nv.SDT, nv.QueQuan, nv.Email, nv.MaNV });
            return result > 0;
        }

        public bool DeleteNhanVien(string maNV)
        {
            string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maNV });
            return result > 0;
        }

        public DataTable SearchNhanVien(string keyword)
        {
            string query = @"
                SELECT nv.MaNV, nv.TenNV, nv.SDT, nv.QueQuan, nv.Email, nv.TenTK, tk.MatKhau
                FROM NhanVien AS nv
                JOIN TaiKhoan AS tk ON nv.TenTK = tk.TenTK
                WHERE nv.TenNV LIKE @keyword OR nv.MaNV LIKE @keyword OR nv.Email LIKE @keyword OR nv.SDT LIKE @keyword";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { "%" + keyword + "%" });
        }
    }
}
