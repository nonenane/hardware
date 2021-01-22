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
-- Description:	<�������� �������� �� ���������>
-- =============================================

ALTER PROCEDURE [hardware].[DelTMovementMaterial] 	
	@id int,
	@result int
AS
BEGIN

if(@result = 0)
	BEGIN
	IF NOT Exists (select top(1) id from hardware.j_tMovementMaterial where id = @id)
		begin
			select -1 as id, '������ ��� ������� ������ �������������.\n' as msg
			return;
		end
	else
		begin
			select 1 as id, '������ ��� ������� ������ �������������.\n' as msg
			return;
		end
	END
ELSE
	BEGIN
		DELETE FROM hardware.j_MovementMaterial where id_tMovementMaterial = @id
		DELETE FROM hardware.j_tMovementMaterial where id = @id
	END

END
