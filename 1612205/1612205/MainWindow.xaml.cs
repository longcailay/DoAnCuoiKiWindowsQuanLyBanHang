using System;
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

        #region Usercontrol SanPham
        BUS_SanPham BUS_SP = new BUS_SanPham();

        private void btnSanPham_Click(object sender, RoutedEventArgs e)
        {
            uscBaoCao.Visibility = Visibility.Collapsed;
            uscGiaoDich.Visibility = Visibility.Collapsed;
            uscSanPham.Visibility = Visibility.Visible;
            
            
            
            
            
        }
        public void CapNhatGridViewSanPham(ListView lsvSanPham)
        {
           
            //= BUS_SP.getSanPham();
           
        }
        
        
        #region Lop san pham
        public class CSanPham
        {
            private string tenSanPham;
            private string tenFile;
            private int giaBanSanPham;
            private int soLuong;
            private int phanTram;
            private DateTime ngayBatDau;
            private DateTime ngayKetThuc;
            private int maSanPham;
            private int maLoaiSanPham;

            public string TenSanPham
            {
                set { tenSanPham = value; }
                get { return tenSanPham; }
            }
            public string TenFile
            {
                set { tenFile = value; }
                get { return tenFile; }
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
            public DateTime NgayBatDau
            {
                set { ngayBatDau = value; }
                get { return ngayBatDau; }
            }
            public DateTime NgayKetThuc
            {
                set { ngayKetThuc = value; }
                get { return ngayKetThuc; }
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
        }
        #endregion


        
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
        }

        private void lsvProduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //lsvProduct.ItemsSource=getS
        }

        private void st_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void txb_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void cv_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnThemSanPham_Click(object sender, RoutedEventArgs e)
        {
            DataTable m = BUS_SP.getSanPham();
            MessageBox.Show(m.Rows[1][1].ToString());
        }
    }
}
