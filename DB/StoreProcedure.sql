------------------Sign Up --------------------

GO  
CREATE PROCEDURE sp_userRegistration
	@Firstname varchar(50),
	@Lastname varchar(50),
	@EmailId varchar(50),
	@Loginpassword varchar(50),
	@Contactno varchar(50)
	 
AS   

    SET NOCOUNT ON;  
    INSERT INTO signup_document( Firstname, Lastname, EmailId ,Loginpassword, Contactno)
     
    VALUES ( @Firstname , @Lastname , @EmailId , @Loginpassword , @Contactno)
    
GO  


sp_helptext sp_userRegistration 


-----------------------Login --------------------------------

GO
CREATE PROCEDURE sp_userAuthentication
@EmailId varchar(50),
@Loginpassword varchar(50)

AS

SET NOCOUNT ON;
SELECT EmailId , Loginpassword
FROM signup_document
WHERE EmailId = @EmailId AND Loginpassword = @Loginpassword

GO


sp_helptext sp_userAuthentication 


-----------------------Document Upload --------------------------------

Alter PROCEDURE sp_Uploaduserocument
@userid int,
@Documetname VARCHAR(50),
@Cardno VARCHAR(20),
@Createdate VARCHAR(max),
@Expirydate  VARCHAR(max),
@ImgFileName VARCHAR(MAX),
@imgType VARCHAR(MAX),
@imgContentLength VARCHAR(MAX),
@imgInputStream VARBINARY(max)
AS

SET NOCOUNT ON;

INSERT INTO user_documetlist(userid, Documetname, Cardno, Createdate, Expirydate, ImgFileName,imgType,imgContentLength,imgInputStream)

VALUES ( @userid, @Documetname, @Cardno, @Createdate, @Expirydate, @ImgFileName,@imgType,@imgContentLength,@imgInputStream)

GO



sp_helptext sp_Uploaduserocument 



-----------------------------------------View Documents---------------------
GO
CREATE PROCEDURE sp_ViewImage
@userid int,
@Userdocno int,
@Documetname varchar(50),
@imgInputStream VARBINARY(max)

AS

SET NOCOUNT ON;
SELECT Userdocno , userid,Documetname,imgInputStream
FROM user_documetlist
WHERE userid = @userid AND Userdocno = @Userdocno

GO


---------------------------------Demo -------------------------------------------------------------


USE Hitesh
GO
Alter PROCEDURE sp_imgupload
@imgfile varbinary(max)
AS

SET NOCOUNT ON;

INSERT INTO imgupload

VALUES (@imgfile)

GO

sp_helptext sp_imgupload 
