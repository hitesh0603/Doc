

------------------------- Sign Up table-------------------

create table signup_document
(
userid int IDENTITY(1,1) PRIMARY KEY,
Firstname varchar(50),
Lastname varchar (50),
EmailId varchar(50),
Loginpassword varchar(50),
Contactno varchar(50),
FOREIGN KEY (userid) REFERENCES  signup_document(userid)
);




------------ document details----------------------

create table user_documetlist
(
Userdocno int IDENTITY(1,1) PRIMARY KEY,
Documetname VARCHAR(50),
Cardno VARCHAR(20),
Createdate VARCHAR(max),
Expirydate VARCHAR(max),
ImgFileName VARCHAR(MAX),
imgType VARCHAR(MAX),
imgContentLength VARCHAR(MAX),
imgInputStream VARBINARY(max)
);


------------------------------------------------

create table imgupload
(
ID int Primary Key identity,
imgfile varbinary(max)
)
drop table imgupload
select * from imgupload