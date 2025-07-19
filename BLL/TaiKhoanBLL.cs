using QuanLyCuaHangMyPham.DAL;
using QuanLyCuaHangMyPham.DTO;
using System;

namespace QuanLyCuaHangMyPham.BLL
{
    public class TaiKhoanBLL
    {
        private static TaiKhoanBLL instance;

        public static TaiKhoanBLL Instance
        {
            get { if (instance == null) instance = new TaiKhoanBLL(); return instance; }
            private set { instance = value; }
        }

        private TaiKhoanBLL() { }

        public bool Login(string userName, string passWord)
        {
            // Có thể thêm các logic kiểm tra dữ liệu đầu vào ở đây
            // Ví dụ: kiểm tra userName, passWord có rỗng không, có hợp lệ không...
            return TaiKhoanDAL.Instance.Login(userName, passWord);
        }

        public TaiKhoanDTO GetAccountByUserName(string userName)
        {
            return TaiKhoanDAL.Instance.GetAccountByUserName(userName);
        }
    }
}
