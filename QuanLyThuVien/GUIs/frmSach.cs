using QuanLyThuVien.Configs;
using QuanLyThuVien.DTOs;
using QuanLyThuVien.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.GUIs
{
    public partial class frmSach : Form
    {
        private SachService sachService = new SachService();
        private TheLoaiService theLoaiService = new TheLoaiService();

        private CloudinaryHelper cloudinaryHelper = new CloudinaryHelper("demfjaknk", "675115286763916", "YmFNxxs4iZTU5pv-qrBFpldsgMw");

        // Biến lưu đường dẫn ảnh đang chọn
        private string imagePath = "";

        public frmSach()
        {
            InitializeComponent();
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            LoadTheLoai();
            LoadSach();
        }

        private void LoadTheLoai()
        {
            var dsTheLoai = theLoaiService.GetAll();
            cboTheLoai.DataSource = dsTheLoai;
            cboTheLoai.DisplayMember = "TenTheLoai";
            cboTheLoai.ValueMember = "MaTheLoai";
        }

        private void LoadSach()
        {
            var dsTheLoai = theLoaiService.GetAll();
            var listSach = sachService.GetAll();

            var listSachWithTenTheLoai = from sach in listSach
                                         join theLoai in dsTheLoai on sach.MaTheLoai equals theLoai.MaTheLoai
                                         select new
                                         {
                                             sach.MaSach,
                                             sach.TenSach,
                                             TenTheLoai = theLoai.TenTheLoai,
                                             sach.TacGia,
                                             sach.NhaXuatBan,
                                             sach.NamXuatBan,
                                             sach.SoLuong,
                                             sach.Anh
                                         };

            dgvSach.DataSource = listSachWithTenTheLoai.ToList();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imagePath = dlg.FileName;
                picBoxAnh.Image = Image.FromFile(imagePath);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var sach = new SachDTO(
                    0,
                    (int)cboTheLoai.SelectedValue,
                    txtNhaXuatBan.Text.Trim(),
                    txtTacGia.Text.Trim(),
                    txtTenSach.Text.Trim(),
                    int.Parse(txtNamXuatBan.Text.Trim()),
                    int.Parse(txtSoLuong.Text.Trim()),
                    cloudinaryHelper.UploadImage(imagePath)
                );

                sachService.Add(sach);
            LoadSach();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaSach.Text))
                {
                    MessageBox.Show("Vui lòng chọn sách để cập nhật.");
                    return;
                }

                var sach = new SachDTO(
                    int.Parse(txtMaSach.Text.Trim()),
                    (int)cboTheLoai.SelectedValue,
                    txtNhaXuatBan.Text.Trim(),
                    txtTacGia.Text.Trim(),
                    txtTenSach.Text.Trim(),
                    int.Parse(txtNamXuatBan.Text.Trim()),
                    int.Parse(txtSoLuong.Text.Trim()),
                    cloudinaryHelper.UploadImage(imagePath)
                );

                sachService.Update(sach);
            LoadSach();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaSach.Text))
                {
                    MessageBox.Show("Vui lòng chọn sách để xóa.");
                    return;
                }

                int maSach = int.Parse(txtMaSach.Text);
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa sách này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    sachService.Delete(maSach);
                    
                }
                LoadSach();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSach.Rows[e.RowIndex];
                txtMaSach.Text = row.Cells["MaSach"].Value.ToString();
                txtTenSach.Text = row.Cells["TenSach"].Value.ToString();
                cboTheLoai.Text = row.Cells["TenTheLoai"].Value.ToString();
                txtTacGia.Text = row.Cells["TacGia"].Value.ToString();
                txtNhaXuatBan.Text = row.Cells["NhaXuatBan"].Value.ToString();
                txtNamXuatBan.Text = row.Cells["NamXuatBan"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();

                string anh = row.Cells["Anh"].Value?.ToString() ?? "";
                imagePath = anh;

                if (!string.IsNullOrEmpty(anh))
                {
                    picBoxAnh.Image = cloudinaryHelper.LoadImageFromUrl(anh);
                }
                else
                {
                    picBoxAnh.Image = null;
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            var ketQua = sachService.GetAll().Where(s =>
                s.MaSach.ToString().Contains(keyword) ||
                s.MaTheLoai.ToString().Contains(keyword) ||
                s.TenSach.ToLower().Contains(keyword) ||
                s.TacGia.ToLower().Contains(keyword) ||
                s.NhaXuatBan.ToLower().Contains(keyword) ||
                s.NamXuatBan.ToString().Contains(keyword) ||
                s.SoLuong.ToString().Contains(keyword)
            ).ToList();

            dgvSach.DataSource = ketQua;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imagePath = dlg.FileName;
                picBoxAnh.ImageLocation = imagePath;
            }
        }
    }
}
