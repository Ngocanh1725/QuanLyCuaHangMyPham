using QuanLyCuaHangMyPham.BLL;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging; // Thêm using cho ImageFormat
using System.IO;
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
            SetupDataGridView();
            LoadKhoHangList();
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        void SetupDataGridView()
        {
            dgvKhoHang.AutoGenerateColumns = false;
            dgvKhoHang.Columns.Clear();
            dgvKhoHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaSP", HeaderText = "Mã SP" });
            dgvKhoHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSP", HeaderText = "Tên Sản Phẩm" });
            dgvKhoHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "Số Lượng Tồn" });
            dgvKhoHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayNhap", HeaderText = "Ngày Nhập Cuối" });
            // Ẩn cột hình ảnh
            dgvKhoHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HinhAnh", Visible = false });
        }

        void LoadKhoHangList()
        {
            dgvKhoHang.DataSource = KhoHangBLL.Instance.GetListSanPhamTrongKho();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            FormNhapHang f = new FormNhapHang();
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

        private void dgvKhoHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhoHang.SelectedRows.Count > 0)
            {
                DataRowView drv = dgvKhoHang.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv != null)
                {
                    if (drv.Row["HinhAnh"] != DBNull.Value)
                    {
                        byte[] hinhAnhData = (byte[])drv.Row["HinhAnh"];
                        picHinhAnhSP.Image = ByteArrayToImage(hinhAnhData);
                    }
                    else
                    {
                        picHinhAnhSP.Image = null;
                    }
                }
            }
        }
    }
}
