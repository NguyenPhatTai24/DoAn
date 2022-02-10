create database ShopSQL
go 
use ShopSQL
go

create table DANGNHAP
(
	TenDangNhap varchar(20) primary key,
	MatKhau varchar(20),
)
create table NHANVIEN
(
	TenDangNhap varchar(20),
	HoTen nvarchar(50),
	GioiTinh nvarchar(10),
	CMND int primary key,
	NamSinh varchar(50),
	Email varchar(50),
	Sdt varchar(50),
	Stk varchar(50),
	QuanLy nvarchar(50),
	CONSTRAINT fk_nv_dn FOREIGN KEY (TenDangNhap) REFERENCES DANGNHAP(TenDangNhap)
)
create table CATRUC
(
    STT int primary key,
	TenDangNhap varchar(20),
	HoTen nvarchar(50),
	ThoiGianTruc date,
	CaTruc nvarchar(50),
	QuanLy nvarchar(50),
	CONSTRAINT fk_nv_ct FOREIGN KEY (TenDangNhap) REFERENCES DANGNHAP(TenDangNhap)
)
create table QUANLYCATRUC
(
	STT int primary key,
	Thu nvarchar(50),
	TenDangNhap varchar(20),
	HoTen nvarchar(50),
	ThoiGianTruc date,
	CaTruc nvarchar(50),
	QuanLy nvarchar(50),
	CONSTRAINT fk_nv_qlct FOREIGN KEY (TenDangNhap) REFERENCES DANGNHAP(TenDangNhap)
)
create table BIEN
(
	STT int primary key,
)
create table BIEN1
(
	STT int primary key,
)
create table LE
(
	NgayLe date,
)
create table LUONGTHEOCA
(
	TenDangNhap varchar(20) primary key,
	Luong int,
	CONSTRAINT fk_nv_ltc FOREIGN KEY (TenDangNhap) REFERENCES DANGNHAP(TenDangNhap)
)
create table LUONG
(
    TenDangNhap varchar(20),
	HoTen nvarchar(50),
	ThoiGianTruc date,
	CaTruc nvarchar(50),
	QuanLy nvarchar(50),
	Luong int,
	LuongLe int,
)
create table SANPHAM
(
	MaSP varchar(50) primary key,
	TenSP nvarchar(100),
	NhanHieu nvarchar(100),
	KhuyenMai int,
	KichCo varchar(50),
	Gia int,
	TonKho int,
	TenDangNhap varchar(20),
	CONSTRAINT fk_sp_ql FOREIGN KEY (TenDangNhap) REFERENCES DANGNHAP(TenDangNhap)
)
create table CTHD
(
    MaHD varchar(50),
	MaSP varchar(50),
	TenSP nvarchar(100),
	NhanHieu nvarchar(100),
	KhuyenMai int,
	KichCo varchar(50),
	SL int,
	Gia int,	
)
create table HD
(
	MaHD varchar(50),
	TenDangNhap varchar(20),
	NgayXuat date,
	TongTien int,
)
insert into BIEN1 values('20');
select * from NHANVIEN
delete from NHANVIEN
insert into DANGNHAP values ('NV01','0123456789');
insert into DANGNHAP values ('NV02','0123456789');
insert into DANGNHAP values ('QL01','0123456789');
select * from DANGNHAP
select * from DANGNHAP where TenDangNhap like 'NV%'
select TenDangNhap as N'Tên Đăng Nhập' , MatKhau as N'Mật Khẩu' from DANGNHAP where TenDangNhap like 'NV%' and MatKhau = '0123456789'
insert into NHANVIEN values ('NV01',N'Nguyễn Thị Đẹp',N'Nữ','0348255483','25/01/2000','depnguyen2512000@gmail.com','0348227483','9704 0354 2552 7914','QL01')
insert into NHANVIEN values ('NV02',N'Nguyễn Thị Xém Đẹp',N'Nữ','0348255484','26/01/2000','depxemnguyen2612000@gmail.com','0348227482','9704 0354 2552 7915','QL01')
select N.TenDangNhap as N'Mã nhân viên' , HoTen as N'Họ tên' from DANGNHAP D,NHANVIEN N where D.TenDangNhap = N.TenDangNhap
select * from CATRUC
Insert into CATRUC values(1,'"+dataGridView1.Rows[0].Cells[0].ToString()+"',N'"+dataGridView1.Rows[1].Cells[1].ToString()+"',N'"+dateTimePicker1.Value.ToString()+"',N'"+ca+"')
delete from CATRUC
select * from LUONGTHEOCA
delete from LUONGTHEOCA where TenDangNhap = 'NV05'
select CAST(ThoiGianTruc as ) from CATRUC
select CONVERT(varchar(10),ThoiGianTruc,103) AS [DD/MM/YYYY]
select CONVERT (varchar(10), getdate(), 103) AS [DD/MM/YYYY]
SELECT CONVERT(VARCHAR(10), ThoiGianTruc, 104)from CATRUC
select STT from CATRUC order by STT desc
delete from SANPHAM where MaSP = 'AQ0001'
select * from BIEN1
select * from SANPHAM
select C.TenDangNhap as 'Mã nhân viên',C.HoTen as 'Họ tên',C.ThoiGianTruc as 'Thời gian trực',C.CaTruc as 'Ca trực',C.QuanLy as 'Quản lý',L.Luong as 'Lương theo ca',LL.LuongLe as 'Lương lễ' from CATRUC C,LUONGTHEOCA L,LUONG LL where L.TenDangNhap = C.TenDangNhap and C.TenDangNhap ='NV01'
Select L.TenDangNhap as 'Mã nhân viên',N.HoTen as 'Họ tên',concat(L.Luong,N' đồng')  as 'Lương theo ca' from LUONGTHEOCA L, NHANVIEN N where L.TenDangNhap = N.TenDangNhap

select C.TenDangNhap as 'Mã nhân viên',C.HoTen as 'Họ tên',C.ThoiGianTruc as 'Thời gian trực',C.CaTruc as 'Ca trực',C.QuanLy as 'Quản lý',C.LuongTheoCa = case ThoiGianTruc when 2021-04-01 then C.LuongTheoCa * 110 / 100 END from CATRUC C,LUONGTHEOCA L where L.TenDangNhap = C.TenDangNhap and C.TenDangNhap = 'NV01'
update LUONGTHEOCA set Luong = Luong/10
select LEFT(MaSP,4) from SANPHAM where MaSP like 'AQ01%'
select * from DANGNHAP
delete from CTHD where MaHD = 'HD3'
select * from CTHD
delete from CTHD
delete from HD
delete from LUONGTHEOCA
delete from LUONG
select case len(MaHD)when 8 then RIGHT(MaHD,6) when 7 then RIGHT(MaHD,5) when 6 then RIGHT(MaHD,4) when 5 then RIGHT(MaHD,3) when 4 then RIGHT(MaHD,2) when 3 then RIGHT(MaHD,1)  when 0 then RIGHT(MaHD,0) end from HD