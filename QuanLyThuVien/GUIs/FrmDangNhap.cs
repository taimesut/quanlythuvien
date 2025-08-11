using LibraryDashboard;
using QuanLyThuVien.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.GUIs
{
    public partial class FrmDangNhap : Form
    {
        private NhanVienService _service;

        public FrmDangNhap()
        {
            InitializeComponent();

            // Khởi tạo màu sắc nút khi form load
            btnDangNhap.BackColor = Color.MediumSlateBlue;
            btnThoat.BackColor = Color.LightGray;

            _service = new NhanVienService();
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

            var user = _service.GetByUsername(username);

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

            // đăng nhập thành công
            Session.NhanVien = user;

            this.Hide();

            using (FrmDashBoard dashboard = new FrmDashBoard())
            {
                dashboard.ShowDialog();
            }

            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
