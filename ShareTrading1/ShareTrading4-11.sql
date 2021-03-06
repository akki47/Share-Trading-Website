USE [ShareTrading]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 11/04/2013 04:21:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HouseNumber] [nvarchar](10) NOT NULL,
	[StreetNumber] [nvarchar](50) NOT NULL,
	[City] [nvarchar](20) NOT NULL,
	[Country] [nvarchar](20) NOT NULL,
	[Fax] [nvarchar](20) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 11/04/2013 04:21:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[SpecialQuestion] [nvarchar](100) NULL,
	[Answer] [nvarchar](50) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shares]    Script Date: 11/04/2013 04:21:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shares](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyId] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[StockExchangeId] [bigint] NULL,
	[FaceValue] [decimal](18, 2) NOT NULL,
	[QuantityInitial] [bigint] NOT NULL,
	[QuantityRemaining] [bigint] NOT NULL,
 CONSTRAINT [PK_Shares] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Portfolios]    Script Date: 11/04/2013 04:21:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Portfolios](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ShareId] [bigint] NOT NULL,
	[DateBought] [datetime] NOT NULL,
	[AveragePrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Portfolios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionHistories]    Script Date: 11/04/2013 04:21:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionHistories](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ShareId] [bigint] NOT NULL,
	[Mode] [int] NOT NULL,
	[NumberOfShares] [bigint] NOT NULL,
	[PricePerShare] [decimal](18, 2) NOT NULL,
	[ProfitPerShare] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_TransactionHistories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalDetails]    Script Date: 11/04/2013 04:21:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address1] [bigint] NOT NULL,
	[Address2] [bigint] NULL,
 CONSTRAINT [PK_PersonalDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/04/2013 04:21:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Points] [bigint] NOT NULL,
	[PersonalDetailId] [bigint] NOT NULL,
	[Id] [bigint] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 11/04/2013 04:21:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[PersonalDetailId] [bigint] NOT NULL,
	[Id] [bigint] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Company_inherits_Account]    Script Date: 11/04/2013 04:21:00 ******/
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_inherits_Account] FOREIGN KEY([Id])
REFERENCES [dbo].[Accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_inherits_Account]
GO
/****** Object:  ForeignKey [FK_CompanyPersonalDetail]    Script Date: 11/04/2013 04:21:00 ******/
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_CompanyPersonalDetail] FOREIGN KEY([PersonalDetailId])
REFERENCES [dbo].[PersonalDetails] ([Id])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_CompanyPersonalDetail]
GO
/****** Object:  ForeignKey [FK_PersonalDetailAddress]    Script Date: 11/04/2013 04:21:00 ******/
ALTER TABLE [dbo].[PersonalDetails]  WITH CHECK ADD  CONSTRAINT [FK_PersonalDetailAddress] FOREIGN KEY([Address1])
REFERENCES [dbo].[Addresses] ([Id])
GO
ALTER TABLE [dbo].[PersonalDetails] CHECK CONSTRAINT [FK_PersonalDetailAddress]
GO
/****** Object:  ForeignKey [FK_PortfolioShare]    Script Date: 11/04/2013 04:21:00 ******/
ALTER TABLE [dbo].[Portfolios]  WITH CHECK ADD  CONSTRAINT [FK_PortfolioShare] FOREIGN KEY([ShareId])
REFERENCES [dbo].[Shares] ([Id])
GO
ALTER TABLE [dbo].[Portfolios] CHECK CONSTRAINT [FK_PortfolioShare]
GO
/****** Object:  ForeignKey [FK_PortfolioUser]    Script Date: 11/04/2013 04:21:00 ******/
ALTER TABLE [dbo].[Portfolios]  WITH CHECK ADD  CONSTRAINT [FK_PortfolioUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Portfolios] CHECK CONSTRAINT [FK_PortfolioUser]
GO
/****** Object:  ForeignKey [FK_ShareCompany]    Script Date: 11/04/2013 04:21:00 ******/
ALTER TABLE [dbo].[Shares]  WITH CHECK ADD  CONSTRAINT [FK_ShareCompany] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Shares] CHECK CONSTRAINT [FK_ShareCompany]
GO
/****** Object:  ForeignKey [FK_TransactionHistoryShare]    Script Date: 11/04/2013 04:21:00 ******/
ALTER TABLE [dbo].[TransactionHistories]  WITH CHECK ADD  CONSTRAINT [FK_TransactionHistoryShare] FOREIGN KEY([ShareId])
REFERENCES [dbo].[Shares] ([Id])
GO
ALTER TABLE [dbo].[TransactionHistories] CHECK CONSTRAINT [FK_TransactionHistoryShare]
GO
/****** Object:  ForeignKey [FK_TransactionHistoryUser]    Script Date: 11/04/2013 04:21:00 ******/
ALTER TABLE [dbo].[TransactionHistories]  WITH CHECK ADD  CONSTRAINT [FK_TransactionHistoryUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TransactionHistories] CHECK CONSTRAINT [FK_TransactionHistoryUser]
GO
/****** Object:  ForeignKey [FK_User_inherits_Account]    Script Date: 11/04/2013 04:21:00 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_inherits_Account] FOREIGN KEY([Id])
REFERENCES [dbo].[Accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_inherits_Account]
GO
/****** Object:  ForeignKey [FK_UserPersonalDetail]    Script Date: 11/04/2013 04:21:00 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_UserPersonalDetail] FOREIGN KEY([PersonalDetailId])
REFERENCES [dbo].[PersonalDetails] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_UserPersonalDetail]
GO
