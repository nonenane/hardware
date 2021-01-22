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
-- Description:	<ѕолучение списка остатков материалов>
-- =============================================

ALTER PROCEDURE [hardware].[GetMetrialOstOnDate] 	
	@date date
AS
BEGIN


DECLARE @tableNowOst table (id_Material int, Count numeric(16,3),id_Responsible int)
DECLARE @tableDateOst table (id_Material int, Count numeric(16,3),id_Responsible int)

INSERT INTO @tableNowOst
select 
	a.id_Material,
	sum(a.Count) as Count,
	a.id_Responsible
from(
select 
	mm.id_Material,
	sum(mm.Count) as Count,
	mm.id_Responsible
from 
	hardware.j_MovementMaterial  mm
		left join hardware.j_tMovementMaterial m on m.id = mm.id_tMovementMaterial
where 
	m.id_TypeOperation = 1 and m.DateMovement<=GETDATE()
group by 
	mm.id_Material,mm.id_Responsible
UNION ALL
select 
	mm.id_Material,
	-1*sum(mm.Count) as Count,
	mm.id_Responsible
from 
	hardware.j_MovementMaterial  mm
		left join hardware.j_tMovementMaterial m on m.id = mm.id_tMovementMaterial
where
	m.id_TypeOperation = 2 and m.DateMovement<=GETDATE()
group by 
	mm.id_Material,mm.id_Responsible) as a
group by a.id_Material,a.id_Responsible


INSERT INTO @tableDateOst
select 
	a.id_Material,
	sum(a.Count) as Count,
	a.id_Responsible
from(
select 
	mm.id_Material,
	sum(mm.Count) as Count,
	mm.id_Responsible
from 
	hardware.j_MovementMaterial  mm
		left join hardware.j_tMovementMaterial m on m.id = mm.id_tMovementMaterial
where 
	m.id_TypeOperation = 1 and m.DateMovement<=@date
group by 
	mm.id_Material,mm.id_Responsible
UNION ALL
select 
	mm.id_Material,
	-1*sum(mm.Count) as Count,
	mm.id_Responsible
from 
	hardware.j_MovementMaterial  mm
		left join hardware.j_tMovementMaterial m on m.id = mm.id_tMovementMaterial
where
	m.id_TypeOperation = 2 and m.DateMovement<=@date
group by 
	mm.id_Material,mm.id_Responsible) as a
group by a.id_Material,a.id_Responsible

select 
	m.id,
	m.cName+' '+u.cName as cName,
	isnull(trim(k.lastname)+' ','')+isnull(trim(k.firstname)+' ','')+isnull(trim(k.secondname),'') as cNameMol,
	isnull(nOst.Count,0.000) as ostNow,
	isnull(dOst.Count,0.000) as ostDate,
	m.isActive
from 
	hardware.s_Material m		
		left join hardware.s_Units u on u.id = m.id_Units
		left join hardware.j_MovementMaterial mm on mm.id_Material = m.id
		left join hardware.s_Responsible r	on r.id = mm.id_Responsible	
		left join dbo.s_kadr k on k.id = r.id_Kadr
		left join @tableNowOst nOst on nOst.id_Material = m.id and nOst.id_Responsible = mm.id_Responsible
		left join @tableDateOst dOst on dOst.id_Material = m.id and dOst.id_Responsible = mm.id_Responsible
	
END
