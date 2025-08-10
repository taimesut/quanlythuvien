using QuanLyThuVien.DTOs;
using QuanLyThuVien.Repositories;
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
    public partial class frmQuyDinh : Form
    {
        private QuyDinhRepository repo = new QuyDinhRepository();
        public frmQuyDinh()
        {
            InitializeComponent();

            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var quidinh = new QuyDinhDTO
            (
                1,
                int.Parse(txtSoNgayMuonToiDa.Text),
                int.Parse(txtSoSachMuonToiDa.Text)
            );

            repo.Update( quidinh );

            MessageBox.Show("Update Thành công");
        }

        private void LoadData()
        {
            var quidinh = repo.GetById(1);

            txtSoNgayMuonToiDa.Text = quidinh.SoNgayMuonToiDa.ToString();
            txtSoSachMuonToiDa.Text = quidinh.SoSachMuonToiDa.ToString();
        }
    }
}
