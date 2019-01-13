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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string imgLoc = "";
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.DefaultExt = ".png";
                dlg.Filter = "All File (.)|*.*|JPEG Files (*.jpeg)|*.jpeg|(.jpg)|.jpg|PNG Files (*.png)|*.png|GIF Files (.gif)|.gif|(*.gif)|*.gif";
                //dlg.Filter = "JPG File (.jpg)|.jpg|GIF File (.gif)|.gif|All File (.)|*.*";
                dlg.Title = "Select Phone Image";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    imgLoc = dlg.FileName.ToString();
                    MessageBox.Show(imgLoc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
