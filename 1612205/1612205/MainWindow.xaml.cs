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

        #region Usercontrol SanPham
        BUS_SanPham BUS_SP = new BUS_SanPham();        
        public List<CSanPham> LSanPham = new List<CSanPham>();     
               

        #region Lop san pham
        public class CSanPham
        {
            private string tenSanPham;
            private byte[] fileAnh;
            private BitmapImage fileAnhBitMap;
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
            public byte[] FileAnh
            {
                set { FileAnh = value; }
                get { return FileAnh; }
            }

            public BitmapImage FileAnhBitMap
            {
                set { FileAnhBitMap = value; }
                get { return FileAnhBitMap; }
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
            public CSanPham(string TenSanPham,byte[] FileAnh, int GiaBanSanPham,int SoLuong, int PhanTram,DateTime NgayBatDau,DateTime NgayKetThuc,int MaSanPham, int MaLoaiSanPham)
            {
                tenSanPham = TenSanPham;
                fileAnh = FileAnh;                
                giaBanSanPham = GiaBanSanPham;
                soLuong = SoLuong;
                phanTram = PhanTram;
                ngayBatDau = NgayBatDau;
                ngayKetThuc = NgayKetThuc;
                maSanPham = MaSanPham;
                maLoaiSanPham = MaLoaiSanPham;
            }

        }
        #endregion
        #region xu ly Image

            

        public BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        #endregion
        public void TaoMangCacSanPham(ref List<CSanPham> MangCacSanPham)
        {
            DataTable dttbSP = BUS_SP.getSanPham();
            for(int i = 0; i < dttbSP.Rows.Count; i++)//dttbSP.Rows.Count
            {
                 string tenSP = dttbSP.Rows[i][0].ToString();
                 byte[]  fileAnh = (byte[])dttbSP.Rows[i][1];
                 int giaBanSP;
                 Int32.TryParse(dttbSP.Rows[i][2].ToString(),out giaBanSP);
                 int soLuong;
                 Int32.TryParse( dttbSP.Rows[i][3].ToString(),out soLuong);
                 int phanTram;
                 Int32.TryParse(dttbSP.Rows[i][4].ToString(), out phanTram);
                 DateTime ngayBatDau;
                 DateTime.TryParse(dttbSP.Rows[i][5].ToString(),out ngayBatDau);
                 DateTime ngayKetThuc;
                 DateTime.TryParse(dttbSP.Rows[i][6].ToString(), out ngayKetThuc);
                 int maSP;
                 Int32.TryParse(dttbSP.Rows[i][7].ToString(),out maSP);
                 int maLoaiSP;
                 Int32.TryParse(dttbSP.Rows[i][8].ToString(),out maLoaiSP);               
                 MangCacSanPham.Add(new CSanPham(tenSP,fileAnh, giaBanSP, soLuong, phanTram, ngayBatDau, ngayKetThuc, maSP, maLoaiSP));
                                
            }            
        }       

        private void btnSanPham_Click(object sender, RoutedEventArgs e)
        {
            uscBaoCao.Visibility = Visibility.Collapsed;
            uscGiaoDich.Visibility = Visibility.Collapsed;
            uscSanPham.Visibility = Visibility.Visible;

        }
        public DataTable loadSanPham()
        {
            return BUS_SP.getSanPham();
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

       
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void cv_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnThemSanPham_Click(object sender, RoutedEventArgs e)
        {
            WinThemSP winThemSP = new WinThemSP();
            winThemSP.ShowDialog();
        }
        private void uscSanPham_Loaded(object sender, RoutedEventArgs e)
        {
            TaoMangCacSanPham(ref LSanPham);
            lsvProduct.ItemsSource = LSanPham;
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
        }

        
    }
}
