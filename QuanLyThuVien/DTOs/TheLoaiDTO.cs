using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTOs
{
    public class TheLoaiDTO
    {
        public TheLoaiDTO(int maTheLoai, string tenTheLoai)
        {
            MaTheLoai = maTheLoai;
            TenTheLoai = tenTheLoai;
        }

        public int MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }
    }
}
