using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham.Models
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string MaNCC { get; set; }
        public string TenSP { get; set; }
        public string HangSP { get; set; }
        public string XuatXu { get; set; }
        public string TheLoai {  get; set; }
        public float GiaBan {  get; set; } 

        public SanPham(string maSP, string maNCC, string tenSP, string hangSP, string xuatXu, string theLoai, float giaBan)
        {
            MaSP = maSP;
            MaNCC = maNCC;
            TenSP = tenSP;
            HangSP = hangSP;
            XuatXu = xuatXu;
            TheLoai = theLoai;
            GiaBan = giaBan;
        }
    }
}
