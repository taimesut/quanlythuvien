using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class TacGiaDTO
    {
        public int MaTacGia { get; set; }
        public string HoVaTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public TacGiaDTO() { }

        public TacGiaDTO(int maTacGia, string hoVaTen, string gioiTinh, DateTime ngaySinh, string diaChi, string soDienThoai)
        {
            MaTacGia = maTacGia;
            HoVaTen = hoVaTen;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
        }
    }
}
