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
        public DataTable getSanPham(string strTimKiem)
        {
            return dalSanPham.getSanPham(strTimKiem);
        }
        public DataTable getSanPham(int maLoaiSP)
        {
            return dalSanPham.getSanPham(maLoaiSP);
        }
        public DataTable getLoaiSanPham()
        {
            return dalSanPham.getLoaiSanPham();
        }
        public DataTable getChiTietSanPham(int MaSanPham)
        {
            return dalSanPham.getChiTietSanPham(MaSanPham);
        }
        public bool themSanPham(DTO_SanPham SP)
        {
            return dalSanPham.themSanPham(SP);
        }
        public bool suaChiTietSanPham(string TenSanPham, int GiaBanSanPham, int GiaMuaSanPham, int SoLuong, int LoaiSanPham, string FileAnh, int MaSanPham)
        {
            return dalSanPham.suaChiTietSanPham(TenSanPham, GiaBanSanPham, GiaMuaSanPham, SoLuong, LoaiSanPham, FileAnh, MaSanPham);

        }
        public bool xoaSanPham(int maSanPham)
        {
            return dalSanPham.xoaSanPham(maSanPham);
        }
    }
}
