USE [FreeZoneRentACarDb]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 3/7/2023 11:07:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_OperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 3/7/2023 11:07:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_UserOperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/7/2023 11:07:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[AuthenticatorType] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 
GO
INSERT [dbo].[OperationClaims] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (1, N'Brands.Create', CAST(N'2023-02-22T00:00:00.0000000' AS DateTime2), CAST(N'2023-02-22T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[OperationClaims] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (2, N'CarImages.Create', CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[OperationClaims] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (1002, N'Car.Create', CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[OperationClaims] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (2002, N'Admin', CAST(N'2023-03-07T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-07T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] ON 
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId], [CreatedDate], [UpdatedDate]) VALUES (1, 1, 1, CAST(N'2023-02-22T00:00:00.0000000' AS DateTime2), CAST(N'2023-02-22T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId], [CreatedDate], [UpdatedDate]) VALUES (2, 1, 2, CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId], [CreatedDate], [UpdatedDate]) VALUES (1002, 1, 1002, CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId], [CreatedDate], [UpdatedDate]) VALUES (2002, 1, 2002, CAST(N'2023-03-07T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-07T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordSalt], [PasswordHash], [Status], [CreatedDate], [UpdatedDate], [AuthenticatorType]) VALUES (1, N'Halit', N'Kalaycı', N'halit@kodlama.io', 0xB1A9A80B93F49C980CFCAA3B20F45C9665156D1705ACEF397CEF69522AAC828B9CE1B9C1CF978D3ED95340A159DE186A9BEF97DD268500069E4511601870DB78369CA63A9FDF5CE5F5B87549F32759497E679583228E6046FDC49BB96D069436E10D3CF73473B5437503EDF27FDA44A51B082E5C9FA6CE877F3BF47D04A9CBD9, 0xE35749AB332EDBE37034397B5ECB05BCA273E1AB7D9AC242B4700D3754C70157F25FD85653EEEFDF8469B553158922460C220026A9874AAEC751F5E0EDAF1E04, 1, CAST(N'2023-02-22T08:10:13.2843852' AS DateTime2), NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [AuthenticatorType]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_OperationClaims_OperationClaimId] FOREIGN KEY([OperationClaimId])
REFERENCES [dbo].[OperationClaims] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_OperationClaims_OperationClaimId]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_Users_UserId]
GO
