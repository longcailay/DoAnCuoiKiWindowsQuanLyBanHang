using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_SanPham
    {
        DAL_SanPham dalSanPham = new DAL_SanPham();

        public DataTable getSanPham()
        {
            return dalSanPham.getSanPham();
        }
       public DataTable getLoaiSanPham()
        {
            return dalSanPham.getLoaiSanPham();
        }
        public bool themSanPham(DTO_SanPham SP)
        {
            return dalSanPham.themSanPham(SP);
        }
    }
}
