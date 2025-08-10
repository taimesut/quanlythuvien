using QuanLyThuVien.DTOs;
using QuanLyThuVien.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Services
{
    public class TheLoaiService
    {
        private readonly TheLoaiRepository _theLoaiRepo;

        public TheLoaiService()
        {
            _theLoaiRepo = new TheLoaiRepository();
        }

        public List<TheLoaiDTO> GetAll()
        {
            return _theLoaiRepo.GetAll();
        }

        public TheLoaiDTO GetById(int maTheLoai)
        {
            return _theLoaiRepo.GetById(maTheLoai);
        }

        public bool Add(string tenTheLoai)
        {
            if (string.IsNullOrWhiteSpace(tenTheLoai))
                throw new ArgumentException("Tên thể loại không được để trống.");

            var theLoai = new TheLoaiDTO(0, tenTheLoai);
            return _theLoaiRepo.Add(theLoai);
        }

        public bool Update(int maTheLoai, string tenTheLoai)
        {
            if (maTheLoai <= 0)
                throw new ArgumentException("Mã thể loại không hợp lệ.");

            if (string.IsNullOrWhiteSpace(tenTheLoai))
                throw new ArgumentException("Tên thể loại không được để trống.");

            var theLoai = new TheLoaiDTO(maTheLoai, tenTheLoai);
            return _theLoaiRepo.Update(theLoai);
        }

        public bool Delete(int maTheLoai)
        {
            if (maTheLoai <= 0)
                throw new ArgumentException("Mã thể loại không hợp lệ.");

            return _theLoaiRepo.Delete(maTheLoai);
        }
    }
}
