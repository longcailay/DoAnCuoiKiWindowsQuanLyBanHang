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
    public class BUS_GiaoDich
    {
        DAL_GiaoDich dalGiaoDich = new DAL_GiaoDich();
        public DataTable getDonHang()
        {
            return dalGiaoDich.getDonHang();
        }
        public bool xoaDonHang(int maDonHang,int mode)
        {
            return dalGiaoDich.xoaDonHang(maDonHang,mode);
        }
        public int getSoLuongSPTrongSPDH(int maDonHang)
        {
            return dalGiaoDich.getSoLuongSPTrongSPDH(maDonHang);
        }
        public bool thanhToanDonHang(int maDonHang)
        {
            return dalGiaoDich.thanhToanDonHang(maDonHang);
        }
    }
}
