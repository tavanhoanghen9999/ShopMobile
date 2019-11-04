Create Database DataMobile
Use DataMobile
Create Table LineProducts
(
	lineid int Identity(1,1) PRIMARY key,
	linename nvarchar(300),
	linenote nvarchar(500),
	createday datetime,
	picture nvarchar(20) 
)
Create Table Suppliers
(
	supplierid int identity(1,1)primary key ,
	suppliername nvarchar(100),
	address nvarchar(500),
	phonenumber nvarchar(10),
	picture nvarchar(20),	
)

Create Table Products
(
	productid int Identity(1,1),
	nameproduct nvarchar(300),
	note nvarchar(500),
	picture nvarchar(20),
	total int ,
	price bigint,
	createday Datetime,
	lineid int,
	discount bigint,
	supplierid int,
	primary key(productid),
    foreign key (lineid) references LineProducts(lineid),
	foreign key (supplierid) references Suppliers(supplierid),
)

Create Table Orders
(
	orderid int Identity(1,1),
	nameorder nvarchar(30),
	createday Datetime,
	daydelivery Datetime,
	address nvarchar(500),
	phonenumber nvarchar(10),
	sumprice bigint,
	customerid int,
	primary key(orderid),
	foreign key(customerid) references Customers(customerid),

)
Create Table DetailOrders
(
	detailorderid int identity(1,1),
	total int,
	price bigint,
	discount bigint,
	orderid int,
	productid int,
	primary key (detailorderid),
	foreign key(orderid) references Orders(orderid),
	foreign key(productid) references Products(productid),
)
 Create Table Customers
(
	customerid int Identity(1,1),
	namecustomer nvarchar(50),
	phonenumber nvarchar(10),
	email nvarchar(30),
	address nvarchar(500),
	primary key(customerid),
	picture nvarchar(20),

) 
Create Table Roles
(
	roleid int identity(1,1) primary key,
	rolename nvarchar(50),
)
Create Table Users
(
	userid int identity(1,1) primary key,
	username nvarchar(50),
	email nvarchar(50),
	address nvarchar(500),
	createday Datetime,
	password nvarchar(500),
	roleid int,
	foreign key(roleid) references Roles(roleid),
)

alter table  Suppliers add email nvarchar(50)
 alter table  Suppliers add activity bit
alter table  Suppliers add createday Datetime
alter table orders add email nvarchar(30)
alter table orders add activity bit
alter table DetailOrders add activity bit
alter table  Customers add activity bit
alter table  Products add activity big



SELECT GETDATE()