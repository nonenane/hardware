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

ALTER PROCEDURE [hardware].[SetTMovementMaterial] 
	@id int,
	@DateMovement date,
	@id_TypeOperation int,
	@YearBasis date,
	@NumberBase varchar(max),
	@idBasis int,
	@Comment varchar(max),
	@id_user int 
AS
BEGIN

BEGIN TRY 
	IF exists(select TOP(1) id from hardware.j_tMovementMaterial where DateMovement = @DateMovement and id_TypeOperation = @id_TypeOperation and YearBasis =@YearBasis and NumberBase=@NumberBase and idBasis=@idBasis and id <> @id)
		BEGIN
			select -1 as id, 'Дублирование записи.\n' as msg
			return
		END

IF @id = -1
	BEGIN
		INSERT INTO hardware.j_tMovementMaterial (DateMovement,id_TypeOperation,YearBasis,NumberBase,idBasis,Comment,id_Editor,DateEdit)
		VALUES (@DateMovement,@id_TypeOperation,@YearBasis,@NumberBase,@idBasis,@Comment,@id_user,GETDATE())

		select  cast(SCOPE_IDENTITY() as int) as id
	END
ELSE
	BEGIN
		UPDATE 
			hardware.j_tMovementMaterial
		SET
			DateMovement = @DateMovement,
			id_TypeOperation = @id_TypeOperation,
			YearBasis =@YearBasis,
			NumberBase=@NumberBase,
			idBasis=@idBasis,
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
