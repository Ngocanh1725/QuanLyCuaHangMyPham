using QuanLyCuaHangMyPham.DAL;
using QuanLyCuaHangMyPham.DTO;
using System;
using System.Collections.Generic;

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

        public List<NhaCungCapDTO> GetListNhaCungCap()
        {
            return NhaCungCapDAL.Instance.GetListNhaCungCap();
        }
    }
}
