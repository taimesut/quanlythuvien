using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTOs
{
    public class QuyDinhDTO
    {
        public QuyDinhDTO(int maQuyDinh, int soNgayMuonToiDa, int soSachMuonToiDa)
        {
            MaQuyDinh = maQuyDinh;
            SoNgayMuonToiDa = soNgayMuonToiDa;
            SoSachMuonToiDa = soSachMuonToiDa;
        }

        public int MaQuyDinh {  get; set; }
        public int SoNgayMuonToiDa { get; set; }
        public int SoSachMuonToiDa { get; set; }
    }
}
