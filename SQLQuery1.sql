CREATE DATABASE QuanLyBanHang
GO
USE QuanLyBanHang
GO
ALTER DATABASE QuanLyBanHang set TRUSTWORTHY ON; 
GO 
EXEC dbo.sp_changedbowner @loginame = N'sa', @map = false 
GO 
sp_configure 'show advanced options', 1; 
GO 
RECONFIGURE; 
GO 
sp_configure 'clr enabled', 1; 
GO 
RECONFIGURE;
GO
--1. Tao bang SanPham
CREATE TABLE SANPHAM
(
MaSanPham int identity(0,1) not null,
TenSanPham nvarchar(45) not null,
FileAnh nvarchar(45) not null,
GiaBanSanPham bigint not null,
GiaMuaSanPham bigint not null,
TinhTrang int not null,
MaLoaiSanPham int not null,
SoLuong int not null,
constraint PK_SANPHAM primary key(MaSanPham)
)

--2. Tao bang LoaiSanPham
CREATE TABLE LOAISANPHAM
(
MaLoaiSanPham int identity(0,1) not null,
TenLoaiSanPham nvarchar(45) not null,
constraint PK_LOAISANPHAM  primary key(MaLoaiSanPham)
)

--3.Tao bang SANPHAM_DONHANG
create table SANPHAM_DONHANG
(
MaDonHang int not null,
MaSanPham int not null,
SoLuong int not null,
constraint PK_SANPHAM_DONHANG primary key(MaDonHang,MaSanPham)
)

--4. Tao bang DONHANG
create table DONHANG
(
MaDonHang int identity(0,1) not null,
TenKhachHang nvarchar(45) not null,
NgayBan datetime not null,
ThanhToan int not null,--0.Chưa thanh tóa 1.Thanh Toán rồi
TongTien bigint not null,
constraint PK_DONHANG primary key(MaDonHang)
)

--5. Tao bang KHUYENMAI
create table KHUYENMAI
(
MaKhuyenMai int identity(0,1) not null,
MaSanPham int not null,
PhanTram int not null,
NgayBatDau datetime not null,
NgayKetThuc datetime not null,
constraint PK_KHUYENMAI primary key(MaKhuyenMai)
)

--Tao khoa ngoai
alter table SANPHAM add 
	Constraint FK_SANPHAM_LOAISANPHAM foreign key (MaLoaiSanPham) references LOAISANPHAM(MaLoaiSanPham)

alter table SANPHAM_DONHANG add 
	Constraint FK_SANPHAM_DONHANG_SANPHAM foreign key (MaSanPham) references SANPHAM(MaSanPham),
	Constraint FK_SANPHAM_DONHANG_DONHANG foreign key (MaDonHang) references DONHANG(MaDonHang)

alter table KHUYENMAI add 
	Constraint FK_KHUYENMAI_SANPHAM foreign key (MaSanPham) references SANPHAM(MaSanPham)


--Nhập giá trị
insert into LOAISANPHAM values(N'Dầu ăn')
insert into LOAISANPHAM values(N'Dầu gội đầu')
insert into LOAISANPHAM values(N'Nước giặc')
insert into LOAISANPHAM values(N'Nước mắm')

delete SANPHAM

insert into SANPHAM values (N'Dầu ăn Neptune','F:\Images\DauAnNeptune.jpg',130000,100000,1,0,20)
insert into SANPHAM values (N'Dầu ăn Ranee','F:\Images\DauAnRanee.jpg',30000,27000,1,0,30)
insert into SANPHAM values (N'Dầu gội Pantene','F:\Images\DauGoiDauPantene.jpg',48000,40000,1,1,40)
insert into SANPHAM values (N'Dầu gội HeadAndShoulders','F:\Images\DauGoiDauHeadAndShoulders.jpg',50000,45000,1,1,50)
insert into SANPHAM values (N'Dầu gội Thorakao','F:\Images\DauGoiDauThorakao.jpg',35000,30000,1,1,50)
insert into SANPHAM values (N'Nước giặc Ariel','F:\Images\NuocGiacAriel.jpg',180000,150000,1,2,40)
insert into SANPHAM values (N'Nước giặc Caremore','F:\Images\NuocGiacCaremore.jpg',170000,160000,1,2,20)
insert into SANPHAM values (N'Nước mắm Đệ nhị','F:\Images\NuocMamDeNhi.jpg',170000,160000,1,3,20)
insert into SANPHAM values (N'Nước mắm Hạnh Phúc','F:\Images\NuocMamHanhPhuc.jpg',30000,26000,1,3,20)
insert into SANPHAM values (N'Nước mắm Kakom','F:\Images\NuocMamKakom.jpg',24000,20000,1,3,20)


--12. Tao bang account
CREATE TABLE TAIKHOAN
(
MaTaiKhoan int identity(0,1) not null,
Username nvarchar(45) not null,
Pass nvarchar(45) not null,
LoaiNhanVien int not null,
MaNhanVien int not null,
constraint PK_TAIKHOAN primary key (MaTaiKhoan)
)
insert into TAIKHOAN values ('admin','1234',0,0)
insert into TAIKHOAN values ('user1','1234',1,1)
insert into TAIKHOAN values ('user2','1234',1,2)
insert into TAIKHOAN values ('user3','1234',1,3)

--1.Tao bang nhanvien
CREATE TABLE NHANVIEN
(
MaNhanVien int identity(0,1) not null,
Ten nvarchar(45) not null,
SoDienThoai char(13) not null,
constraint PK_NHANVIEN  primary key(MaNhanVien)
)
insert into NHANVIEN values (N'Nguyễn Văn A','123456789')
insert into NHANVIEN values (N'Nguyễn Văn B','123456788')
insert into NHANVIEN values (N'Nguyễn Thị C','123456777')
insert into NHANVIEN values (N'Trần Văn D','123456666')
