USE [master]
GO

/****** Object:  Database [CarSales]    Script Date: 5/09/2018 2:12:10 PM ******/
CREATE DATABASE [CarSales]


USE [CarSales]
GO

/****** Object:  Table [dbo].[AdvertisedCars]    Script Date: 5/09/2018 2:12:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AdvertisedCars](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Year] [varchar](4) NOT NULL,
	[Make] [varchar](50) NOT NULL,
	[Model] [varchar](50) NOT NULL,
	[AdvertisedPriceType] [varchar](4) NOT NULL,
	[ECGAmount] [numeric](10, 2) NULL,
	[DAPAmount] [numeric](10, 2) NULL,
	[AdvertisedAmount] [numeric](16, 2) NULL,
 CONSTRAINT [PK_AdvertisedCars] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Owners]    Script Date: 5/09/2018 2:13:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Owners](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[PhoneNumber] [varchar](10) NULL,
	[Email] [varchar](50) NULL,
	[DealerABN] [varchar](50) NULL,
	[OwnerType] [varchar](50) NOT NULL,
	[Comments] [nvarchar](max) NULL,
 CONSTRAINT [PK_Owners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Owners_Cars_Ref]    Script Date: 5/09/2018 2:14:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Owners_Cars_Ref](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OwnerId] [int] NOT NULL,
	[CarId] [int] NOT NULL,
 CONSTRAINT [PK_Owners_Cars_Ref] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Owners_Cars_Ref]  WITH CHECK ADD  CONSTRAINT [FK_Car_Owner_Ref] FOREIGN KEY([CarId])
REFERENCES [dbo].[AdvertisedCars] ([ID])
GO

ALTER TABLE [dbo].[Owners_Cars_Ref] CHECK CONSTRAINT [FK_Car_Owner_Ref]
GO

ALTER TABLE [dbo].[Owners_Cars_Ref]  WITH CHECK ADD  CONSTRAINT [FK_Owner_Car_Ref] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Owners] ([Id])
GO

ALTER TABLE [dbo].[Owners_Cars_Ref] CHECK CONSTRAINT [FK_Owner_Car_Ref]
GO




