using QuanLyCuaHangMyPham.DTO;
using System;
using System.Data;

namespace QuanLyCuaHangMyPham.DAL
{
    public class NhaCungCapDAL
    {
        private static NhaCungCapDAL instance;

        public static NhaCungCapDAL Instance
        {
            get { if (instance == null) instance = new NhaCungCapDAL(); return instance; }
            private set { instance = value; }
        }

        private NhaCungCapDAL() { }

        // Lấy danh sách tất cả nhà cung cấp
        public DataTable GetListNhaCungCap()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM NhaCungCap");
        }

        // Lấy mã nhà cung cấp cuối cùng từ CSDL để tính toán mã tiếp theo
        public string GetLastMaNCC()
        {
            string query = "SELECT TOP 1 MaNCC FROM NhaCungCap ORDER BY MaNCC DESC";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result?.ToString();
        }

        // Thêm một nhà cung cấp mới vào CSDL
        public bool InsertNhaCungCap(NhaCungCapDTO ncc)
        {
            string query = "INSERT INTO NhaCungCap (MaNCC, TenNCC, Email, SDTLH) VALUES ( @MaNCC , @TenNCC , @Email , @SDTLH )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ncc.MaNCC, ncc.TenNCC, ncc.Email, ncc.SDTLH });
            return result > 0;
        }

        // Cập nhật thông tin một nhà cung cấp
        public bool UpdateNhaCungCap(NhaCungCapDTO ncc)
        {
            string query = "UPDATE NhaCungCap SET TenNCC = @TenNCC , Email = @Email , SDTLH = @SDTLH WHERE MaNCC = @MaNCC_Old";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ncc.TenNCC, ncc.Email, ncc.SDTLH, ncc.MaNCC });
            return result > 0;
        }

        // Xóa một nhà cung cấp
        public bool DeleteNhaCungCap(string maNCC)
        {
            // Kiểm tra xem nhà cung cấp có đang được liên kết với sản phẩm nào không
            string checkQuery = "SELECT COUNT(*) FROM SanPham WHERE MaNCC = @MaNCC";
            int count = (int)DataProvider.Instance.ExecuteScalar(checkQuery, new object[] { maNCC });
            if (count > 0)
            {
                return false; // Nếu có, không cho phép xóa
            }

            string deleteQuery = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC_Old";
            int result = DataProvider.Instance.ExecuteNonQuery(deleteQuery, new object[] { maNCC });
            return result > 0;
        }

        // Tìm kiếm nhà cung cấp
        public DataTable SearchNhaCungCap(string keyword)
        {
            string query = "SELECT * FROM NhaCungCap WHERE TenNCC LIKE @keyword OR MaNCC LIKE @keyword";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { "%" + keyword + "%" });
        }
    }
}
