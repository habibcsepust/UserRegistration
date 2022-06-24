

CREATE DATABASE UserRegitration


USE UserRegitration


CREATE TABLE TblCountry(
Id INT IDENTITY(1,1) PRIMARY KEY,
countryName VARCHAR(100)
)

INSERT INTO TblCountry(countryName) Values ('Bangladesh')
INSERT INTO TblCountry(countryName) Values ('India')

drop table TblCountry

select * from TblCountry



CREATE TABLE TblCity(
Id INT IDENTITY(1,1) PRIMARY KEY,
cityName VARCHAR(50),
CountryId INT
)

select * from TblCity


drop table TblCity

INSERT INTO TblCity(cityName,CountryId) Values ('Dhaka',1)
INSERT INTO TblCity(cityName,CountryId) Values ('Chittagong',1)
INSERT INTO TblCity(cityName,CountryId) Values ('New Delhi',2)
INSERT INTO TblCity(cityName,CountryId) Values ('ModdhaPradesh',2)


INSERT INTO TblUsers(Id,fName, lName,phoneNo,emailNo,userCity,userImg, userCV, password,dob,Gender)
VALUES(37,'AAA','BBB','017507525285','jjmin@admin.com',4,'','','123','2/6/1993 12:00:00 AM','others')



select * from TblCountry

select * from TblCity

select * from TblUsers 

SELECT userCV from TblUsers WHERE Id = 26


UPDATE TblCity SET
	CountryId = 1
WHERE CountryId = 1
 --Id IN(1,2)

UPDATE TblUsers SET 
	fName = 'Habibur', lName='Rahman'
	, phoneNo='01750752424',emailNo='habibcsepust@gmail.com'
	, userCity = 2,userImg = '',userCV = ''
	,password = '123', dob='',Gender='male'
WHERE Id = 19 


	SELECT OrderNumber, CompanyName, ProductName
  FROM Product P
  JOIN Supplier S ON S.Id = P.SupplierId
  JOIN OrderItem I ON P.Id = I.ProductId
  JOIN [Order] O ON O.Id = I.OrderId
 ORDER BY OrderNumber

select * from TblUsers 



CREATE TABLE TblUsers(
Id int,
fName VARCHAR(100),
lName VARCHAR(100),
phoneNo VARCHAR(15),
emailNo VARCHAR(250),
userCity INT,
userImg VARCHAR(3000),
userCV VARCHAR(3000),
password VARCHAR(500),
dob datetime,
Gender VARCHAR(10),
)

select * from TblUsers 

INSERT INTO TblUsers(Id,fName, lName,phoneNo,emailNo,userCity,userImg, userCV, password, dob,Gender) Values (0000001,'Habibur','Rahman','01750752424','h@gmail.com',2,'files/c.jpg','file/sjkdks.doc','12345',convert(datetime,'18-06-12 10:34:09 PM',5),'male')
INSERT INTO TblUsers(Id,fName, lName,phoneNo,emailNo,userCity,userImg, userCV, password, dob,Gender) Values (0000002,'Habibur','Rahman','01750752424','h@gmail.com',3,'files/b.jpg','file/sjkdks.doc','12345',convert(datetime,'18-06-12 10:34:09 PM',5),'female')
INSERT INTO TblUsers(Id,fName, lName,phoneNo,emailNo,userCity,userImg, userCV, password, dob,Gender) Values (0000001,'Habibur','Rahman','01750752424','h@gmail.com',2,'files/a.jpg','file/sjkdks.doc','12345',convert(datetime,'18-06-12 10:34:09 PM',5),'male')
INSERT INTO TblUsers(Id,fName, lName,phoneNo,emailNo,userCity,userImg, userCV, password, dob,Gender) Values (0000002,'admin','admin','01750752424','admin@admin.com',3,'files/files/dd.docx','file/sjkdks.doc','@123@',convert(datetime,'18-06-12 10:34:09 PM',5),'female')

   

DROP TABLE TblUsers


USE UserRegitration
go

select * from TblCountry

select * from TblCity

select * from TblUsers  


select CONCAT(fName,+' '+lName) as name,tuser.phoneNo as phone, tuser.emailNo as email, tuser.dob as dob,tuser.userCity as city ,tuser.userImg as Image,tuser.userCV as CV, tcountry.countryName, tcity.cityName as City from TblUsers tuser left join TblCity tcity on tuser.userCity = tcity.Id left join TblCountry tcountry on tcountry.Id = tcity.CountryId




select tuser.Id as id, CONCAT(fName,+' '+lName) as name,tuser.fName as fName
,tuser.lName as lName,tuser.phoneNo as phone,tuser.Gender as Gender, tuser.emailNo as email
, tuser.dob as dob,tuser.userImg as Image,tuser.userCV as CV, tcountry.countryName as country
, tcity.cityName as city from TblUsers tuser 

left join TblCity tcity on tuser.userCity = tcity.Id 
left join TblCountry tcountry on tcountry.Id = tcity.CountryId






select max(Id) from TblUsers

