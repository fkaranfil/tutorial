CREATE TABLE Company
(
CompanyID int,
CompanyName varchar(100),
CUserName varchar(100),
CUserPassword varchar(100),
CompanyEmail varchar(50),
CompanyPhone varchar(100),
CompanyAddress varchar(150),
CompanyRegisterTime varchar(50),
ContactFName varchar(100),
ContactLName varchar(100),
LoginType int

);


CREATE TABLE Product
(
ProductNo int,
ProductName varchar(100),
ProductDetails varchar(500),
ProductDate varchar(50),
CategoryID int,
ProductState varchar(100),
ProductImagePath varchar(500),
ProductPrice varchar(15),
CompanyID int

);

CREATE TABLE Orderr
(
OrderID int,
CustomerID int,
OrderDetails varchar(500),
OrderDate varchar(50)
);

CREATE TABLE Customer
(
CustomerID int,
CustomerFName varchar(100),
CustomerLName varchar(100),
CustomerEmail varchar(50),
CustomerPhone varchar(30),
CustomerAddress varchar(100),
);

CREATE TABLE Comment
(
CommentText varchar(200),
CommenterName varchar(20),
CommentDate varchar(50),
CommentId int,
ProductID int
);

CREATE TABLE Category
(
CategoryDescription varchar(200),
CategoryName varchar(100),
CategoryID int

);




