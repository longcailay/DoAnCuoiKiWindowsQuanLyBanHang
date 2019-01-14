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
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Data;
using DTO;
using BUS;
namespace _1612205
{
    /// <summary>
    /// Interaction logic for WinThemSP.xaml
    /// </summary>
    public partial class WinThemSP : Window
    {
        public WinThemSP()
        {
            InitializeComponent();
        }
        BUS_SanPham BUS_SP = new BUS_SanPham();
        string imgLoc1,imgLoc2="";  //cái 1 là để kiểm tra và gán vào image source, cái 2 để ghi lên database     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImFileAnh.Visibility = Visibility.Visible;
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.DefaultExt = ".png";
                dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";               
                dlg.Title = "Select Phone Image";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {

                    //chuyển từ string path tới image source
                    imgLoc1 = dlg.FileName.ToString();
                    imgLoc2 = imgLoc1;
                    string temp = "";
                    for (int i=0; i<imgLoc1.Length; i++)
                    {                        
                        if ( imgLoc1[i] == '\\')
                        {
                            temp += "/";
                        }
                        else
                        {
                            temp += imgLoc1[i].ToString();
                        }
                        
                    }                    
                    var converter = new ImageSourceConverter();
                    ImFileAnh.Source = (ImageSource)converter.ConvertFromString(temp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void cleanWindow()
        {
            txbGiaBan.Text = txbGiaMua.Text = txbSoLuong.Text = txbTenSanPham.Text = "";
            cbxLoaiSP.Text = "";
            cbxLoaiSP.Visibility = Visibility.Collapsed;          
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (txbTenSanPham.Text == ""|| txbGiaBan.Text == "" || txbGiaMua.Text == "" || txbSoLuong.Text == "" || cbxLoaiSP.SelectedIndex == -1)
            {
                MessageBox.Show("Xin nhập vào không đầy đủ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            //kiểm tra các trường dữ liệu đầu vào
            if (txbGiaBan.Text.All(char.IsDigit) == false || txbGiaBan.Text.All(char.IsDigit) == false || Int32.Parse(txbGiaBan.Text) < 0 || Int32.Parse(txbGiaMua.Text) < 0)
            {
                MessageBox.Show("Giá tiền không hợp lệ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbGiaBan.Text = txbGiaMua.Text = "";
                return;
            }

            if(Int32.Parse(txbGiaBan.Text) < Int32.Parse(txbGiaMua.Text))
            {
                MessageBox.Show("Giá bán phải lớn hơn giá mua!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (txbSoLuong.Text.All(char.IsDigit) == false || Int32.Parse(txbSoLuong.Text) < 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbSoLuong.Text = "";
                return;
            }

            if (imgLoc2 == "")
            {
                MessageBox.Show("Vui lòng chọn ảnh!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            int loaiSanPham;
            Int32.TryParse(cbxLoaiSP.SelectedValue.ToString(),out loaiSanPham);
            MessageBox.Show(loaiSanPham.ToString());
            DTO_SanPham SP = new DTO_SanPham(0, txbTenSanPham.Text, imgLoc2, Int32.Parse(txbGiaBan.Text), Int32.Parse(txbGiaMua.Text), 1, loaiSanPham, Int32.Parse(txbSoLuong.Text));
            if (BUS_SP.themSanPham(SP))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                cleanWindow();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
                  
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void cbxLoaiSP_AccessKeyPressed(object sender, AccessKeyPressedEventArgs e)
        {

        }

        private void cbxLoaiSP_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = BUS_SP.getLoaiSanPham();
            cbxLoaiSP.ItemsSource = dataTable.DefaultView;
            cbxLoaiSP.DisplayMemberPath = "TenLoaiSanPham";
            cbxLoaiSP.SelectedValuePath = "MaLoaiSanPham";
        }

        private void cbxLoaiSP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) return;
               DataRowView dataRowView =(DataRowView)e.AddedItems[0];              
        }
    }
}
