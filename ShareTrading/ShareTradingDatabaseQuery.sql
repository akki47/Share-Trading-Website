USE [ShareTradingDatabase]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 12/19/2013 01:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[SpecialQuestion] [nvarchar](100) NULL,
	[Answer] [nvarchar](50) NULL,
	[Role] [int] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 12/19/2013 01:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 12/19/2013 01:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 12/19/2013 01:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [bigint] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
 CONSTRAINT [PK__webpages_Members__25869641] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 12/19/2013 01:14:22 ******/
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
/****** Object:  Table [dbo].[TransactionHistories]    Script Date: 12/19/2013 01:14:22 ******/
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
/****** Object:  Table [dbo].[Portfolios]    Script Date: 12/19/2013 01:14:22 ******/
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
/****** Object:  Table [dbo].[Shares]    Script Date: 12/19/2013 01:14:22 ******/
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
/****** Object:  Table [dbo].[Company]    Script Date: 12/19/2013 01:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[PersonalDetailId] [bigint] NOT NULL,
	[Id] [bigint] NOT NULL,
	[AccountId] [bigint] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/19/2013 01:14:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Points] [bigint] NOT NULL,
	[PersonalDetailId] [bigint] NOT NULL,
	[Id] [bigint] NOT NULL,
	[AccountId] [bigint] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalDetails]    Script Date: 12/19/2013 01:14:22 ******/
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
/****** Object:  Default [DF__webpages___IsCon__267ABA7A]    Script Date: 12/19/2013 01:14:22 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  CONSTRAINT [DF__webpages___IsCon__267ABA7A]  DEFAULT ((0)) FOR [IsConfirmed]
GO
/****** Object:  Default [DF__webpages___Passw__276EDEB3]    Script Date: 12/19/2013 01:14:22 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  CONSTRAINT [DF__webpages___Passw__276EDEB3]  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
/****** Object:  ForeignKey [FK_Company_Accounts]    Script Date: 12/19/2013 01:14:22 ******/
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_Accounts]
GO
/****** Object:  ForeignKey [FK_CompanyPersonalDetail]    Script Date: 12/19/2013 01:14:22 ******/
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_CompanyPersonalDetail] FOREIGN KEY([PersonalDetailId])
REFERENCES [dbo].[PersonalDetails] ([Id])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_CompanyPersonalDetail]
GO
/****** Object:  ForeignKey [FK_PersonalDetail_Address1]    Script Date: 12/19/2013 01:14:22 ******/
ALTER TABLE [dbo].[PersonalDetails]  WITH CHECK ADD  CONSTRAINT [FK_PersonalDetail_Address1] FOREIGN KEY([Address1])
REFERENCES [dbo].[Addresses] ([Id])
GO
ALTER TABLE [dbo].[PersonalDetails] CHECK CONSTRAINT [FK_PersonalDetail_Address1]
GO
/****** Object:  ForeignKey [FK_PersonalDetail_Address2]    Script Date: 12/19/2013 01:14:22 ******/
ALTER TABLE [dbo].[PersonalDetails]  WITH CHECK ADD  CONSTRAINT [FK_PersonalDetail_Address2] FOREIGN KEY([Address2])
REFERENCES [dbo].[Addresses] ([Id])
GO
ALTER TABLE [dbo].[PersonalDetails] CHECK CONSTRAINT [FK_PersonalDetail_Address2]
GO
/****** Object:  ForeignKey [FK_PortfolioShare]    Script Date: 12/19/2013 01:14:22 ******/
ALTER TABLE [dbo].[Portfolios]  WITH CHECK ADD  CONSTRAINT [FK_PortfolioShare] FOREIGN KEY([ShareId])
REFERENCES [dbo].[Shares] ([Id])
GO
ALTER TABLE [dbo].[Portfolios] CHECK CONSTRAINT [FK_PortfolioShare]
GO
/****** Object:  ForeignKey [FK_PortfolioUser]    Script Date: 12/19/2013 01:14:22 ******/
ALTER TABLE [dbo].[Portfolios]  WITH CHECK ADD  CONSTRAINT [FK_PortfolioUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Portfolios] CHECK CONSTRAINT [FK_PortfolioUser]
GO
/****** Object:  ForeignKey [FK_ShareCompany]    Script Date: 12/19/2013 01:14:22 ******/
ALTER TABLE [dbo].[Shares]  WITH CHECK ADD  CONSTRAINT [FK_ShareCompany] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Shares] CHECK CONSTRAINT [FK_ShareCompany]
GO
/****** Object:  ForeignKey [FK_TransactionHistoryShare]    Script Date: 12/19/2013 01:14:22 ******/
ALTER TABLE [dbo].[TransactionHistories]  WITH CHECK ADD  CONSTRAINT [FK_TransactionHistoryShare] FOREIGN KEY([ShareId])
REFERENCES [dbo].[Shares] ([Id])
GO
ALTER TABLE [dbo].[TransactionHistories] CHECK CONSTRAINT [FK_TransactionHistoryShare]
GO
/****** Object:  ForeignKey [FK_TransactionHistoryUser]    Script Date: 12/19/2013 01:14:22 ******/
ALTER TABLE [dbo].[TransactionHistories]  WITH CHECK ADD  CONSTRAINT [FK_TransactionHistoryUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TransactionHistories] CHECK CONSTRAINT [FK_TransactionHistoryUser]
GO
/****** Object:  ForeignKey [FK_User_Accounts]    Script Date: 12/19/2013 01:14:22 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Accounts]
GO
/****** Object:  ForeignKey [FK_UserPersonalDetail]    Script Date: 12/19/2013 01:14:22 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_UserPersonalDetail] FOREIGN KEY([PersonalDetailId])
REFERENCES [dbo].[PersonalDetails] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_UserPersonalDetail]
GO
