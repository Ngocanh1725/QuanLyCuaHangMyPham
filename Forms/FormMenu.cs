using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham
{
    public partial class FormMenu : Form
    {
        private string phanQuyen;
        private string tenDangNhap;
        private Button currentButton; // Lưu trữ button đang được chọn
        private Form activeForm; // Lưu trữ form con đang hiển thị

        public FormMenu(string phanQuyen, string tenDangNhap)
        {
            InitializeComponent();
            this.phanQuyen = phanQuyen;
            this.tenDangNhap = tenDangNhap;
        }

        // Phương thức để thay đổi màu của button được chọn
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    // Tắt màu của button cũ
                    DisableButton();
                    // Thiết lập màu cho button mới
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(255, 105, 180); // DeepPink
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        // Phương thức để trả lại màu mặc định cho button
        private void DisableButton()
        {
            foreach (Control previousBtn in pnlMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(255, 182, 193); // LightPink
                    previousBtn.ForeColor = Color.Black;
                    previousBtn.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        // Phương thức để mở một form con trong panel chính
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlBody.Controls.Add(childForm);
            this.pnlBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        // Sự kiện load form
        private void FormMenu_Load(object sender, EventArgs e)
        {
            lblUsername.Text = tenDangNhap;
            lblRole.Text = phanQuyen;

            // Phân quyền: Chỉ Admin mới thấy mục Nhân viên và Thống kê
            if (phanQuyen != "Admin")
            {
                btnNhanVien.Visible = false;
                btnThongKe.Visible = false;
            }
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormSanPham(), sender);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhaCC(), sender);
        }

        private void btnTaoDonHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDonHang(), sender);
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormKhoHang(), sender);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhanVien(), sender);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormThongKe(), sender);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Sẽ kích hoạt sự kiện FormClosed và hiển thị lại FormLogin
            }
            else
            {
                DisableButton(); // Bỏ highlight nút đăng xuất nếu người dùng chọn "No"
            }
        }
    }
}
