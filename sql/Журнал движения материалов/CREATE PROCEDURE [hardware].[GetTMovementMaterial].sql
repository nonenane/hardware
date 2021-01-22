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
-- Description:	<ѕолучение  списка движений по материалу>
-- =============================================

ALTER PROCEDURE [hardware].[GetTMovementMaterial] 	
	@dateStart date,
	@dateEnd date
AS
BEGIN

select 
	m.id,
	m.DateMovement,
	m.id_TypeOperation,
	m.idBasis,
	m.YearBasis,
	m.NumberBase,
	m.Comment,
	t.cName as nameType,
	mm.Count,
	isnull(trim(k.lastname)+' ','')+isnull(trim(k.firstname)+' ','')+isnull(trim(k.secondname),'') as cNameMol
	,m.DateEdit,
	l.FIO
from 
	hardware.j_tMovementMaterial m
		left join hardware.s_TypeOperation t on t.id = m.id_TypeOperation
		LEFT join dbo.ListUsers l on l.id = m.id_Editor

		left join hardware.j_MovementMaterial mm on mm.id_tMovementMaterial = m.id
		left join hardware.s_Responsible r	on r.id = mm.id_Responsible	
		left join dbo.s_kadr k on k.id = r.id_Kadr
where 
	@dateStart<= m.DateMovement and m.DateMovement<=@dateEnd
	
END
