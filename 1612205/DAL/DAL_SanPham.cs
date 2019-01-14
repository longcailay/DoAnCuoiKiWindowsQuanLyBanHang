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
            SqlDataAdapter da = new SqlDataAdapter("select TenSanPham,FileAnh,GiaBanSanPham,SoLuong,PhanTram,NgayBatDau,NgayKetThuc,sp.MaSanPham,sp.MaLoaiSanPham from SANPHAM sp left join KHUYENMAI km on sp.MaSanPham = km.MaSanPham where TinhTrang = 1", _conn);
            DataTable dtSanPham = new DataTable();
            da.Fill(dtSanPham);
            return dtSanPham;
        }

        public DataTable getLoaiSanPham()
        {
            SqlDataAdapter da = new SqlDataAdapter("select TenLoaiSanPham,MaLoaiSanPham from LOAISANPHAM", _conn);
            DataTable dtLoaiSanPham = new DataTable();
            da.Fill(dtLoaiSanPham);
            return dtLoaiSanPham;
        }

        public DataTable getChiTietSanPham(int MaSanPham)
        {
            string SQL = string.Format($"select TenSanPham,GiaBanSanPham,GiaMuaSanPham,SoLuong,TenLoaiSanPham,FileAnh,sp.MaLoaiSanPham from SANPHAM sp,LOAISANPHAM lsp where sp.MaSanPham={MaSanPham} and sp.MaLoaiSanPham = lsp.MaLoaiSanPham and TinhTrang=1");
            SqlDataAdapter da = new SqlDataAdapter(SQL, _conn);
            DataTable dtLoaiSanPham = new DataTable();
            da.Fill(dtLoaiSanPham);
            return dtLoaiSanPham;
        }

        public bool suaChiTietSanPham(string TenSanPham, int GiaBanSanPham, int GiaMuaSanPham, int SoLuong, int LoaiSanPham, string FileAnh, int MaSanPham)
        {
            try
            {
                //Ket noi
                _conn.Open();

                //Query string
                string SQL = string.Format($"UPDATE SANPHAM SET " +
                    "TenSanPham = N'{0}', GiaBanSanPham = {1}, GiaMuaSanPham= {2}, SoLuong = {3}, MaLoaiSanPham={4},FileAnh='{5}' where MaSanPham={6}",TenSanPham,GiaBanSanPham,GiaMuaSanPham, SoLuong,LoaiSanPham, FileAnh,MaSanPham);
                
                SqlCommand cmd = new SqlCommand(SQL, _conn);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
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

        public bool xoaSanPham(int maSanPham)
        {
            try
            {
                // Ket noi
                _conn.Open();
                // Query string 
                string SQL = string.Format($"UPDATE SANPHAM SET " +
                    " TinhTrang = 0 where MaSanPham={0}", maSanPham);

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
