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

        public DataTable GetListNhaCungCap()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM NhaCungCap");
        }

        public bool InsertNhaCungCap(NhaCungCap ncc)
        {
            string query = "INSERT INTO NhaCungCap (MaNCC, TenNCC, Email, SDTLH) VALUES ( @MaNCC , @TenNCC , @Email , @SDTLH )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ncc.MaNCC, ncc.TenNCC, ncc.Email, ncc.SDTLH });
            return result > 0;
        }

        public bool UpdateNhaCungCap(NhaCungCap ncc)
        {
            string query = "UPDATE NhaCungCap SET TenNCC = @TenNCC , Email = @Email , SDTLH = @SDTLH WHERE MaNCC = @MaNCC_Old";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ncc.TenNCC, ncc.Email, ncc.SDTLH, ncc.MaNCC });
            return result > 0;
        }

        public bool DeleteNhaCungCap(string maNCC)
        {
            // Cần kiểm tra khóa ngoại trước khi xóa
            string checkQuery = "SELECT COUNT(*) FROM SanPham WHERE MaNCC = @MaNCC";
            int count = (int)DataProvider.Instance.ExecuteScalar(checkQuery, new object[] { maNCC });
            if (count > 0)
            {
                // Nếu nhà cung cấp này đã được liên kết với sản phẩm, không cho phép xóa
                return false;
            }

            string deleteQuery = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC_Old";
            int result = DataProvider.Instance.ExecuteNonQuery(deleteQuery, new object[] { maNCC });
            return result > 0;
        }

        public DataTable SearchNhaCungCap(string keyword)
        {
            string query = "SELECT * FROM NhaCungCap WHERE TenNCC LIKE @keyword OR MaNCC LIKE @keyword";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { "%" + keyword + "%" });
        }
    }
}
