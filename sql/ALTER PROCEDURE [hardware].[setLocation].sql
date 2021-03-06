USE [dbase1]
GO
/****** Object:  StoredProcedure [hardware].[setLocation]    Script Date: 22.01.2021 17:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		S.P.G.
-- Create date: 17.
-- Description:	Получение настроек
-- =============================================
ALTER PROCEDURE [hardware].[setLocation]		
	@id int,
	@cName varchar(max),
	@id_object int,
	@type int,
	@isActive bit,
	@idUser int
AS
BEGIN
SET NOCOUNT ON

IF EXISTS ( SELECT * FROM hardware.s_Location WHERE id<>@id AND LOWER(cName) = LOWER(@cName) and id_object = @id_object) AND @type<>2
	BEGIN
		SELECT -2 as id
		return;
	END

BEGIN TRY
IF @id=-1
	BEGIN
		INSERT INTO hardware.s_Location (cName,isActive,DateCreate,DateEdit,id_Creator,id_Editor,id_object)
			 VALUES (@cName,@isActive,GETDATE(),GETDATE(),@idUser,@idUser,@id_object)
		SELECT SCOPE_IDENTITY() as id
	END
ELSE IF @id<> -1
	BEGIN
		IF @type = 1
			BEGIN
				UPDATE hardware.s_Location SET cName= @cName,isActive=@isActive, DateEdit=GETDATE(),id_Editor=@idUser,id_object = @id_object
					WHERE id = @id
				SELECT @id as id
			END
		ELSE IF @type=2
			BEGIN
				IF( EXISTS(select * from hardware.j_ContentReceivingTransfer where id_Location = @id ) OR EXISTS(select * from hardware.j_Hardware where id_Location = @id ))
				BEGIN
					UPDATE 
						hardware.s_Location 
					SET 
						isActive=case When isActive=1 then 0 else 1 end
					WHERE 
						id = @id
					SELECT -3 as id
				END
				ELSE
				BEGIN		
					DELETE FROM hardware.s_Location WHERE id = @id
					SELECT @id as id
				END
			END
	END
END TRY
BEGIN CATCH	
	SELECT -1 as id
END CATCH


END	
