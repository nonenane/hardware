USE [dbase1]
GO
/****** Object:  StoredProcedure [hardware].[getListHardWare]    Script Date: 25.01.2021 9:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		S.P.G.
-- Create date: 17.
-- Description:	Получение списка оборудования и комплектующих
-- =============================================
ALTER PROCEDURE [hardware].[getListHardWare]		
AS
BEGIN
SET NOCOUNT ON

CREATE TABLE #hardwareStatus (id int, cName varchar(max))
INSERT into #hardwareStatus
exec [hardware].[getStatus] 'hardwareStatus'

CREATE TABLE #typeHardWareStatus (id int, cName varchar(max))
INSERT into #typeHardWareStatus
exec [hardware].[getStatus] 'typeHardWare'


--select id_Hardware INTO #tmpHard from hardware.j_ContentWriteOff group by id_Hardware

SELECT
	c.*	
	,cast(0 as bit) as isSelect
	,(select count(*) from [hardware].[j_Scan] s where s.id_Journal=c.id and s.TypeScan=8) as scaneCount
	,l.cName as nameLocation		
	,isnull(ltrim(rtrim(k.lastname)),'')+
		isnull(' ' + ltrim(rtrim(k.firstname)),'')+
		isnull('  ' + ltrim(rtrim(k.secondname)),'') as FIO
	,hs.cName as nameStatus
	--,ths.cName as nameHardware
	,c.cName as nameHardware
	,DATEDIFF(day,c.DateEdit,getdate()) as cntDay
	--,tha.id_Hardware as writeActUse
	,case when lsr.inType = 1 then isnull(cast(lsr.Number as varchar(50)),'') else '' end as Number
	,cast(case when dateadd(month,isnull(c.WarrantyPeriod,0),cast(c.DatePurchase as date))>=cast(GETDATE() as date) then 1 else 0 end as bit) as isGarant
	,isnull(cast(YEAR(lsr.DateConfirmationD) as varchar(150)),'') as confYear
	,isnull(cast(lsr.DateConfirmationD as varchar(150)),'') as DateConfirmationD,
	cast(case when k.id_WorkStatus in (2,4,7) then 1 else 0 end as bit) as isWorkingNow,
	ob.cName as nameObject
FROM 
	hardware.j_Hardware c
		left join hardware.s_Location l on l.id=c.id_Location
		left join hardware.s_Object ob on ob.id = l.id_object
		left join hardware.s_Responsible r on r.id=c.id_Responsible
		left join s_kadr k on k.id = r.id_Kadr
		left join #hardwareStatus hs on hs.id= c.Status
		left join #typeHardWareStatus ths on ths.id= c.TypeComponentsHardware		
		left join ServiceRecords.j_ListServiceRecords lsr on lsr.id = c.id_ListServiceRecords
		--left join #tmpHard tha on tha.id_Hardware = c.id

drop table  #hardwareStatus,#typeHardWareStatus---,#tmpHard

END	
