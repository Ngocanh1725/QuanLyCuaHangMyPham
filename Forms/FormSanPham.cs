
using QuanLyCuaHangMyPham.BLL;
using QuanLyCuaHangMyPham.DTO;
using System;
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham
{
    public partial class FormSanPham : Form
    {
        public FormSanPham()
        {
            InitializeComponent();
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            LoadSanPhamList();
            LoadNhaCungCapComboBox();
            AddSanPhamBinding();
        }

        void LoadSanPhamList()
        {
            dgvSanPham.DataSource = SanPhamBLL.Instance.GetListSanPham();
        }

        void LoadNhaCungCapComboBox()
        {
            cbbNhaCungCap.DataSource = NhaCungCapBLL.Instance.GetListNhaCungCap();
            cbbNhaCungCap.DisplayMember = "TenNCC";
            cbbNhaCungCap.ValueMember = "MaNCC";
        }

        void AddSanPhamBinding()
        {
            txtMaSP.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "MaSP", true, DataSourceUpdateMode.Never));
            txtTenSP.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "TenSP", true, DataSourceUpdateMode.Never));
            txtHangSP.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "HangSP", true, DataSourceUpdateMode.Never));
            txtXuatXu.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "XuatXu", true, DataSourceUpdateMode.Never));
            txtTheLoai.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "TheLoai", true, DataSourceUpdateMode.Never));
            cbbNhaCungCap.DataBindings.Add(new Binding("SelectedValue", dgvSanPham.DataSource, "MaNCC", true, DataSourceUpdateMode.Never));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maSP = txtMaSP.Text;
                string tenSP = txtTenSP.Text;
                string hangSP = txtHangSP.Text;
                string xuatXu = txtXuatXu.Text;
                string theLoai = txtTheLoai.Text;
                string maNCC = cbbNhaCungCap.SelectedValue.ToString();

                if (string.IsNullOrWhiteSpace(maSP) || string.IsNullOrWhiteSpace(tenSP))
                {
                    MessageBox.Show("Mã và Tên sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (SanPhamBLL.Instance.InsertSanPham(maSP, tenSP, hangSP, xuatXu, theLoai, maNCC))
                {
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSanPhamList();
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại! Mã sản phẩm có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string maSP = txtMaSP.Text;
                string tenSP = txtTenSP.Text;
                string hangSP = txtHangSP.Text;
                string xuatXu = txtXuatXu.Text;
                string theLoai = txtTheLoai.Text;
                string maNCC = cbbNhaCungCap.SelectedValue.ToString();

                if (SanPhamBLL.Instance.UpdateSanPham(maSP, tenSP, hangSP, xuatXu, theLoai, maNCC))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSanPhamList();
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string maSP = txtMaSP.Text;

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{maSP}' không? Hành động này không thể hoàn tác.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (SanPhamBLL.Instance.DeleteSanPham(maSP))
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSanPhamList();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string keyword = txtTimKiem.Text;
            dgvSanPham.DataSource = SanPhamBLL.Instance.SearchSanPham(keyword);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadSanPhamList();
            txtTimKiem.Clear();
        }
    }
