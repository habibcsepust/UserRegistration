

CREATE DATABASE UserRegitration


USE UserRegitration


CREATE TABLE TblCountry(
Id INT IDENTITY(1,1) PRIMARY KEY,
countryName VARCHAR(100)
)

INSERT INTO TblCountry(countryName) Values ('Bangladesh')
INSERT INTO TblCountry(countryName) Values ('India')
INSERT INTO TblCountry(countryName) Values ('Saudi Arabia')
INSERT INTO TblCountry(countryName) Values ('Pakistan')


select * from TblCountry



CREATE TABLE TblCity(
Id INT IDENTITY(1,1) PRIMARY KEY,
cityName VARCHAR(50),
CountryId INT
)

select * from TblCity

INSERT INTO TblCity(cityName,CountryId) Values ('Dhaka',1)
INSERT INTO TblCity(cityName,CountryId) Values ('Mokka',3)
INSERT INTO TblCity(cityName,CountryId) Values ('Korachi',4)
INSERT INTO TblCity(cityName,CountryId) Values ('Dilhe',2)




SELECT top 10 CONCAT(fName,+' '+lName) as name,tu.phoneNo as phone, tu.emailNo as email, tc.cityName as city, tblc.countryName as country from TblUsers tu
	left join TblCity tc ON tu.userCity = tc.Id
	left join TblCountry tblc ON tu.countryName = tblc.Id where tu.emailNo = 'admin@admin.com'


select * from TblCountry

select * from TblCity

select * from TblUsers 



	SELECT OrderNumber, CompanyName, ProductName
  FROM Product P
  JOIN Supplier S ON S.Id = P.SupplierId
  JOIN OrderItem I ON P.Id = I.ProductId
  JOIN [Order] O ON O.Id = I.OrderId
 ORDER BY OrderNumber

select * from TblUsers 



CREATE TABLE TblUsers(
Id i,
fName VARCHAR(100),
lName VARCHAR(100),
phoneNo VARCHAR(15),
emailNo VARCHAR(250),
userCity INT,
countryName INT,
userImg VARCHAR(3000),
userCV VARCHAR(3000),
password VARCHAR(500),
dob datetime,
Gender VARCHAR(10),
)

select * from TblUsers 

INSERT INTO TblUsers(Id,fName, lName,phoneNo,emailNo,userCity,countryName,userImg, userCV, password, dob,Gender) Values (0000001,'Habibur','Rahman','01750752424','h@gmail.com',2,1,'file/sjkdks.jpg','file/sjkdks.doc','12345',convert(datetime,'18-06-12 10:34:09 PM',5),'male')
INSERT INTO TblUsers(Id,fName, lName,phoneNo,emailNo,userCity,countryName,userImg, userCV, password, dob,Gender) Values (0000002,'Habibur','Rahman','01750752424','h@gmail.com',3,2,'file/sjkdks.jpg','file/sjkdks.doc','12345',convert(datetime,'18-06-12 10:34:09 PM',5),'female')
INSERT INTO TblUsers(Id,fName, lName,phoneNo,emailNo,userCity,countryName,userImg, userCV, password, dob,Gender) Values (0000001,'Habibur','Rahman','01750752424','h@gmail.com',2,4,'file/sjkdks.jpg','file/sjkdks.doc','12345',convert(datetime,'18-06-12 10:34:09 PM',5),'male')
INSERT INTO TblUsers(Id,fName, lName,phoneNo,emailNo,userCity,countryName,userImg, userCV, password, dob,Gender) Values (0000002,'admin','admin','01750752424','admin@admin.com',3,3,'file/sjkdks.jpg','file/sjkdks.doc','@123@',convert(datetime,'18-06-12 10:34:09 PM',5),'female')

   

DROP TABLE TblUsers




select * from TblCountry

select * from TblCity

select * from TblUsers  






select max(Id) from TblUsers

