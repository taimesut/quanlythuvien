using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class NhaCungCapDTO
    {
        public int MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Gmail { get; set; }

        public NhaCungCapDTO() { }

        public NhaCungCapDTO(int maNhaCungCap, string tenNhaCungCap, string diaChi, string soDienThoai, string gmail)
        {
            MaNhaCungCap = maNhaCungCap;
            TenNhaCungCap = tenNhaCungCap;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            Gmail = gmail;
        }
    }
}
