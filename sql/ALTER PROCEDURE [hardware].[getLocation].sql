USE [dbase1]
GO
/****** Object:  StoredProcedure [hardware].[getLocation]    Script Date: 22.01.2021 17:00:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		S.P.G.
-- Create date: 17.
-- Description:	Получение настроек
-- Editor:		Molotkova_IS
-- Edit date:	28-04-2020
-- Description:	Сортировка по алфавиту
-- =============================================
ALTER PROCEDURE [hardware].[getLocation]	
AS
BEGIN
SET NOCOUNT ON


SELECT
	l.id,l.cName,l.isActive,l.id_object, o.cName as nameObject
FROM 
	hardware.s_Location l
		left join hardware.s_Object o on o.id = l.id_object
ORDER BY l.cName


END	
