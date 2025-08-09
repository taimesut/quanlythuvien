using QuanLyThuVien.DATA_ACCESS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BUSINESS
{
    public class TheLoai_BUS
    {
        private TheLoaiDAL dal;

        public TheLoai_BUS()
        {
            dal = new TheLoaiDAL();
        }

        public List<TheLoaiDTO> GetAll()
        {
            return dal.GetAll();
        }

        public bool Add(TheLoaiDTO tl)
        {
            return dal.Insert(tl);
        }

        public bool Update(TheLoaiDTO tl)
        {
            return dal.Update(tl);
        }

        public bool Delete(int maTheLoai)
        {
            return dal.Delete(maTheLoai);
        }

        public TheLoaiDTO GetById(int maTheLoai)
        {
            return dal.GetById(maTheLoai);
        }

        public List<TheLoaiDTO> Search(string keyword)
        {
            return dal.Search(keyword);
        }
    }
}
