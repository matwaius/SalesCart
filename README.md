# Project made to add products to a shopping cart, select the customer, and send it to the back-end for recording.

## Project setup
```
npm install
```

### Compiles and hot-reloads for development
```
npm run serve
```

### Compiles and minifies for production
```
npm run build
```

### Lints and fixes files
```
npm run lint
```

### Customize configuration
See [Configuration Reference](https://cli.vuejs.org/config/).

### SQL
```
USE master
IF OBJECT_ID('TESTE') > 0 DROP database TESTE
GO
Create database TESTE
GO
USE TESTE
IF OBJECT_ID('Product') > 0 DROP TABLE dbo.Product
GO
CREATE TABLE dbo.Product(
	id int IDENTITY(1,1) NOT NULL,
	name varchar(255) NOT NULL,
	description varchar(100) NOT NULL,
	price Decimal(16,7) NOT NULL,
	created datetime2(7) NOT NULL,
CONSTRAINT productID PRIMARY KEY CLUSTERED 
(
	id ASC
))
GO
insert into dbo.Product values('Produto 1','Produto 1',1, getdate())
insert into dbo.Product values('Produto 2','Produto 2',2, getdate())
insert into dbo.Product values('Produto 3','Produto 3',3, getdate())
insert into dbo.Product values('Produto 4','Produto 4',4, getdate())
insert into dbo.Product values('Produto 5','Produto 5',5, getdate())


IF OBJECT_ID('Customer') > 0 DROP TABLE dbo.Customer
GO
CREATE TABLE dbo.Customer(
	id int IDENTITY(1,1) NOT NULL,
	name varchar(255) NOT NULL,
	login varchar(20) NOT NULL,
	password varchar(20) NOT NULL,
 CONSTRAINT customerID PRIMARY KEY CLUSTERED 
(
	id ASC
))
GO
insert into dbo.Customer values('Usuario 1','1','1')
insert into dbo.Customer values('Usuario 2','2','2')
insert into dbo.Customer values('Usuario 3','3','3')
insert into dbo.Customer values('Usuario 4','4','4')
insert into dbo.Customer values('Usuario 5','5','5')

IF OBJECT_ID('Orders') > 0 DROP TABLE dbo.Orders
GO
CREATE TABLE dbo.Orders(
	id int IDENTITY(1,1) NOT NULL,
	customerID int NOT NULL,
	total_order decimal(16,7) NOT NULL,
	created_at datetime2(7) NOT NULL,
	comments varchar(255) NOT NULL,
 CONSTRAINT OrdersID PRIMARY KEY CLUSTERED 
(
	id
))
GO
alter table dbo.Orders with check add constraint fk_customer_id FOREIGN KEY (customerID) References dbo.Customer (id)
IF OBJECT_ID('Order_Product') > 0 DROP TABLE dbo.Order_Product
GO
CREATE TABLE dbo.Order_Product(
	orderID int NOT NULL,
	productID int NOT NULL,
	quantity integer NOT NULL,
	created_at datetime2(7) NOT NULL,
	unit_price decimal(16,7) NOT NULL,
	total_price decimal(16,7) NOT NULL,
 CONSTRAINT OrderProductID PRIMARY KEY CLUSTERED 
(
	orderID,
	productID
))
GO
alter table dbo.Order_Product with check add constraint fk_product_id FOREIGN KEY (productID) References dbo.Product (id)
alter table dbo.Order_Product with check add constraint fk_order_id FOREIGN KEY (orderID) References dbo.Orders (id)
```
