using QuanLyCuaHangMyPham.BLL;
using System;
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham
{
    public partial class FormNhaCungCap : Form
    {
        public FormNhaCungCap()
        {
            InitializeComponent();
        }

        private void FormNhaCungCap_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadNhaCungCapList();
            AddNhaCungCapBinding();
        }
        void SetupDataGridView()
        {
            dgvNhaCungCap.AutoGenerateColumns = false;
            dgvNhaCungCap.Columns.Clear();
            dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaNCC", HeaderText = "Mã NCC" });
            dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenNCC", HeaderText = "Tên Nhà Cung Cấp" });
            dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email" });
            dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SDTLH", HeaderText = "SĐT Liên Hệ" });
        }


        void LoadNhaCungCapList()
        {
            // Xóa binding cũ để tránh lỗi
            txtMaNCC.DataBindings.Clear();
            txtTenNCC.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtSDT.DataBindings.Clear();

            dgvNhaCungCap.DataSource = NhaCungCapBLL.Instance.GetListNhaCungCap();

        
        }

        void AddNhaCungCapBinding()
        {
            txtMaNCC.DataBindings.Add(new Binding("Text", dgvNhaCungCap.DataSource, "MaNCC", true, DataSourceUpdateMode.Never));
            txtTenNCC.DataBindings.Add(new Binding("Text", dgvNhaCungCap.DataSource, "TenNCC", true, DataSourceUpdateMode.Never));
            txtEmail.DataBindings.Add(new Binding("Text", dgvNhaCungCap.DataSource, "Email", true, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("Text", dgvNhaCungCap.DataSource, "SDTLH", true, DataSourceUpdateMode.Never));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNCC.Text) || string.IsNullOrWhiteSpace(txtTenNCC.Text))
                {
                    MessageBox.Show("Mã và Tên Nhà cung cấp không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (NhaCungCapBLL.Instance.InsertNhaCungCap(txtMaNCC.Text, txtTenNCC.Text, txtEmail.Text, txtSDT.Text))
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhaCungCapList();
                }
                else
                {
                    MessageBox.Show("Thêm nhà cung cấp thất bại! Mã NCC có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (NhaCungCapBLL.Instance.UpdateNhaCungCap(txtMaNCC.Text, txtTenNCC.Text, txtEmail.Text, txtSDT.Text))
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhaCungCapList();
                }
                else
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa nhà cung cấp '{txtTenNCC.Text}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (NhaCungCapBLL.Instance.DeleteNhaCungCap(txtMaNCC.Text))
                    {
                        MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNhaCungCapList();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại! Nhà cung cấp này đang được liên kết với một hoặc nhiều sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvNhaCungCap.DataSource = NhaCungCapBLL.Instance.SearchNhaCungCap(txtTimKiem.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtTimKiem.Clear();
            LoadNhaCungCapList();
        }
    }
}