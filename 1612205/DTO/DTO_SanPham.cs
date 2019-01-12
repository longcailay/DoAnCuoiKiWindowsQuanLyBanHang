using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_SanPham
    {
        private int _maSanPham;
        private string _tenSanPham;
        private string _tenFile;
        private int _giaBanSanPham;
        private int _giaMuaSanPham;
        private int _tinhTrang;
        private int _maLoaiSanPham;
        private int _soLuong;

        public int MASANPHAM
        {
            get
            {
                return _maSanPham;
            }
            set
            {
                _maSanPham = value;
            }
        }
        public string TENSANPHAM
        {
            get
            {
                return _tenSanPham;
            }
            set
            {
                _tenSanPham = value;
            }
        }
        public string TENFILE
        {
            get
            {
                return _tenFile;
            }
            set
            {
               _tenFile= value;
            }
        }
        public int GIABANSANPHAM
        {
            get
            {
                return _giaBanSanPham;
            }
            set
            {
                _giaBanSanPham = value;
            }
        }

        public int GIAMUASANPHAM
        {
            get
            {
                return _giaMuaSanPham;
            }
            set
            {
                _giaMuaSanPham = value;
            }
        }

        public int TINHTRANG
        {
            get
            {
                return _tinhTrang;
            }
            set
            {
                _tinhTrang = value;
            }
        }

        public int MALOAISANPHAM
        {
            get
            {
                return _maLoaiSanPham;
            }
            set
            {
                _maLoaiSanPham = value;
            }
        }

        public int SOLUONG
        {
            get
            {
                return _soLuong;
            }
            set
            {
                _soLuong = value;
            }
        }
        public DTO_SanPham()
        {

        }
        public DTO_SanPham(int maSanPham,string tenSanPham,string tenFile,int giaBanSanPham,int giaMuaSanPham,int tinhTrang, int maLoaiSanPham, int soLuong)
        {
            this.MASANPHAM = maSanPham;
            this.TENSANPHAM = tenSanPham;
            this.TENFILE = tenFile;
            this.GIABANSANPHAM = giaBanSanPham;
            this.GIAMUASANPHAM = giaMuaSanPham;
            this.TINHTRANG = tinhTrang;
            this.MALOAISANPHAM = maLoaiSanPham;
            this.SOLUONG = soLuong;
        }
    }
}
