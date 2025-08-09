using System;

namespace QuanLyThuVien.DTO
{
    public class DocGiaDTO
    {
        public int MaDocGia { get; set; }
        public string HoVaTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }

        public DocGiaDTO() { }

        public DocGiaDTO(int maDocGia, string hoVaTen, DateTime ngaySinh, string diaChi, string gioiTinh, string soDienThoai)
        {
            MaDocGia = maDocGia;
            HoVaTen = hoVaTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            GioiTinh = gioiTinh;
            SoDienThoai = soDienThoai;
        }
    }
}
