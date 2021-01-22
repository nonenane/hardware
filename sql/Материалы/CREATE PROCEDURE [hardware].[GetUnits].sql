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
-- Description:	<Получение списка едииниц измерения>
-- =============================================

CREATE PROCEDURE [hardware].[GetUnits] 	
AS
BEGIN

	select 
		u.id,
		u.cName,
		u.isActive
	from 
		hardware.s_Units u
	
END
