Create database QuanLyKho
go

Use QuanLyKho
Go

Create table Unit
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max) ,
)

go

Create table Suplier
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max) ,
	Address nvarchar(max) ,
	Phone nvarchar(20),
	Email nvarchar(200),
	MoreInfo nvarchar(Max),
	ContractDate DateTime,

	
)

go

Create table Customer
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max) ,
	Address nvarchar(max) ,
	Phone nvarchar(20),
	Email nvarchar(200),
	MoreInfo nvarchar(Max),
	ContractDate DateTime,

	
)

go

Create table Object
(
	Id nvarchar(128) primary key,
	DisplayName nvarchar(max) ,
	IdUnit int ,
	IdSpulier int,
	QRCode nvarchar(max),
	BarCode nvarchar(Max)


	foreign key(IdUnit) references Unit(Id),
	foreign key(IdSpulier) references Suplier(Id)
)
go

Create table UsersRole
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max) ,
	
)

go

insert into UsersRole (DisplayName) values (N'Admin')
go
insert into UsersRole (DisplayName) values (N'Nhân viên')
go


Create table Users
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max) ,
	UserName nvarchar(100) ,
	Password nvarchar(100) ,
	QRCode nvarchar(max),
	BarCode nvarchar(Max),
	IdRole int not null

	foreign key(IdRole) references UsersRole(Id)
)
go


insert into Users (DisplayName, UserName, Password, IdRole) values (N'Oanhdv', N'Admin', N'admin', 1)
go
insert into Users (DisplayName, UserName, Password, IdRole) values (N'Nhân viên', N'Staff', N'Staff', 2)
go

Create table Input
(
	Id nvarchar(128)  primary key,
	DateInput DateTime
)
go


Create table InputInfor
(
	Id nvarchar(128)  primary key,
	IdObject nvarchar(128) not null,
	IdInput nvarchar(128) not null,
	Count int,
	InputPrice float default 0,
	OutputPrice  float default 0,
	Status nvarchar(max)

	foreign key(IdObject) references Object(Id),
	foreign key(IdInput) references Input(Id)
)
go

Create table Output
(
	Id nvarchar(128)  primary key,
	DateInput DateTime
)
go

Create table OutputInfor
(
	Id nvarchar(128)  primary key,
	IdObject nvarchar(128) not null,
	IdOutput nvarchar(128) not null,
	IdCustomer int not null,
	Count int,
	Status nvarchar(max)


	foreign key(IdObject) references Object(Id),
	foreign key(IdOutput) references Output(Id),
	foreign key(IdCustomer) references Customer(Id)
)
go

