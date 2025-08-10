using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTOs
{
    public class DocGiaDTO
    {
        public DocGiaDTO(int maDocGia, string hoVaTen, string diaChi, string gioiTinh, string soDienThoai)
        {
            MaDocGia = maDocGia;
            HoVaTen = hoVaTen;
            DiaChi = diaChi;
            GioiTinh = gioiTinh;
            SoDienThoai = soDienThoai;
        }

        public int MaDocGia {  get; set; }
        public string HoVaTen {  get; set; }
        public string DiaChi {  get; set; }
        public string GioiTinh {  get; set; }
        public string SoDienThoai {  get; set; }
    }
}
