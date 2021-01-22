USE [dbase1]
GO
/****** Object:  StoredProcedure [Goods_Card_New].[spg_setSubject]    Script Date: 30.11.2020 15:34:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2021-01-22
-- Description:	Запись справочника материалов
-- =============================================
ALTER PROCEDURE [hardware].[SetMaterial]			 
	@id int,
	@cName varchar(max),
	@id_unit int,
	@isActive bit,
	@id_user int,
	@result int = 0,
	@isDel int	
AS
BEGIN
	SET NOCOUNT ON;

BEGIN TRY 
	IF @isDel = 0
		BEGIN			
			IF EXISTS (select TOP(1) id from [hardware].[s_Material] where id <>@id and LTRIM(RTRIM(LOWER(cName))) = LTRIM(RTRIM(LOWER(@cName))))
				BEGIN
					SELECT -1 as id,'В справочнике уже присутствует\n тип расходного материала с таким наименованием.\n' as msg;
					return;
				END
		

			IF @id = 0
				BEGIN
					INSERT INTO [hardware].[s_Material]
						   ([cName]
						   ,[id_Units]						   
						   ,[isActive]
						   ,[id_Editor]
						   ,[DateEdit])
					 VALUES
						   (@cName,
						   @id_unit,
						   1,
						   @id_user,
						   GETDATE())

					SELECT  cast(SCOPE_IDENTITY() as int) as id
					return;
				END
			ELSE
				BEGIN					
					UPDATE 
							[hardware].[s_Material]
					SET		[cName] = @cName
						   ,[id_Units] = @id_unit
						   ,[isActive] = @isActive
						   ,[id_Editor] = @id_user
						   ,[DateEdit]=GETDATE()
					where id = @id
										
					SELECT @id as id
					return;					
				END
		END
	ELSE
		BEGIN
			IF @result = 0
				BEGIN
					
					IF NOT EXISTS(select TOP(1) id from [hardware].[s_Material] where id = @id)
						BEGIN
							select -1 as id
							return;
						END

					
					IF EXISTS(select TOP(1) id from [hardware].[j_MovementMaterial] where id_Material = @id)
						BEGIN
							select -2 as id
							return;
						END
					
					select 0 as id
					return;
				END
			ELSE
				BEGIN
					DELETE FROM [hardware].[s_Material]  where id = @id
					RETURN
				END
		END
END TRY 
BEGIN CATCH 
	SELECT -9999 as id,ERROR_MESSAGE() as msg
	return;
END CATCH
	
END
