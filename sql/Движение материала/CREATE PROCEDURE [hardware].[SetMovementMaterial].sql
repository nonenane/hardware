USE [dbase1]
GO
/****** Object:  StoredProcedure [dbo].[getListTovar]    Script Date: 21.01.2021 11:39:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<SPorykhin G.Y.>
-- Create date: <2021-01-21>
-- Description:	<Запись движения расходных материалов>
-- =============================================

CREATE PROCEDURE [hardware].[SetMovementMaterial] 
	@id int,
	@id_tMovementMaterial int,
	@id_Material int,
	@Count numeric(16,3),
	@id_Responsible int,	
	@Comment varchar(max),
	@id_user int 
AS
BEGIN

BEGIN TRY 
	--IF exists(select TOP(1) id from hardware.j_MovementMaterial where id_tMovementMaterial = @id_tMovementMaterial and id_Material = @id_Material and id <> @id)
	--	BEGIN
	--		select -1 as id, 'Дублирование записи.\n' as msg
	--		return
	--	END

IF @id = -1
	BEGIN
		INSERT INTO hardware.j_MovementMaterial (id_tMovementMaterial,id_Material,Count,id_Responsible,Comment,id_Editor,DateEdit)
		VALUES (@id_tMovementMaterial,@id_Material,@Count,@id_Responsible,@Comment,@id_user,GETDATE())

		select  cast(SCOPE_IDENTITY() as int) as id
	END
ELSE
	BEGIN
		UPDATE 
			hardware.j_MovementMaterial
		SET
			id_tMovementMaterial = @id_tMovementMaterial,
			id_Material = @id_Material,
			Count = @Count,
			id_Responsible = @id_Responsible,
			Comment= @Comment,
			id_Editor=@id_user,
			DateEdit=GETDATE()
		WHERE
			id =@id 

		select @id as id
	END
END TRY 
BEGIN CATCH 
	SELECT -9999 as id,ERROR_MESSAGE() as msg
	return;
END CATCH


END
