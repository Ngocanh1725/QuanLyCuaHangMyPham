using QuanLyCuaHangMyPham.BLL;
using System;
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham
{
    public partial class FormKhoHang : Form
    {
        public FormKhoHang()
        {
            InitializeComponent();
        }

        private void FormKhoHang_Load(object sender, EventArgs e)
        {
            LoadKhoHangList();
        }

        void LoadKhoHangList()
        {
            dgvKhoHang.DataSource = KhoHangBLL.Instance.GetListSanPhamTrongKho();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            FormNhapHang f = new FormNhapHang();
            // Chỉ load lại grid nếu form Nhập hàng trả về kết quả OK
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadKhoHangList();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhoHang.SelectedRows.Count > 0)
            {
                string maSP = dgvKhoHang.SelectedRows[0].Cells["MaSP"].Value.ToString();
                string tenSP = dgvKhoHang.SelectedRows[0].Cells["TenSP"].Value.ToString();

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{tenSP}' ra khỏi kho không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (KhoHangBLL.Instance.DeleteFromKho(maSP))
                    {
                        MessageBox.Show("Xóa sản phẩm khỏi kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKhoHangList();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadKhoHangList();
        }
    }
}