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
-- Description:	<Получение материалов для движения>
-- =============================================

ALTER PROCEDURE [hardware].[GetMovementMaterial] 	
	@id_tMovementMaterial int	
AS
BEGIN

	select 
		m.id,
		m.id_Responsible,
		m.Count,
		m.id_Material,		
		m.Comment,
		isnull(trim(k.lastname)+' ','')+isnull(trim(k.firstname)+' ','')+isnull(trim(k.secondname),'') as cName,
		mm.cName as nameMaterial,		
		u.cName as nameUnit
	from 
		hardware.j_MovementMaterial m
			left join hardware.s_Responsible r on r.id = m.id_Responsible
			left join dbo.s_kadr k on k.id = r.id_Kadr

			left join hardware.s_Material mm on mm.id = m.id_Material
			left join hardware.s_Units u on u.id = mm.id_Units
	where 
		id_tMovementMaterial = @id_tMovementMaterial
	
END
