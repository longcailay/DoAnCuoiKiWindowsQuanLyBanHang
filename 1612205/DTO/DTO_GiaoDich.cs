using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_GiaoDich
    {
        private int maDonHang { get; set; }
        private string tenKhachHang { get; set; }
        private DateTime ngayBan { get; set; }
        private int tongTien { get; set; }
        public DTO_GiaoDich(int maDH, string tenKH, DateTime NgayBan, int TongTien)
        {
            maDonHang = maDH;
            tenKhachHang = tenKH;
            ngayBan = NgayBan;
            tongTien = TongTien;
        }
    }
}
