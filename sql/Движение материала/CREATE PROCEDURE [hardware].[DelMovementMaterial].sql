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
-- Description:	<Удаление движения расходных материалов>
-- =============================================

CREATE PROCEDURE [hardware].[DelMovementMaterial] 
	@id int
AS
BEGIN

BEGIN TRY 
	
	DELETE FROM hardware.j_MovementMaterial where id = @id
	
END TRY 
BEGIN CATCH 
	SELECT -9999 as id,ERROR_MESSAGE() as msg
	return;
END CATCH


END
