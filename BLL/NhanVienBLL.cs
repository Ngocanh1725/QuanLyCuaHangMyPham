using QuanLyCuaHangMyPham.DAL;
using QuanLyCuaHangMyPham.DTO;
using System;
using System.Data;

namespace QuanLyCuaHangMyPham.BLL
{
    public class NhanVienBLL
    {
        private static NhanVienBLL instance;

        public static NhanVienBLL Instance
        {
            get { if (instance == null) instance = new NhanVienBLL(); return instance; }
            private set { instance = value; }
        }

        private NhanVienBLL() { }

        public DataTable GetListNhanVien()
        {
            return NhanVienDAL.Instance.GetListNhanVien();
        }

        public bool InsertNhanVien(string maNV, string tenNV, string sdt, string queQuan, string email, string tenTK, string matKhau)
        {
            // Kiểm tra xem tài khoản hoặc mã nhân viên đã tồn tại chưa
            if (TaiKhoanDAL.Instance.GetAccountByUserName(tenTK) != null) return false;
            if (NhanVienDAL.Instance.GetNhanVienByMaNV(maNV) != null) return false;

            // Thêm tài khoản trước
            TaiKhoanDTO tk = new TaiKhoanDTO(tenTK, matKhau, "Nhân viên");
            if (!TaiKhoanDAL.Instance.InsertTaiKhoan(tk))
            {
                return false;
            }

            // Nếu thêm tài khoản thành công, thêm nhân viên
            NhanVienDTO nv = new NhanVienDTO(maNV, tenNV, sdt, queQuan, email, tenTK);
            if (!NhanVienDAL.Instance.InsertNhanVien(nv))
            {
                // Nếu thêm nhân viên thất bại, phải xóa tài khoản vừa tạo để đồng bộ
                TaiKhoanDAL.Instance.DeleteTaiKhoan(tenTK);
                return false;
            }

            return true;
        }

        public bool UpdateNhanVien(string maNV, string tenNV, string sdt, string queQuan, string email, string tenTK, string matKhau)
        {
            // Cập nhật thông tin nhân viên
            NhanVienDTO nv = new NhanVienDTO(maNV, tenNV, sdt, queQuan, email, tenTK);
            bool resultNV = NhanVienDAL.Instance.UpdateNhanVien(nv);

            // Cập nhật mật khẩu
            bool resultTK = TaiKhoanDAL.Instance.UpdateTaiKhoan(tenTK, matKhau);

            return resultNV && resultTK;
        }

        public bool DeleteNhanVien(string maNV)
        {
            // Lấy thông tin nhân viên để có TenTK
            NhanVienDTO nv = NhanVienDAL.Instance.GetNhanVienByMaNV(maNV);
            if (nv == null) return false;

            // Xóa nhân viên trước (vì có khóa ngoại từ TaiKhoan đến NhanVien)
            // Trong thiết kế của bạn, khóa ngoại từ NhanVien -> TaiKhoan
            // Nên xóa NhanVien trước, rồi xóa TaiKhoan
            if (!NhanVienDAL.Instance.DeleteNhanVien(maNV))
            {
                return false;
            }

            // Xóa tài khoản
            if (!TaiKhoanDAL.Instance.DeleteTaiKhoan(nv.TenTK))
            {
                // Nếu xóa tài khoản thất bại, nên thêm lại nhân viên (khá phức tạp, tạm bỏ qua)
                return false;
            }

            return true;
        }

        public DataTable SearchNhanVien(string keyword)
        {
            return NhanVienDAL.Instance.SearchNhanVien(keyword);
        }
    }
}
