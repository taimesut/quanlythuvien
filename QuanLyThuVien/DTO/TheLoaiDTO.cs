using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class TheLoaiDTO
    {
        public int MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }

        public TheLoaiDTO() { }

        public TheLoaiDTO(int maTheLoai, string tenTheLoai)
        {
            MaTheLoai = maTheLoai;
            TenTheLoai = tenTheLoai;
        }
    }
}
