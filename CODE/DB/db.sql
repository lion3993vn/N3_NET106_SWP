/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[IsMainAddress] [bit] NULL,
 CONSTRAINT [PK__Address__3214EC074F7046C4] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AgeGroupProduct]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgeGroupProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AgeRange] [nvarchar](250) NULL,
 CONSTRAINT [PK__AgeGroup__3214EC07A8D27E3F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](250) NULL,
	[Logo] [nvarchar](max) NULL,
	[BrandDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK__Brand__3214EC079B39557F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](500) NULL,
 CONSTRAINT [PK__Category__3214EC07644223FC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Comment] [nvarchar](500) NULL,
	[Rating] [int] NULL,
	[Date] [datetime2](7) NULL,
 CONSTRAINT [PK__Feedback__3214EC07E0A2CFC9] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TotalPrice] [int] NULL,
	[Address] [nvarchar](500) NOT NULL,
	[Note] [nvarchar](max) NULL,
	[AmountDiscount] [int] NULL,
	[Status] [nvarchar](250) NULL,
	[Date] [datetime] NULL,
	[PaymentId] [int] NULL,
	[DeliveryStatus] [nvarchar](250) NULL,
 CONSTRAINT [PK__Order__3214EC077E9989C3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Price] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK__OrderDet__3214EC07BF4BE7FD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Origin]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Origin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OriginName] [nvarchar](250) NULL,
 CONSTRAINT [PK__Origin__3214EC072BFD6020] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Otp]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Otp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[OTPCode] [int] NOT NULL,
	[OTPTime] [datetime] NOT NULL,
	[IsUsed] [bit] NOT NULL,
 CONSTRAINT [PK__OTP__3214EC079B39557F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[Status] [nvarchar](250) NULL,
	[Method] [nvarchar](100) NULL,
	[Code] [int] NULL,
 CONSTRAINT [PK__Payment__3214EC072E9667DA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PointMoney]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PointMoney](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MinPoints] [int] NULL,
	[AmountDiscount] [int] NULL,
 CONSTRAINT [PK__PointMon__3214EC076B2C3B19] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Title] [nvarchar](500) NULL,
	[Banner] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Date] [datetime] NULL,
	[UnsignTitle] [nvarchar](500) NULL,
 CONSTRAINT [PK__Post__3214EC0772DC9C94] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CateId] [int] NULL,
	[ProductName] [nvarchar](500) NULL,
	[Price] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[Weight] [int] NULL,
	[IsActive] [bit] NULL,
	[Quantity] [int] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[AgeId] [int] NULL,
	[OriginId] [int] NULL,
	[BrandId] [int] NULL,
	[UnsignProductName] [nvarchar](500) NULL,
 CONSTRAINT [PK__Product__3214EC07F9237F13] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Refund]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Refund](
	[OrderId] [int] NOT NULL,
	[Reason] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Status] [nvarchar](500) NULL,
 CONSTRAINT [PK__Refund__C3905BCF300B2A7A] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NULL,
 CONSTRAINT [PK__Role__3214EC070DE1BF62] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/13/2024 9:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[RoleId] [int] NULL,
	[Fullname] [nvarchar](250) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Avatar] [nvarchar](250) NULL,
	[GoogleId] [nvarchar](max) NULL,
	[PhoneNumber] [varchar](10) NULL,
	[Status] [bit] NULL,
	[Points] [int] NULL,
	[UnsignName] [nvarchar](250) NULL,
	[ConfirmEmail] [bit] NOT NULL,
	[TokenConfirmEmail] [nvarchar](250) NULL,
 CONSTRAINT [PK__User__3214EC0785EC007A] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT (N'') FOR [Address]
GO
ALTER TABLE [dbo].[Otp] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsUsed]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (CONVERT([bit],(0))) FOR [ConfirmEmail]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK__Address__UserId__66603565] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK__Address__UserId__66603565]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK__Feedback__Produc__6754599E] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK__Feedback__Produc__6754599E]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK__Feedback__UserId__68487DD7] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK__Feedback__UserId__68487DD7]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Order__PaymentId__6A30C649] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payment] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Order__PaymentId__6A30C649]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Order__UserId__6B24EA82] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Order__UserId__6B24EA82]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__Order__6C190EBB] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK__OrderDeta__Order__6C190EBB]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__Produ__6D0D32F4] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK__OrderDeta__Produ__6D0D32F4]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK__Post__UserId__6E01572D] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK__Post__UserId__6E01572D]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__AgeId__6EF57B66] FOREIGN KEY([AgeId])
REFERENCES [dbo].[AgeGroupProduct] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__AgeId__6EF57B66]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__BrandId__6FE99F9F] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__BrandId__6FE99F9F]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__CateId__70DDC3D8] FOREIGN KEY([CateId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__CateId__70DDC3D8]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__OriginI__71D1E811] FOREIGN KEY([OriginId])
REFERENCES [dbo].[Origin] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__OriginI__71D1E811]
GO
ALTER TABLE [dbo].[Refund]  WITH CHECK ADD  CONSTRAINT [FK__Refund__OrderId__72C60C4A] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[Refund] CHECK CONSTRAINT [FK__Refund__OrderId__72C60C4A]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK__User__RoleId__73BA3083] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK__User__RoleId__73BA3083]
GO
