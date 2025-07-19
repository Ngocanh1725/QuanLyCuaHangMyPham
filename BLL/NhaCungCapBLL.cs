using QuanLyCuaHangMyPham.DAL;
using QuanLyCuaHangMyPham.DTO;
using System;
using System.Data;

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

        public bool InsertNhaCungCap(string maNCC, string tenNCC, string email, string sdtlh)
        {
            NhaCungCap ncc = new NhaCungCap(maNCC, tenNCC, email, sdtlh);
            return NhaCungCapDAL.Instance.InsertNhaCungCap(ncc);
        }

        public bool UpdateNhaCungCap(string maNCC, string tenNCC, string email, string sdtlh)
        {
            NhaCungCap ncc = new NhaCungCap(maNCC, tenNCC, email, sdtlh);
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
