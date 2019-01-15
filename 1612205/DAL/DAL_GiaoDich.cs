using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_GiaoDich:DAL_DBConnect
    {
        public DataTable getDonHang()
        {
            string SQL = string.Format($"select MaDonHang,TenKhachHang,NgayBan,ThanhToan,TongTien from DONHANG");
            SqlDataAdapter da = new SqlDataAdapter(SQL, _conn);
            DataTable dtDonHang = new DataTable();
            da.Fill(dtDonHang);
            return dtDonHang;
        }
    }
}
