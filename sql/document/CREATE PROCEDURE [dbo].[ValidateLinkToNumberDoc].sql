USE [DocumentsDZ]
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

CREATE PROCEDURE [dbo].[ValidateLinkToNumberDoc] 
	@number int,
	@date date,
	@idBase int
AS
BEGIN

--IF exists (select TOP(1) id from Repair.j_RequestRepair where Number = @number and YEAR(DateSubmission)=YEAR(@date)) and @idBase = 3
--	BEGIN
--		select cast(1 as bit) as rowIsExists
--		return
--	END

IF exists (select TOP(1) id from dbo.documents d left join [dbo].[s_orders] r on r.id_doc = d.id
	where d.id_doctype in (47,48) and r.id_user_exec in (1,2,5,6,7) and   d.no_doc = @number and YEAR(d.date_create)=YEAR(@date)) and @idBase = 2
	BEGIN
		select cast(1 as bit) as rowIsExists
		return
	END

--IF exists (select TOP(1) id from [ServiceRecords].[j_ListServiceRecords] where Number = @number and YEAR(ConfirmationD)=YEAR(@date)) and @idBase = 1
--	BEGIN
--		select cast(1 as bit) as rowIsExists
--		return
--	END

select cast(0 as bit) as rowIsExists

END
