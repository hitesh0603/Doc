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

CREATE PROCEDURE sp_Uploaduserocument
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

INSERT INTO user_documetlist( Documetname, Cardno, Createdate, Expirydate, ImgFileName,imgType,imgContentLength,imgInputStream)

VALUES ( @Documetname, @Cardno, @Createdate, @Expirydate, @ImgFileName,@imgType,@imgContentLength,@imgInputStream)

GO



sp_helptext sp_Uploaduserocument 

select * from user_documetlist
-----------------------------------------View Documents---------------------

USE PRACTISE
GO
CREATE PROCEDURE sp_ViewImage

AS
SET NOCOUNT ON;
select *
from user_documetlist
 





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
