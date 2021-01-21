USE [dbase1]
GO
/****** Object:  StoredProcedure [dbo].[getListTovar]    Script Date: 21.01.2021 11:39:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<AKU>
-- Create date: <2021-01-21>
-- Description:	<Получение списка базовых типов по движению материала>
-- =============================================

CREATE PROCEDURE [hardware].[GetTypeBasic] 

AS
BEGIN

select 
	id,
	cName,
	isActive 
from 
	[hardware].[s_TypeBasic] 

END
