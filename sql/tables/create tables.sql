CREATE TABLE [hardware].[s_Material](
	[id]			int				IDENTITY(1,1) NOT NULL,
	[cName]			varchar(1024)	not null,
	[id_Units]		int				not null,
	[isActive]		bit				not null default 1,
	[id_Editor]		int				not null,
	[DateEdit]		datetime		not null,
 CONSTRAINT [PK_s_Material] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [hardware].[s_Units](
	[id]			int				IDENTITY(1,1) NOT NULL,
	[cName]			varchar(1024)	not null,	
	[isActive]		bit				not null default 1,
	[id_Editor]		int				not null,
	[DateEdit]		datetime		not null,
 CONSTRAINT [PK_s_Units] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [hardware].[s_Units] (cName,isActive,id_Editor,DateEdit) values ('метр',1,96,GETDATE()),('шт.',1,96,GETDATE())
GO

CREATE TABLE [hardware].[j_tMovementMaterial](
	[id]					int				IDENTITY(1,1) NOT NULL,
	[DateMovement]			date			not null,
	[id_TypeOperation]		int				not null,
	[idBasis]				int				null,
	[YearBasis]				date			null,
	[NumberBase]			varchar(max)	null,
	[Comment]				varchar(max)	null,
	[id_Editor]				int				not null,
	[DateEdit]				datetime		not null,
 CONSTRAINT [PK_j_tMovementMaterial] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [hardware].[j_MovementMaterial](
	[id]					int				IDENTITY(1,1) NOT NULL,
	[id_tMovementMaterial]	int				not null,
	[id_Material]			int				not null,
	[Count]					numeric (16,3)	not null,
	[id_Responsible]		int				not null,
	[Comment]				varchar(max)	null,	
	[id_Editor]				int				not null,
	[DateEdit]				datetime		not null,
 CONSTRAINT [PK_j_MovementMaterial] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [hardware].[s_TypeBasic](
	[id]			int				IDENTITY(1,1) NOT NULL,
	[cName]			varchar(1024)	not null,	
	[isActive]		bit				not null default 1,
	[id_Editor]		int				not null,
	[DateEdit]		datetime		not null,
 CONSTRAINT [PK_s_TypeBasic] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [hardware].[s_TypeBasic] (cName,isActive,id_Editor,DateEdit) values ('СЗ',1,96,GETDATE()),('ДО',1,96,GETDATE()),('ЗР',1,96,GETDATE())
GO


CREATE TABLE [hardware].[s_TypeOperation](
	[id]			int				IDENTITY(1,1) NOT NULL,
	[cName]			varchar(1024)	not null,	
	[isActive]		bit				not null default 1,
	[id_Editor]		int				not null,
	[DateEdit]		datetime		not null,
 CONSTRAINT [PK_s_TypeOperation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [hardware].[s_TypeOperation] (cName,isActive,id_Editor,DateEdit) values ('Закупка',1,96,GETDATE()),('Расход',1,96,GETDATE())
GO