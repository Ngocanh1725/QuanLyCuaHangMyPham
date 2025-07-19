using QuanLyCuaHangMyPham.BLL;
using System;
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham
{
    public partial class FormNhapHang : Form
    {
        public FormNhapHang()
        {
            InitializeComponent();
            LoadSanPhamComboBox();
        }

        void LoadSanPhamComboBox()
        {
            cbbSanPham.DataSource = KhoHangBLL.Instance.GetAllSanPham();
            cbbSanPham.DisplayMember = "TenSP";
            cbbSanPham.ValueMember = "MaSP";
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            if (cbbSanPham.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSP = cbbSanPham.SelectedValue.ToString();
            int soLuong = (int)numSoLuong.Value;
            DateTime ngayNhap = dtpNgayNhap.Value;

            if (KhoHangBLL.Instance.NhapHang(maSP, soLuong, ngayNhap))
            {
                MessageBox.Show("Nhập hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Báo cho form cha biết để load lại dữ liệu
                this.Close();
            }
            else
            {
                MessageBox.Show("Nhập hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}