USE [dbase1]
GO
/****** Object:  StoredProcedure [hardware].[getReportHistory]    Script Date: 25.01.2021 10:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		SPG
-- Получение списка типа оборудования и компонентов
-- =============================================
ALTER PROCEDURE [hardware].[getReportHistory]
	@id_jHardWate int = 3757,
	@dateStart date = null,
	@dateEnd date = null,
	@type int  = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

select 
	id_jHardware,
	max(TypeComponentsHardware) as TypeComponentsHardware, 
	max(cName) as cName, 
	max(InventoryNumber) as InventoryNumber
INTO #TMP
from (
select 	
	 id_jHardware,
	 case when cName like 'Тип оборудования:' then valueOld end as TypeComponentsHardware,	 
	 case when cName like 'Наименование объекта:' then valueOld end as cName,
	 case when cName like 'Инв. номер:' then valueOld end as InventoryNumber 
from  
	[hardware].[j_ChangesHardware] 
where 
	isDelete = 1 and (id_jHardware = @id_jHardWate or @id_jHardWate = 0) ) as a
 group by id_jHardware
--GROUP BY id_jHardware

select 
	h.id,
	h.id_jHardware,
	ISNULL(w.cName,t.cName) as nameOb,
	ISNULL(w.InventoryNumber,t.InventoryNumber) as InventoryNumber,
	ISNULL(CASE WHEN w.TypeComponentsHardware = 0 THEN 'Оборудование' else 'Комплектующие' end,t.TypeComponentsHardware) as TypeComponentsHardware,
	h.cName,
	h.valueOld,
	h.valueNew,
	h.isDelete
	,convert(varchar(max),h.DateCreate,104)+' '+convert(varchar(5),h.DateCreate,108) as DateCreate,
	h.id_Creator,
	u.FIO,
	cast(case when t.id_jHardware is not null then 1 else 0 end as bit) as isDeleteRow,
	convert(varchar(max),w.DateCreate,104)+' '+convert(varchar(5),w.DateCreate,108) as DateCreateHardWare
	--,w.cName	
	--,w.TypeComponentsHardware
from	
	[hardware].[j_ChangesHardware] h
		left join dbo.ListUsers u on u.id = h.id_Creator
		left join hardware.j_Hardware w on w.id = h.id_jHardware
		LEFT JOIN #TMP t on t.id_jHardware = h.id_jHardware
where 
	(h.id_jHardware = @id_jHardWate or @id_jHardWate = 0) 
	AND ((@dateStart is null AND @dateEnd is null) OR (@dateStart<=cast(h.DateCreate as date) AND cast(h.DateCreate as date)<=@dateEnd))
	AND ((@type is null) OR (@type = 1 and h.isDelete = 0) OR  (@type = 2 and h.isDelete = 1) OR (@type =3))
order by h.id_jHardware asc, h.DateCreate desc


DROP TABLE #TMP


 
END
