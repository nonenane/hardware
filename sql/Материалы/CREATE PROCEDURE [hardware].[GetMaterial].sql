USE [dbase1]
GO
/****** Object:  StoredProcedure [dbo].[getListTovar]    Script Date: 21.01.2021 11:39:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<SPorykhin G.Y.>
-- Create date: <2021-01-22>
-- Description:	<Получение списка материалов>
-- =============================================

ALTER PROCEDURE [hardware].[GetMaterial] 	
AS
BEGIN

	select 
		mm.id,
		mm.id_Units,
		mm.cName,
		u.cName as cNameUnit,
		mm.isActive
	from 
		hardware.s_Material mm 
			left join hardware.s_Units u on u.id = mm.id_Units
	
END
