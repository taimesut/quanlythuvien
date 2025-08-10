using QuanLyThuVien.DTOs;
using QuanLyThuVien.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services
{
    public class DocGiaService
    {
        private readonly DocGiaRepository _repo;

        public DocGiaService()
        {
            _repo = new DocGiaRepository();
        }

        public List<DocGiaDTO> LayTatCaDocGia()
        {
            return _repo.GetAll();
        }

        public DocGiaDTO LayDocGiaTheoId(int id)
        {
            return _repo.GetById(id);
        }

        public bool ThemDocGia(DocGiaDTO docGia)
        {
            if (string.IsNullOrWhiteSpace(docGia.HoVaTen))
                throw new Exception("Họ và tên không được để trống.");

            return _repo.Add(docGia);
        }

        public bool CapNhatDocGia(DocGiaDTO docGia)
        {
            if (docGia.MaDocGia <= 0)
                throw new Exception("Mã độc giả không hợp lệ.");

            return _repo.Update(docGia);
        }

        public bool XoaDocGia(int id)
        {
            if (id <= 0)
                throw new Exception("Mã độc giả không hợp lệ.");

            return _repo.Delete(id);
        }

        public List<DocGiaDTO> TimKiemDocGia(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return LayTatCaDocGia();

            return _repo.SearchByName(keyword);
        }
    }
}
