using QuanLyCuaHangMyPham.DTO;
using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DAL
{
    public class TaiKhoanDAL
    {
        private static TaiKhoanDAL instance;

        public static TaiKhoanDAL Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAL(); return instance; }
            private set { instance = value; }
        }

        private TaiKhoanDAL() { }

        public bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM TaiKhoan WHERE TenTK = @userName AND MatKhau = @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });
            return result.Rows.Count > 0;
        }

        public TaiKhoanDTO GetAccountByUserName(string userName)
        {
            string query = "SELECT * FROM TaiKhoan WHERE TenTK = @userName";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName });

            if (data.Rows.Count > 0)
            {
                return new TaiKhoanDTO(data.Rows[0]);
            }
            return null;
        }

        public bool InsertTaiKhoan(TaiKhoanDTO tk)
        {
            string query = "INSERT INTO TaiKhoan (TenTK, MatKhau, PhanQuyen) VALUES ( @TenTK , @MatKhau , @PhanQuyen )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tk.TenTK, tk.MatKhau, tk.PhanQuyen });
            return result > 0;
        }

        public bool UpdateTaiKhoan(string tenTK, string matKhau)
        {
            string query = "UPDATE TaiKhoan SET MatKhau = @MatKhau WHERE TenTK = @TenTK";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { matKhau, tenTK });
            return result > 0;
        }

        public bool DeleteTaiKhoan(string tenTK)
        {
            string query = "DELETE FROM TaiKhoan WHERE TenTK = @TenTK";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenTK });
            return result > 0;
        }
    }
}
