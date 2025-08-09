
using QuanLyThuVien.DATA_ACCESS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyThuVien.BUSINESS
{
    public class DocGia_BUS
    {
        private DocGiaDAL dal = new DocGiaDAL();

        // Lấy toàn bộ danh sách độc giả
        public List<DocGiaDTO> GetAll()
        {
            return dal.GetAll();
        }

        // Thêm độc giả mới
        public bool Add(DocGiaDTO docGia)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(docGia.HoVaTen))
                throw new ArgumentException("Họ tên độc giả không được để trống!");

            if (docGia.NgaySinh > DateTime.Now.AddYears(-10)) // Ví dụ: phải trên 10 tuổi
                throw new ArgumentException("Ngày sinh không hợp lệ!");

            return dal.Insert(docGia);
        }

        // Sửa thông tin độc giả
        public bool Update(DocGiaDTO docGia)
        {
            if (docGia.MaDocGia <= 0)
                throw new ArgumentException("Mã độc giả không hợp lệ!");

            if (string.IsNullOrWhiteSpace(docGia.HoVaTen))
                throw new ArgumentException("Họ tên độc giả không được để trống!");

            return dal.Update(docGia);
        }

        // Xóa độc giả theo mã
        public bool Delete(int maDocGia)
        {
            if (maDocGia <= 0)
                throw new ArgumentException("Mã độc giả không hợp lệ!");

            return dal.Delete(maDocGia);
        }

        // Tìm kiếm độc giả theo từ khóa (tên, mã, CMND, ...)
        public List<DocGiaDTO> Search(string keyword)
        {
            return dal.Search(keyword);
        }
    }
}
