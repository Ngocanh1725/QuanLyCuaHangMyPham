using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

// Đặt trong một namespace riêng để dễ quản lý
namespace QuanLyCuaHangMyPham.CustomControls
{
    public class RoundedButton : Button
    {
        // Fields
        private int borderRadius = 20;

        // Properties
        [Category("Custom Properties")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                this.Invalidate(); // Yêu cầu vẽ lại control
            }
        }

        // Constructor
        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        // Methods
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);

            // Chuyển đổi BorderRadius sang float để vẽ
            float floatBorderRadius = Convert.ToSingle(borderRadius);

            if (borderRadius > 2) // Nếu có bo góc
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, floatBorderRadius))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                {
                    // Thiết lập vùng hiển thị của button theo hình dạng bo tròn
                    this.Region = new Region(pathSurface);
                    // Vẽ đường viền để làm mịn các cạnh
                    pevent.Graphics.DrawPath(penSurface, pathSurface);
                }
            }
            else // Nếu không bo góc, vẽ hình chữ nhật bình thường
            {
                this.Region = new Region(rectSurface);
            }

            // Vẽ chữ lên trên button
            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font,
                this.ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
