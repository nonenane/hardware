USE [dbase1]
GO
/****** Object:  StoredProcedure [dbo].[getListTovar]    Script Date: 21.01.2021 11:39:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Sporykhin G.Y.>
-- Create date: <2021-01-21>
-- Description:	<Получение списка активных МОЛ>
-- =============================================

ALTER PROCEDURE [hardware].[GetActiveMOL] 

AS
BEGIN

select 
	r.id,
	r.id_Kadr,
	isnull(trim(k.lastname)+' ','')+isnull(trim(k.firstname)+' ','')+isnull(trim(k.secondname),'') as cName,
	r.isActive
from 
	hardware.s_Responsible r		
		inner join dbo.s_kadr k on k.id = r.id_Kadr
where 
	k.id_WorkStatus in (2,4,7) and r.isActive = 1

END
