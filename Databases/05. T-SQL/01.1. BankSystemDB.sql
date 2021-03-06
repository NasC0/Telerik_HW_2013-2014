USE [BankSystemDB]
GO
/****** Object:  User [NasK0]    Script Date: 24.8.2014 г. 12:07:36 ******/
CREATE USER [NasK0] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 24.8.2014 г. 12:07:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[Balance] [money] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 24.8.2014 г. 12:07:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[SSN] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

GO
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (1, 1, 1500.0000)
GO
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (2, 2, 2399.1500)
GO
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (3, 3, 4500.2000)
GO
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[People] ON 

GO
INSERT [dbo].[People] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (1, N'Pesho', N'Peshev', N'123456789')
GO
INSERT [dbo].[People] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (2, N'Misho', N'Mishev', N'123456789')
GO
INSERT [dbo].[People] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (3, N'Mitko', N'Mitev', N'123456789')
GO
SET IDENTITY_INSERT [dbo].[People] OFF
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_People] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_People]
GO
