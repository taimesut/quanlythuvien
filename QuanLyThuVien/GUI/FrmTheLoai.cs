using QuanLyThuVien.BUSINESS;
using QuanLyThuVien.DTO;
using System;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class FrmTheLoai : Form
    {
        private TheLoaiDTO currentTheLoai;
        private TheLoai_BUS bus = new TheLoai_BUS();

        // Constructor thêm mới
        public FrmTheLoai()
        {
            InitializeComponent();
            this.Text = "Thêm Thể Loại Mới";
        }

        // Constructor sửa (truyền DTO vào)
        public FrmTheLoai(TheLoaiDTO theLoai) : this()
        {
            currentTheLoai = theLoai;
            this.Text = "Sửa Thể Loại";
            txtTenTheLoai.Text = currentTheLoai.TenTheLoai;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ten = txtTenTheLoai.Text.Trim();
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng nhập tên thể loại.");
                return;
            }

            if (currentTheLoai == null)
            {
                // Thêm mới
                TheLoaiDTO newTheLoai = new TheLoaiDTO { TenTheLoai = ten };
                if (bus.Add(newTheLoai))
                {
                    MessageBox.Show("Thêm thể loại thành công.");
                }
                else
                {
                    MessageBox.Show("Thêm thể loại thất bại.");
                }
            }
            else
            {
                // Sửa
                currentTheLoai.TenTheLoai = ten;
                if (bus.Update(currentTheLoai))
                {
                    MessageBox.Show("Cập nhật thể loại thành công.");
                }
                else
                {
                    MessageBox.Show("Cập nhật thể loại thất bại.");
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
