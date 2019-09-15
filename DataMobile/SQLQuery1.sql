Create Database DataMobile
Use DataMobile
Create Table LineProduct
(
	lineid int Identity(1,1) PRIMARY key,
	linename nvarchar(300),
	linenote nvarchar(500),
	createday datetime,
	picture nvarchar(20) 
)
Create Table Supplier
(
	supplierid int identity(1,1)primary key ,
	suppliername nvarchar(100),
	address nvarchar(500),
	phonenumber nvarchar(10),	
)

Create Table Product
(
	productid int Identity(1,1),
	nameproduct nvarchar(300),
	note nvarchar(500),
	picture nvarchar(20),
	total int ,
	price bigint,
	createday Datetime,
	lineid int,
	supplierid int,
	primary key(productid),
    foreign key (lineid) references LineProduct(lineid),
	foreign key (supplierid) references Supplier(supplierid),
)
Create Table Customer
(
	customerid int Identity(1,1),
	namecustomer nvarchar(50),
	phonenumber nvarchar(10),
	email nvarchar(30),
	address nvarchar(500),
	primary key(customerid),
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
	foreign key(customerid) references Customer(customerid),

)
Create Table DetailOrder
(
	detailorderid int identity(1,1),
	total int,
	price bigint,
	discount bigint,
	orderid int,
	productid int,
	primary key (detailorderid),
	foreign key(orderid) references Orders(orderid),
	foreign key(productid) references Product(productid),
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
--alter table Users add phonenumber nvarchar(10)