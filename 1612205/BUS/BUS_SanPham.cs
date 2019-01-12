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
    }
}
