USE [master]
GO
/****** Object:  Database [WorldDB]    Script Date: 21.8.2014 г. 15:27:39 ******/
CREATE DATABASE [WorldDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WorldDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\WorldDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WorldDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\WorldDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WorldDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WorldDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WorldDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WorldDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WorldDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WorldDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WorldDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [WorldDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WorldDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WorldDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WorldDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WorldDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WorldDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WorldDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WorldDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WorldDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WorldDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WorldDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WorldDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WorldDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WorldDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WorldDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WorldDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WorldDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WorldDB] SET RECOVERY FULL 
GO
ALTER DATABASE [WorldDB] SET  MULTI_USER 
GO
ALTER DATABASE [WorldDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WorldDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WorldDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WorldDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [WorldDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WorldDB', N'ON'
GO
USE [WorldDB]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 21.8.2014 г. 15:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[TownID] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Continents]    Script Date: 21.8.2014 г. 15:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 21.8.2014 г. 15:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ContinentID] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[People]    Script Date: 21.8.2014 г. 15:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[People](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[AddressID] [int] NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Towns]    Script Date: 21.8.2014 г. 15:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Towns](
	[TownID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

GO
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (1, N'77 Ivan Vazov bul', 1)
GO
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (2, N'Tsarigradsko Shose bul', 2)
GO
SET IDENTITY_INSERT [dbo].[Addresses] OFF
GO
SET IDENTITY_INSERT [dbo].[Continents] ON 

GO
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (1, N'Europe')
GO
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (2, N'Asia')
GO
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (3, N'North America')
GO
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (4, N'South America')
GO
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (5, N'Africa')
GO
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (6, N'Australia')
GO
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (7, N'Antarctica')
GO
SET IDENTITY_INSERT [dbo].[Continents] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

GO
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (1, N'Bulgaria', 1)
GO
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (2, N'Greece', 1)
GO
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (3, N'Turkey', 2)
GO
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (4, N'Russia', 1)
GO
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (5, N'United States of America', 3)
GO
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (6, N'Cuba', 4)
GO
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (7, N'Egypt', 5)
GO
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (8, N'Australia', 6)
GO
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[People] ON 

GO
INSERT [dbo].[People] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (1, N'Pesho', N'Peshev', 1)
GO
INSERT [dbo].[People] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (2, N'Bai', N'Mangau', 2)
GO
SET IDENTITY_INSERT [dbo].[People] OFF
GO
SET IDENTITY_INSERT [dbo].[Towns] ON 

GO
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (1, N'Burgas', 1)
GO
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (2, N'Sofia', 1)
GO
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (3, N'Athens', 2)
GO
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (4, N'Istanbul', 3)
GO
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (5, N'St. Peterburg', 4)
GO
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (6, N'Chicago', 5)
GO
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (7, N'Giza', 7)
GO
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (8, N'Sydney', 8)
GO
SET IDENTITY_INSERT [dbo].[Towns] OFF
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownID])
REFERENCES [dbo].[Towns] ([TownID])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentID])
REFERENCES [dbo].[Continents] ([ContinentID])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Addresses] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Addresses] ([AddressID])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries1] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries1]
GO
USE [master]
GO
ALTER DATABASE [WorldDB] SET  READ_WRITE 
GO
