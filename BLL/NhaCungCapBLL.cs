using QuanLyCuaHangMyPham.DAL;
using QuanLyCuaHangMyPham.DTO;
using System;
using System.Data;
using System.Text.RegularExpressions; // Thư viện cần thiết để xử lý chuỗi

namespace QuanLyCuaHangMyPham.BLL
{
    public class NhaCungCapBLL
    {
        private static NhaCungCapBLL instance;

        public static NhaCungCapBLL Instance
        {
            get { if (instance == null) instance = new NhaCungCapBLL(); return instance; }
            private set { instance = value; }
        }

        private NhaCungCapBLL() { }

        public DataTable GetListNhaCungCap()
        {
            return NhaCungCapDAL.Instance.GetListNhaCungCap();
        }

        // Hàm tạo mã NCC tiếp theo
        public string GenerateNextMaNCC()
        {
            // 1. Lấy mã NCC cuối cùng từ DAL
            string lastMaNCC = NhaCungCapDAL.Instance.GetLastMaNCC();

            // 2. Nếu chưa có mã nào, bắt đầu từ NCC001
            if (string.IsNullOrEmpty(lastMaNCC))
            {
                return "NCC001";
            }

            // 3. Sử dụng Regex để tìm phần số ở cuối chuỗi (ví dụ: "NCC010" -> "010")
            Match match = Regex.Match(lastMaNCC, @"(\d+)$");
            if (match.Success)
            {
                // 4. Chuyển phần số thành kiểu int
                int number = int.Parse(match.Value);
                // 5. Tăng số lên 1
                number++;
                // 6. Định dạng lại thành chuỗi 3 chữ số và ghép với tiền tố "NCC"
                return "NCC" + number.ToString("D3");
            }

            // Trả về mã mặc định nếu có lỗi không mong muốn
            return "NCC001";
        }

        public bool InsertNhaCungCap(string maNCC, string tenNCC, string email, string sdtlh)
        {
            NhaCungCapDTO ncc = new NhaCungCapDTO(maNCC, tenNCC, email, sdtlh);
            return NhaCungCapDAL.Instance.InsertNhaCungCap(ncc);
        }

        public bool UpdateNhaCungCap(string maNCC, string tenNCC, string email, string sdtlh)
        {
            NhaCungCapDTO ncc = new NhaCungCapDTO(maNCC, tenNCC, email, sdtlh);
            return NhaCungCapDAL.Instance.UpdateNhaCungCap(ncc);
        }

        public bool DeleteNhaCungCap(string maNCC)
        {
            return NhaCungCapDAL.Instance.DeleteNhaCungCap(maNCC);
        }

        public DataTable SearchNhaCungCap(string keyword)
        {
            return NhaCungCapDAL.Instance.SearchNhaCungCap(keyword);
        }
    }
}
