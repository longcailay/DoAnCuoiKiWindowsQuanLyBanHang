﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using DTO;
using BUS;

namespace _1612205
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }
        int isLapDonHang = 0;
        int maDHCur_LapDonHang = 0;
        BUS_GiaoDich BUS_GD = new BUS_GiaoDich();


        public class CDonHang
        {
            public int maDonHang { get; set; }
            public string tenKhachHang { get; set; }
            public DateTime ngayBan { get; set; }
            public int tongTien { get; set; }
            public string thanhToan { get; set; }
            public CDonHang(int maDH, string tenKH, DateTime NgayBan, int TongTien, string ThanhToan)
            {
                maDonHang = maDH;
                tenKhachHang = tenKH;
                ngayBan = NgayBan;
                tongTien = TongTien;
                thanhToan = ThanhToan;
            }

        }
        /* public class CDonHang
         {
             public int maDonHang { get; set; }
             public string tenKhachHang { get; set; }
             public DateTime ngayBan { get; set; }
             public int tongTien { get; set; }
             public string thanhToan { get; set; }
             public CDonHang(int maDH, string tenKH, DateTime NgayBan, int TongTien, string ThanhToan)
             {
                 maDonHang = maDH;
                 tenKhachHang = tenKH;
                 ngayBan = NgayBan;
                 tongTien = TongTien;
                 thanhToan = ThanhToan;
             }

         }*/
        public DataTable loadDonHang()
        {
            return BUS_GD.getDonHang();
        }

        private List<CDonHang> TaoMangCacDonHang(MainWindow mainWindow)
        {
            List<CDonHang> MangDonHang = new List<CDonHang>();
            //DataTable dttbSP = BUS_SP.getSanPham();
            DataTable dttbDH = mainWindow.loadDonHang();
            for (int i = 0; i < dttbDH.Rows.Count; i++)//dttbSP.Rows.Count
            {
                int maDH;
                Int32.TryParse(dttbDH.Rows[i][0].ToString(), out maDH);
                string tenKH = dttbDH.Rows[i][1].ToString();
                DateTime ngayBan;
                DateTime.TryParse(dttbDH.Rows[i][2].ToString(), out ngayBan);
                int nThanhToan;
                Int32.TryParse(dttbDH.Rows[i][3].ToString(), out nThanhToan);
                string strThanhToan;
                if (nThanhToan == 1)
                {
                    strThanhToan = "Đã thanh toán";
                }
                else
                {
                    strThanhToan = "Chưa thanh toán";
                }
                int tongTien;
                Int32.TryParse(dttbDH.Rows[i][4].ToString(), out tongTien);
                MangDonHang.Add(new CDonHang(maDH, tenKH, ngayBan, tongTien, strThanhToan));
            }
            return MangDonHang;
        }
        /* private List<CDonHang> TaoMangCacDonHang(MainWindow mainWindow)
         {
             List<CDonHang> MangDonHang = new List<CDonHang>();
             //DataTable dttbSP = BUS_SP.getSanPham();
             DataTable dttbDH = mainWindow.loadDonHang();
             for (int i = 0; i < dttbDH.Rows.Count; i++)//dttbSP.Rows.Count
             {
                 int maDH;
                 Int32.TryParse(dttbDH.Rows[i][0].ToString(), out maDH);
                 string tenKH = dttbDH.Rows[i][1].ToString();
                 DateTime ngayBan;
                 DateTime.TryParse(dttbDH.Rows[i][2].ToString(), out ngayBan);
                 int nThanhToan;
                 Int32.TryParse(dttbDH.Rows[i][3].ToString(), out nThanhToan);
                 string strThanhToan;
                 if (nThanhToan == 1)
                 {
                     strThanhToan = "Đã thanh toán";
                 }
                 else
                 {
                     strThanhToan = "Chưa thanh toán";
                 }
                 int tongTien;
                 Int32.TryParse(dttbDH.Rows[i][4].ToString(), out tongTien);
                 MangDonHang.Add(new CDonHang(maDH, tenKH, ngayBan, tongTien, strThanhToan));
             }
             return MangDonHang;
         }
         */

        #region Usercontrol SanPham
        BUS_SanPham BUS_SP = new BUS_SanPham();
        int modeFind = 0;//0. mặc định tìm hết,1. tìm theo khung tìm kiếm,2. tìm theo khung lọc
        #region Lop san pham
        public class CSanPham
        {
            private string tenSanPham;
            private string fileAnh;
            private int giaBanSanPham;
            private int soLuong;
            private int phanTram;
            private int tinhTrang;
            private int giaMuaSanPham;
            private int maSanPham;
            private int maLoaiSanPham;

            public string TenSanPham
            {
                set { tenSanPham = value; }
                get { return tenSanPham; }
            }
            public string FileAnh
            {
                set { fileAnh = value; }
                get { return fileAnh; }
            }
            public int GiaBanSanPham
            {
                set { giaBanSanPham = value; }
                get { return giaBanSanPham; }
            }
            public int SoLuong
            {
                set { soLuong = value; }
                get { return soLuong; }
            }
            public int PhanTram
            {
                set { phanTram = value; }
                get { return phanTram; }
            }
            public int GiaMuaSanPham
            {
                set { giaMuaSanPham = value; }
                get { return giaMuaSanPham; }
            }
            public int TinhTrang
            {
                set { tinhTrang = value; }
                get { return tinhTrang; }
            }
            public int MaSanPham
            {
                set { maSanPham = value; }
                get { return maSanPham; }
            }
            public int MaLoaiSanPham
            {
                set { maLoaiSanPham = value; }
                get { return maLoaiSanPham; }
            }
            public CSanPham(string TenSanPham, string FileAnh, int GiaBanSanPham, int SoLuong, int PhanTram, int TinhTrang, int GiaMua, int MaSanPham, int MaLoaiSanPham)
            {
                tenSanPham = TenSanPham;
                fileAnh = FileAnh;
                giaBanSanPham = GiaBanSanPham;
                soLuong = SoLuong;
                phanTram = PhanTram;
                tinhTrang = TinhTrang;
                giaMuaSanPham = GiaMuaSanPham;
                maSanPham = MaSanPham;
                maLoaiSanPham = MaLoaiSanPham;
            }

        }
        #endregion
        public DataTable loadSanPham(int mode)//mode 0. mặc định tìm hết,1. tìm theo khung tìm kiếm,2. tìm theo khung lọc
        {
            if (mode == 1)
            {
                return BUS_SP.getSanPham(txbTimKiem.Text);
            }
            if (mode == 2)
            {
                if (cbxLoc.SelectedIndex != -1)
                {
                    int loaiSanPham;
                    Int32.TryParse(cbxLoc.SelectedValue.ToString(), out loaiSanPham);
                    return BUS_SP.getSanPham(loaiSanPham);
                }
            }
            return BUS_SP.getSanPham();
        }

        public static void TaoMangCacSanPham(ref List<CSanPham> MangCacSanPham, MainWindow mainWindow, int mode)
        {
            //DataTable dttbSP = BUS_SP.getSanPham();
            DataTable dttbSP = mainWindow.loadSanPham(mode);

            for (int i = 0; i < dttbSP.Rows.Count; i++)//dttbSP.Rows.Count
            {
                string tenSP = dttbSP.Rows[i][0].ToString();
                string fileAnh = dttbSP.Rows[i][1].ToString();
                int giaBanSP;
                Int32.TryParse(dttbSP.Rows[i][2].ToString(), out giaBanSP);
                int soLuong;
                Int32.TryParse(dttbSP.Rows[i][3].ToString(), out soLuong);
                int phanTram;
                Int32.TryParse(dttbSP.Rows[i][4].ToString(), out phanTram);
                int tinhTrang;
                Int32.TryParse(dttbSP.Rows[i][5].ToString(), out tinhTrang);
                int giaMuaSP;
                Int32.TryParse(dttbSP.Rows[i][6].ToString(), out giaMuaSP);
                int maSP;
                Int32.TryParse(dttbSP.Rows[i][7].ToString(), out maSP);
                int maLoaiSP;
                Int32.TryParse(dttbSP.Rows[i][8].ToString(), out maLoaiSP);
                MangCacSanPham.Add(new CSanPham(tenSP, fileAnh, giaBanSP, soLuong, phanTram, tinhTrang, giaMuaSP, maSP, maLoaiSP));

            }
        }

        private void btnSanPham_Click(object sender, RoutedEventArgs e)
        {
            uscBaoCao.Visibility = Visibility.Collapsed;
            uscGiaoDich.Visibility = Visibility.Collapsed;
            uscSanPham.Visibility = Visibility.Visible;
            //uscSanPham_Loaded(sender, e);
            gridViewSanPham_Loaded(sender, e);
        }
        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            if (txbTimKiem.Text == "")
            {
                modeFind = 0;
            }
            else
            {
                modeFind = 1;
            }
            this.gridViewSanPham_Loaded(sender, e);
        }

        private void btnLoc_Click(object sender, RoutedEventArgs e)
        {
            if (cbxLoc.SelectedIndex == -1)
            {
                modeFind = 0;
            }
            else
            {
                modeFind = 2;
            }
            this.gridViewSanPham_Loaded(sender, e);
        }


        private void btnThemSanPham_Click(object sender, RoutedEventArgs e)
        {
                WinThemSP winThemSP = new WinThemSP();
                winThemSP.ShowDialog();
           
        }

        private void gridViewSanPham_Loaded(object sender, RoutedEventArgs e)
        {
            List<CSanPham> LSanPham = new List<CSanPham>();
            TaoMangCacSanPham(ref LSanPham, this, modeFind);
            lsvProduct.ItemsSource = LSanPham;
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (isLapDonHang == 0)
            {
                WinChiTietSP winChiTietSP = new WinChiTietSP(Int32.Parse(textBlock.Text));
                winChiTietSP.ShowDialog();
            }
            else
            {
                WinDuaSPVaoGioHang winDuaSPVaoGioHang = new WinDuaSPVaoGioHang(Int32.Parse(textBlock.Text));
                winDuaSPVaoGioHang.ShowDialog();
            }
        }

        private void cbxLoc_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dtTable = BUS_SP.getLoaiSanPham();
            cbxLoc.ItemsSource = dtTable.DefaultView;
            cbxLoc.DisplayMemberPath = "TenLoaiSanPham";
            cbxLoc.SelectedValuePath = "MaLoaiSanPham";
            cbxLoc.SelectedIndex = -1;
        }

        #endregion



        private void btnBaoCao_Click(object sender, RoutedEventArgs e)
        {
            uscBaoCao.Visibility = Visibility.Visible;
            uscGiaoDich.Visibility = Visibility.Collapsed;
            uscSanPham.Visibility = Visibility.Collapsed;
        }

        private void btnGiaoDich_Click(object sender, RoutedEventArgs e)
        {
            uscBaoCao.Visibility = Visibility.Collapsed;
            uscGiaoDich.Visibility = Visibility.Visible;
            uscSanPham.Visibility = Visibility.Collapsed;
            dtgrCacDonHang_Loaded(sender, e);
            cv_btnThanhToan_Xoa.Visibility = Visibility.Collapsed;
            cv_CacDonHang.Visibility = Visibility.Visible;
            cv_LapDonHang.Visibility = Visibility.Collapsed;
        }

        private void dtgrCacDonHang_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            List<CDonHang> LDonHang = TaoMangCacDonHang(this);

            dtgrCacDonHang.ItemsSource = LDonHang;
            dtgrCacDonHang.Columns[0].Header = "Mã ĐH";
            dtgrCacDonHang.Columns[1].Header = "Tên KH";
            dtgrCacDonHang.Columns[2].Header = "Ngày bán";
            dtgrCacDonHang.Columns[3].Header = "Tổng tiền";
            dtgrCacDonHang.Columns[4].Header = "Thanh toán";
            dtgrCacDonHang.Columns[0].IsReadOnly = true;
            dtgrCacDonHang.Columns[1].IsReadOnly = true;
            dtgrCacDonHang.Columns[2].IsReadOnly = true;
            dtgrCacDonHang.Columns[3].IsReadOnly = true;
            dtgrCacDonHang.Columns[4].IsReadOnly = true;
            dtgrCacDonHang.SelectedIndex = -1;

        }

        private void dtgrCacDonHang_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (dtgrCacDonHang.SelectedIndex == -1)
            {
                //MessageBox.Show("kkk");
            }
            else
            {

                //lấy dữ liệu tại ô đang chọn trong datagird wpf
                dtgrCacDonHang.AutoGenerateColumns = true;
                int indexRow = dtgrCacDonHang.SelectedIndex;
                TextBlock text0 = dtgrCacDonHang.Columns[0].GetCellContent(dtgrCacDonHang.Items[indexRow]) as TextBlock;
                if (text0 != null) txbMaDonHang.Text = text0.Text;


                TextBlock text1 = dtgrCacDonHang.Columns[1].GetCellContent(dtgrCacDonHang.Items[indexRow]) as TextBlock;
                if (text1 != null) txbTenKhachHang.Text = text1.Text;


                TextBlock text2 = dtgrCacDonHang.Columns[2].GetCellContent(dtgrCacDonHang.Items[indexRow]) as TextBlock;
                if (text2 != null)
                {
                    var x = DateTime.Parse(text2.Text);
                    dtpkNgayBan.SelectedDate = x;
                }

                TextBlock text3 = dtgrCacDonHang.Columns[3].GetCellContent(dtgrCacDonHang.Items[indexRow]) as TextBlock;
                if (text3 != null) txbTongTien.Text = text3.Text;
                if (txbMaDonHang.Text != "")
                {
                    TextBlock text4 = dtgrCacDonHang.Columns[4].GetCellContent(dtgrCacDonHang.Items[indexRow]) as TextBlock;
                    if (text4 != null)
                    {
                        if (text4.Text == "Chưa thanh toán")
                        {
                            cv_btnThanhToan_Xoa.Visibility = Visibility.Visible;
                            cv_btnThanhToan_Xoa_Loaded(sender, e);
                        }
                        else
                        {
                            cv_btnThanhToan_Xoa.Visibility = Visibility.Collapsed;
                            cv_btnThanhToan_Xoa_Loaded(sender, e);
                        }
                    }

                }
            }

        }

        private void cv_btnThanhToan_Xoa_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnXoaDonHang_Click(object sender, RoutedEventArgs e)
        {
            if (txbMaDonHang.Text != "")
            {
                int maDonHang;
                int mode = 0;
                Int32.TryParse(txbMaDonHang.Text, out maDonHang);
                if (BUS_GD.getSoLuongSPTrongSPDH(maDonHang) > 0)//đơn hàng đã có sản phẩm
                {
                    mode = 1;
                }
                else
                {
                    mode = 0;
                }
                if (BUS_GD.xoaDonHang(maDonHang, mode))
                {
                    MessageBox.Show("Xóa đơn hàng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    dtgrCacDonHang_Loaded(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            if (txbMaDonHang.Text != "")
            {
                int maDonHang;
                Int32.TryParse(txbMaDonHang.Text, out maDonHang);
                if (BUS_GD.thanhToanDonHang(maDonHang))
                {
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    dtgrCacDonHang_Loaded(sender, e);
                }
                else
                {
                    MessageBox.Show("thanh toán thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnLapDonHang_Click(object sender, RoutedEventArgs e)
        {
            cv_CacDonHang.Visibility = Visibility.Collapsed;
            cv_LapDonHang.Visibility = Visibility.Visible;
            btnLapDonHang.IsEnabled = false;
            btnQuayVeDonHang.IsEnabled = true;
            btnDenCuaHang.IsEnabled = true;
            isLapDonHang = 1;
            DateTime a = DateTime.Now;
            //MessageBox.Show(a.ToShortDateString());          
            if (BUS_GD.lapDonHangMoi(a))
            {
                maDHCur_LapDonHang = BUS_GD.getMaxIdDonHang();                
                cv_LapDonHang_Loaded(sender, e);
            }
            else
            {
                MessageBox.Show("Không thể lập đơn hàng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MessageBox.Show("hđhdh");
        }

        private void uscGiaoDich_Loaded(object sender, RoutedEventArgs e)
        {
            if(isLapDonHang==0)
            {
                btnLapDonHang.IsEnabled = true;
                btnQuayVeDonHang.IsEnabled = false;
                btnDenCuaHang.IsEnabled = false;
            }
            else
            {
                btnLapDonHang.IsEnabled = false;
                btnQuayVeDonHang.IsEnabled = true;
                btnDenCuaHang.IsEnabled = true;
            }
            cv_LapDonHang.Visibility = Visibility.Collapsed;
        }

        private void btnLuu_LapDonHang_Click(object sender, RoutedEventArgs e)
        {
            isLapDonHang = 0;
            uscGiaoDich_Loaded(sender, e);
        }

        private void btnHuy_LapDonHang_Click(object sender, RoutedEventArgs e)
        {
            isLapDonHang = 0;
            uscGiaoDich_Loaded(sender, e);
            int mode = 0;
            if (BUS_GD.getSoLuongSPTrongSPDH(maDHCur_LapDonHang) > 0)//đơn hàng đã có sản phẩm
            {
                mode = 1;
            }
            else
            {
                mode = 0;
            }
            if (BUS_GD.xoaDonHang(maDHCur_LapDonHang, mode))
            {
                dtgrCacDonHang_Loaded(sender, e);
            }
            else
            {
                // MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnThanhToan_LapDonHang_Click(object sender, RoutedEventArgs e)
        {
            isLapDonHang = 0;
            uscGiaoDich_Loaded(sender, e);
            if(BUS_GD.thanhToanDonHang(maDHCur_LapDonHang))
            {

            }
            else
            {
                MessageBox.Show("Thanh toán thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void cv_LapDonHang_Loaded(object sender, RoutedEventArgs e)
        {
            if (maDHCur_LapDonHang != 0)
            {
                DataTable dttbLapDonHang = BUS_GD.getDonHangMoiTao(maDHCur_LapDonHang);
                txbMaDH_LapDonHang.Text = dttbLapDonHang.Rows[0][0].ToString();
                var x = DateTime.Parse(dttbLapDonHang.Rows[0][1].ToString());
                dtpkNgay_LapDonHang.SelectedDate = x;                
            }
        }

        private void btnQuayVeDonHang_Click(object sender, RoutedEventArgs e)
        {
            cv_CacDonHang.Visibility = Visibility.Collapsed;
            cv_LapDonHang.Visibility = Visibility.Visible;
        }

        private void btnDenCuaHang_Click(object sender, RoutedEventArgs e)
        {
            btnSanPham_Click(sender, e);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            int mode = 0;
            if (BUS_GD.getSoLuongSPTrongSPDH(maDHCur_LapDonHang) > 0)//đơn hàng đã có sản phẩm
            {
                mode = 1;
            }
            else
            {
                mode = 0;
            }
            if (BUS_GD.xoaDonHang(maDHCur_LapDonHang, mode))
            {

            }
            else
            {
                // MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

