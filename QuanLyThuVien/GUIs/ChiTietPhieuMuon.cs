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
    public partial class ChiTietPhieuMuon : Form
    {
        private ChiTietPhieuMuonRepository repository = new ChiTietPhieuMuonRepository();
        private SachRepository sachRepository = new SachRepository();
        private int id;
        public ChiTietPhieuMuon()
        {
            InitializeComponent();
        }

        public ChiTietPhieuMuon(int id)
        {
            InitializeComponent();
            this.id = id;
            label1.Text ="Mã Phiếu: " + id.ToString();

            LoadData();
        }

        private void LoadData()
        {
            var listChiTiet = repository.GetByPhieuMuon(id);
            var listSach = sachRepository.GetAll();

            var newlist = from s in listChiTiet
                          join ls in listSach on s.MaSach equals ls.MaSach
                          select new
                          {
                              s.MaSach,
                              ls.TenSach,
                              s.SoLuong,
                          };
            Console.WriteLine(newlist);

            dgv.DataSource = null;
            dgv.DataSource = newlist.ToList();
        }
    }
}
