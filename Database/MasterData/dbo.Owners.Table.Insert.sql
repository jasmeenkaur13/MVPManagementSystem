USE [CarSales]
GO
SET IDENTITY_INSERT [dbo].[Owners] ON 

INSERT [dbo].[Owners] ([Id], [Name], [PhoneNumber], [Email], [DealerABN], [OwnerType], [Comments]) VALUES (1, N'Jasmeen', N'098768690', N'abc@yahoo.com', NULL, N'P', NULL)
INSERT [dbo].[Owners] ([Id], [Name], [PhoneNumber], [Email], [DealerABN], [OwnerType], [Comments]) VALUES (2, N'Taran', N'098682681', N'tdr@yahoo.com', N'345135', N'D', NULL)
INSERT [dbo].[Owners] ([Id], [Name], [PhoneNumber], [Email], [DealerABN], [OwnerType], [Comments]) VALUES (3, N'Jatin', N'096527612', N'jat@gmail.com', NULL, N'P', NULL)
SET IDENTITY_INSERT [dbo].[Owners] OFF
