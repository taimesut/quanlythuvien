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
    public partial class frmNhanVien : Form
    {

        private NhanVienService nhanVienService = new NhanVienService();
        public frmNhanVien()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");


            loadNhanVien();
        }

        private void loadNhanVien()
        {
            var list = nhanVienService.GetAll();

            dgvNhanVien.DataSource = null;
            dgvNhanVien.DataSource = list;

        }

        private void dvgNhanVien_cellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtMaNhanVien.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtHoTen.Text = row.Cells["HoVaTen"].Value.ToString();
                txtChucVu.Text = row.Cells["ChucVu"].Value.ToString();
                txtTenTaiKhoan.Text = row.Cells["TenTaiKhoan"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                datePicker.Text = row.Cells["NgaySinh"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                string gt = row.Cells["GioiTinh"].Value?.ToString();
                cboGioiTinh.SelectedItem = gt;

                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
            }
        }

        private void ClearForm()
        {
            txtMaNhanVien.Text = "";
            txtTenTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            cboGioiTinh.SelectedIndex = -1;
            txtSoDienThoai.Text = "";
            txtChucVu.Text = "";
            datePicker.Text = "";
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var nv = new NhanVienDTO
                {
                    TenTaiKhoan = txtTenTaiKhoan.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    HoVaTen = txtHoTen.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    GioiTinh = cboGioiTinh.SelectedItem?.ToString(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    ChucVu = txtChucVu.Text.Trim(),
                    NgaySinh = DateTime.Parse(datePicker.Text.Trim())
                };

                bool result = nhanVienService.Add(nv);
                if (result)
                {
                    MessageBox.Show("Thêm nhân viên thành công!");
                    loadNhanVien();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaNhanVien.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần sửa.");
                    return;
                }

                var nv = new NhanVienDTO
                {
                    MaNhanVien = int.Parse(txtMaNhanVien.Text),
                    TenTaiKhoan = txtTenTaiKhoan.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    HoVaTen = txtHoTen.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    GioiTinh = cboGioiTinh.SelectedItem?.ToString(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    ChucVu = txtChucVu.Text.Trim(),
                    NgaySinh = DateTime.Parse(datePicker.Text.Trim())
                };

                bool result = nhanVienService.Update(nv);
                if (result)
                {
                    MessageBox.Show("Cập nhật nhân viên thành công!");
                    loadNhanVien();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật nhân viên thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaNhanVien.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
                    return;
                }

                int id = int.Parse(txtMaNhanVien.Text);
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    bool result = nhanVienService.Delete(id);
                    if (result)
                    {
                        MessageBox.Show("Xóa nhân viên thành công!");
                        loadNhanVien();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            var ketQua = nhanVienService.GetAll().Where(d =>
                d.MaNhanVien.ToString().Contains(keyword) ||
                d.HoVaTen.ToLower().Contains(keyword) ||
                d.DiaChi.ToLower().Contains(keyword) ||
                d.TenTaiKhoan.ToLower().Contains(keyword) ||
                d.GioiTinh.Contains(keyword) ||
                d.SoDienThoai.Contains(keyword)
            ).ToList();

            dgvNhanVien.DataSource = null;
            dgvNhanVien.DataSource = ketQua;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
