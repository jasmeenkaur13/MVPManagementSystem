USE [CarSales]
GO
SET IDENTITY_INSERT [dbo].[AdvertisedCars] ON 

INSERT [dbo].[AdvertisedCars] ([ID], [Year], [Make], [Model], [AdvertisedPriceType], [ECGAmount], [DAPAmount], [AdvertisedAmount]) VALUES (1, N'2017', N'maruti', N'swift', N'ECG', CAST(23454.00 AS Numeric(10, 2)), NULL, NULL)
INSERT [dbo].[AdvertisedCars] ([ID], [Year], [Make], [Model], [AdvertisedPriceType], [ECGAmount], [DAPAmount], [AdvertisedAmount]) VALUES (2, N'2018', N'maruti', N'sx4', N'DAP', NULL, CAST(2345.00 AS Numeric(10, 2)), NULL)
INSERT [dbo].[AdvertisedCars] ([ID], [Year], [Make], [Model], [AdvertisedPriceType], [ECGAmount], [DAPAmount], [AdvertisedAmount]) VALUES (3, N'1990', N'mercedes', N'c-200', N'ECG', CAST(2345.00 AS Numeric(10, 2)), NULL, NULL)
SET IDENTITY_INSERT [dbo].[AdvertisedCars] OFF
