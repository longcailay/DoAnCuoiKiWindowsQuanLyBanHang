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
    public class DAL_SanPham: DAL_DBConnect
    {
        /// <summary>
        /// Get toàn bộ sản phẩm (chỉ ở bảng sản phẩm)
        /// </summary>
        /// <returns></returns>
        public DataTable getSanPham()
        {
            SqlDataAdapter da = new SqlDataAdapter("select TenSanPham,TenFile,GiaBanSanPham,SoLuong,PhanTram,NgayBatDau,NgayKetThuc,sp.MaSanPham, from SANPHAM sp left join KHUYENMAI km on sp.MaSanPham = km.MaSanPham and TinhTrang=1", _conn);
            DataTable dtSanPham = new DataTable();
            da.Fill(dtSanPham);
            return dtSanPham;
        }

        
    }
}
