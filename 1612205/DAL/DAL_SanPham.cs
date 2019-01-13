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
            SqlDataAdapter da = new SqlDataAdapter("select TenSanPham,FileAnh,GiaBanSanPham,SoLuong,PhanTram,NgayBatDau,NgayKetThuc,sp.MaSanPham,sp.MaLoaiSanPham from SANPHAM sp left join KHUYENMAI km on sp.MaSanPham = km.MaSanPham and TinhTrang=1", _conn);
            DataTable dtSanPham = new DataTable();
            da.Fill(dtSanPham);
            return dtSanPham;
        }
        public bool themSanPham(DTO_SanPham SP)
        {
            try
            {
                // Ket noi
                _conn.Open();                
                // Query string 
                string SQL = string.Format("INSERT INTO SANPHAM(TenSanPham,FileAnh,GiaBanSanPham,GiaMuaSanPham,TinhTrang,MaLoaiSanPham,SoLuong) VALUES(N'{0}',N'{1}','{2}','{3}','{4}','{5}','{6}')", SP.TENSANPHAM, SP.TENFILE, SP.GIABANSANPHAM, SP.GIAMUASANPHAM, SP.TINHTRANG, SP.MALOAISANPHAM,SP.SOLUONG);

                // Command
                SqlCommand cmd = new SqlCommand(SQL, _conn);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
            return false;
        }


    }
}
