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
-- Description:	<Поиск данных по движению товара>
-- =============================================

ALTER PROCEDURE [hardware].[FindMovementMaterial] 	
	@idBasis int,
	@NumberBase int,
	@YearBasis date
AS
BEGIN

select 
	m.id,
	m.DateMovement,
	mat.cName+' '+u.cName as nameMat,
	isnull(trim(k.lastname)+' ','')+isnull(trim(k.firstname)+' ','')+isnull(trim(k.secondname),'') as cNameMol,
	mm.Count,
	mm.Comment,
	m.id_TypeOperation,
	t.cName as nameType,
	m.DateEdit,
	l.FIO
from 
	hardware.j_tMovementMaterial m 
		left join dbo.ListUsers l on l.id = m.id_Editor
		left join hardware.s_TypeOperation t on t.id = m.id_TypeOperation
		left join hardware.j_MovementMaterial mm on mm.id_tMovementMaterial = m.id
		left join hardware.s_Responsible r	on r.id = mm.id_Responsible	
		left join dbo.s_kadr k on k.id = r.id_Kadr

		left join hardware.s_Material mat	on mat.id = mm.id_Material	
		left join hardware.s_Units u on u.id = mat.id_Units		
		
where 
	idBasis =@idBasis and m.NumberBase = @NumberBase and m.YearBasis = @YearBasis
	
END
