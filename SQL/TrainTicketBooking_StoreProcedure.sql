
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE InsertUserDetail
	@UserId int,
	@UserName VARCHAR(20),
	@Gender varchar(10),
	@Age int,
	@Wallet int,
	@OPType varchar(5)	
AS
BEGIN
	
	SET NOCOUNT ON;

    
	If(@OPType='I')
	BEGIN 
		Insert into UserDetail values(@UserId,@UserName,@Gender,@Age,@Wallet)
	END
	ELSE
	BEGIN
		If(@OPType='U')
		BEGIN
		update UserDetail set UserName=@UserName,Gender=@Gender,Age=@Age,Wallet=@Wallet where UserId=@UserId
		END
		ELSE
		BEGIN
			If(@OPType='D')
			BEGIN
			delete UserDetail where UserId=@UserId
			END
		END

END
END
GO
