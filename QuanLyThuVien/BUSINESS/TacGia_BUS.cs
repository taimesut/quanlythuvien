using QuanLyThuVien.DATA_ACCESS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BUSINESS
{
    public class TacGia_BUS
    {
        private TacGiaDAL dal;

        public TacGia_BUS()
        {
            dal = new TacGiaDAL();
        }

        public List<TacGiaDTO> GetAll()
        {
            return dal.GetAll();
        }

        public bool Add(TacGiaDTO tg)
        {
            return dal.Insert(tg);
        }

        public bool Update(TacGiaDTO tg)
        {
            return dal.Update(tg);
        }

        public bool Delete(int maTacGia)
        {
            return dal.Delete(maTacGia);
        }

        public TacGiaDTO GetById(int maTacGia)
        {
            return dal.GetById(maTacGia);
        }

        public List<TacGiaDTO> Search(string keyword)
        {
            return dal.Search(keyword);
        }
    }
}
