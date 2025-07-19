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

        /// <summary>
        /// Kiểm tra thông tin đăng nhập từ CSDL.
        /// </summary>
        /// <param name="userName">Tên đăng nhập.</param>
        /// <param name="passWord">Mật khẩu.</param>
        /// <returns>True nếu đăng nhập thành công, ngược lại là False.</returns>
        public bool Login(string userName, string passWord)
        {
            // Tránh SQL Injection bằng cách sử dụng tham số hóa
            string query = "SELECT * FROM TaiKhoan WHERE TenTK = @userName AND MatKhau = @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });
            return result.Rows.Count > 0;
        }

        /// <summary>
        /// Lấy thông tin tài khoản bằng tên đăng nhập.
        /// </summary>
        /// <param name="userName">Tên đăng nhập.</param>
        /// <returns>Đối tượng TaiKhoan.</returns>
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
    }
}
