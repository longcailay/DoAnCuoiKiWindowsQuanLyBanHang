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

        public int getSoLuongSPTrongSPDH(int maDonHang)//lấy số lượng dòng trong bảng SPDH mà có mã DH = madonhang
        {
            string SQL = string.Format($"select count(*) from SANPHAM_DONHANG where MaDonHang = {maDonHang}");
            SqlDataAdapter da = new SqlDataAdapter(SQL, _conn);
            DataTable dtDonHang = new DataTable();
            da.Fill(dtDonHang);
            int SL = Int32.Parse(dtDonHang.Rows[0][0].ToString());
            return SL;
        }

        public bool thanhToanDonHang(int maDonHang)
        {
            try
            {
                // Ket noi
                _conn.Open();
                // Query string 
                string SQL = string.Format($"update DONHANG set ThanhToan = 1 where MaDonHang = {maDonHang}");
                
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

        public bool lapDonHangMoi(DateTime ngayLap)
        {
            try
            {                
                // Ket noi
                _conn.Open();
                string format = "MM-dd-yyyy HH:mm:ss";
                // Query string 
                string SQL = string.Format($" insert into DONHANG values(N'NULL','{ngayLap.ToString(format)}',0,0)");

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
        public int getMaxIdDonHang()
        {
            string SQL = string.Format($"select MAX(MaDonHang) from DONHANG");
            SqlDataAdapter da = new SqlDataAdapter(SQL, _conn);
            DataTable dtDonHang = new DataTable();
            da.Fill(dtDonHang);
            int SL = Int32.Parse(dtDonHang.Rows[0][0].ToString());
            return SL;
        }

        public DataTable getDonHangMoiTao(int MaDonHang)
        {
            string SQL = string.Format($"select maDonHang,NgayBan from DONHANG where MaDonHang = {MaDonHang}");
            SqlDataAdapter da = new SqlDataAdapter(SQL, _conn);
            DataTable dtDonHang = new DataTable();
            da.Fill(dtDonHang);
            return dtDonHang;
        }
        public bool xoaDonHang(int maDonHang,int mode)//mode=0. đơn hàng chưa có sp nào nên không có dữ liệu trong bẳng SP_DH
                                                      //mode=1. đơn hàng đã có sản phẩm trong bảng SP_DH
        {
            try
            {
                // Ket noi
                _conn.Open();
                // Query string 
                string SQL="";
                if (mode == 0)
                {
                    SQL = string.Format($"delete DONHANG where MaDonHang = {maDonHang}");//chỉ xóa bảng DONHANG
                }
                else
                {
                    SQL = string.Format($"delete SANPHAM_DONHANG where MaDonHang = {maDonHang}  delete DONHANG where MaDonHang = {maDonHang} ");//xóa cả hai bảng DH và SP_DH
                }
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
