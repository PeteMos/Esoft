CREATE DATABASE [Esoft]
GO
USE [Esoft]
GO
/****** Object:  Table [dbo].[Apartment]    Script Date: 29.01.2025 11:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HouseID] [int] NOT NULL,
	[Number] [varchar](10) NOT NULL,
	[Area] [float] NOT NULL,
	[CountOfRooms] [int] NOT NULL,
	[Section] [int] NOT NULL,
	[Floor] [int] NOT NULL,
	[IsSold] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CostDetails]    Script Date: 29.01.2025 11:56:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ApartmentID] [int] NOT NULL,
	[BuildingCost] [int] NOT NULL,
	[ValueAdded] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[House]    Script Date: 29.01.2025 11:56:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[House](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ResidentialComplexID] [int] NOT NULL,
	[StreetID] [int] NOT NULL,
	[Number] [varchar](10) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResidentialComplex]    Script Date: 29.01.2025 11:56:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResidentialComplex](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[City] [varchar](255) NOT NULL,
	[Status] [varchar](15) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Street]    Script Date: 29.01.2025 11:56:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Street](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Apartment] ON 

INSERT [dbo].[Apartment] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [IsDeleted]) VALUES (1, 1, N'1', 67.6, 2, 1, 1, 1, 0)
INSERT [dbo].[Apartment] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [IsDeleted]) VALUES (2, 1, N'2', 79.2, 3, 1, 1, 1, 0)
INSERT [dbo].[Apartment] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [IsDeleted]) VALUES (3, 2, N'320', 79.2, 3, 2, 15, 1, 0)
INSERT [dbo].[Apartment] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [IsDeleted]) VALUES (4, 2, N'321', 35.4, 1, 2, 15, 1, 0)
INSERT [dbo].[Apartment] ([ID], [HouseID], [Number], [Area], [CountOfRooms], [Section], [Floor], [IsSold], [IsDeleted]) VALUES (5, 2, N'322', 35.4, 1, 2, 15, 1, 0)
SET IDENTITY_INSERT [dbo].[Apartment] OFF
GO
SET IDENTITY_INSERT [dbo].[CostDetails] ON 

INSERT [dbo].[CostDetails] ([ID], [ApartmentID], [BuildingCost], [ValueAdded]) VALUES (1, 1, 11882000, 300000)
INSERT [dbo].[CostDetails] ([ID], [ApartmentID], [BuildingCost], [ValueAdded]) VALUES (2, 2, 13925000, 375000)
INSERT [dbo].[CostDetails] ([ID], [ApartmentID], [BuildingCost], [ValueAdded]) VALUES (3, 3, 13925000, 375000)
INSERT [dbo].[CostDetails] ([ID], [ApartmentID], [BuildingCost], [ValueAdded]) VALUES (4, 4, 7852000, 200000)
INSERT [dbo].[CostDetails] ([ID], [ApartmentID], [BuildingCost], [ValueAdded]) VALUES (5, 5, 7852000, 200000)
SET IDENTITY_INSERT [dbo].[CostDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[House] ON 

INSERT [dbo].[House] ([ID], [ResidentialComplexID], [StreetID], [Number], [IsDeleted]) VALUES (1, 1, 1, N'Г8', 0)
INSERT [dbo].[House] ([ID], [ResidentialComplexID], [StreetID], [Number], [IsDeleted]) VALUES (2, 1, 1, N'Г7', 0)
INSERT [dbo].[House] ([ID], [ResidentialComplexID], [StreetID], [Number], [IsDeleted]) VALUES (3, 1, 1, N'А2', 0)
INSERT [dbo].[House] ([ID], [ResidentialComplexID], [StreetID], [Number], [IsDeleted]) VALUES (4, 1, 1, N'А1', 0)
INSERT [dbo].[House] ([ID], [ResidentialComplexID], [StreetID], [Number], [IsDeleted]) VALUES (5, 1, 1, N'Б3', 0)
INSERT [dbo].[House] ([ID], [ResidentialComplexID], [StreetID], [Number], [IsDeleted]) VALUES (6, 1, 1, N'Б4', 0)
INSERT [dbo].[House] ([ID], [ResidentialComplexID], [StreetID], [Number], [IsDeleted]) VALUES (7, 2, 2, N'1.1', 0)
INSERT [dbo].[House] ([ID], [ResidentialComplexID], [StreetID], [Number], [IsDeleted]) VALUES (8, 2, 2, N'1.2', 0)
SET IDENTITY_INSERT [dbo].[House] OFF
GO
SET IDENTITY_INSERT [dbo].[ResidentialComplex] ON 

INSERT [dbo].[ResidentialComplex] ([ID], [Name], [City], [Status], [IsDeleted]) VALUES (1, N'Level Амурская', N'Москва', N'строительство', 0)
INSERT [dbo].[ResidentialComplex] ([ID], [Name], [City], [Status], [IsDeleted]) VALUES (2, N'Испанские кварталы', N'Москва', N'план', 0)
SET IDENTITY_INSERT [dbo].[ResidentialComplex] OFF
GO
SET IDENTITY_INSERT [dbo].[Street] ON 

INSERT [dbo].[Street] ([ID], [Name]) VALUES (1, N'Амурская')
INSERT [dbo].[Street] ([ID], [Name]) VALUES (2, N'Калужское шоссе')
SET IDENTITY_INSERT [dbo].[Street] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Street__737584F69A85C931]    Script Date: 29.01.2025 11:56:29 ******/
ALTER TABLE [dbo].[Street] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Apartment] ADD  DEFAULT ((0)) FOR [IsSold]
GO
ALTER TABLE [dbo].[Apartment] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[House] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ResidentialComplex] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Apartment]  WITH CHECK ADD  CONSTRAINT [FK_Apartment_House] FOREIGN KEY([HouseID])
REFERENCES [dbo].[House] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Apartment] CHECK CONSTRAINT [FK_Apartment_House]
GO
ALTER TABLE [dbo].[CostDetails]  WITH CHECK ADD  CONSTRAINT [FK_CostDetails_Apartment] FOREIGN KEY([ApartmentID])
REFERENCES [dbo].[Apartment] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[CostDetails] CHECK CONSTRAINT [FK_CostDetails_Apartment]
GO
ALTER TABLE [dbo].[House]  WITH CHECK ADD  CONSTRAINT [FK_House_ResidentialComplex] FOREIGN KEY([ResidentialComplexID])
REFERENCES [dbo].[ResidentialComplex] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [FK_House_ResidentialComplex]
GO
ALTER TABLE [dbo].[House]  WITH CHECK ADD  CONSTRAINT [FK_House_Street] FOREIGN KEY([StreetID])
REFERENCES [dbo].[Street] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [FK_House_Street]
GO
