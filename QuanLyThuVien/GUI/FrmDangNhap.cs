using LibraryDashboard;
using QuanLyThuVien.BUSINESS;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class FrmDangNhap : Form
    {
        private readonly NhanVien_BUS bus = new NhanVien_BUS();

        public FrmDangNhap()
        {
            InitializeComponent();

            // Khởi tạo màu sắc nút khi form load
            btnDangNhap.BackColor = Color.MediumSlateBlue;
            btnThoat.BackColor = Color.LightGray;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên tài khoản và Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = bus.LayNguoiDungTheoId(username);

            if (user == null)
            {
                MessageBox.Show("Tên tài khoản không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user.MatKhau != password)
            {
                MessageBox.Show("Mật khẩu không chính xác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Đăng nhập thành công
            //MessageBox.Show($"Chào mừng {user.TenTaiKhoan}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Ẩn form đăng nhập
            this.Hide();

            // Mở dashboard (mở non-modal để có thể đóng dashboard và quay lại đăng nhập nếu muốn)
            using (FrmDashBoard dashboard = new FrmDashBoard())
            {
                dashboard.ShowDialog();
            }

            // Đóng form đăng nhập sau khi dashboard đóng
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDangNhap_Resize(object sender, EventArgs e)
        {
            // Luôn căn giữa 2 nút btnDangNhap và btnThoat theo chiều ngang khi form thay đổi kích thước
            int totalButtonsWidth = btnDangNhap.Width + btnThoat.Width + 40; // 40 là khoảng cách giữa 2 nút
            int startX = (this.ClientSize.Width - totalButtonsWidth) / 2;
            int y = btnDangNhap.Location.Y;

            btnDangNhap.Location = new Point(startX, y);
            btnThoat.Location = new Point(startX + btnDangNhap.Width + 40, y);
        }
    }
}
