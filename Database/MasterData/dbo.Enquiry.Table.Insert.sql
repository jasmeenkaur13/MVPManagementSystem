USE [CarSales]
GO
SET IDENTITY_INSERT [dbo].[Enquiry] ON 

INSERT [dbo].[Enquiry] ([EnquiryId], [CarId], [Name], [PhoneNumber], [Email]) VALUES (1, 1, N'Huy', N'0987676523', N'abc@gmail.com')
INSERT [dbo].[Enquiry] ([EnquiryId], [CarId], [Name], [PhoneNumber], [Email]) VALUES (2, 1, N'Nuy', N'0986765454', N'cyv@gmail.com')
SET IDENTITY_INSERT [dbo].[Enquiry] OFF
