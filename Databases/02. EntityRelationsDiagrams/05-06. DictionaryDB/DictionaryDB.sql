USE [master]
GO
/****** Object:  Database [DictionaryDB]    Script Date: 21.8.2014 г. 18:05:56 ******/
CREATE DATABASE [DictionaryDB]
GO
ALTER DATABASE [DictionaryDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DictionaryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DictionaryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DictionaryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DictionaryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DictionaryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DictionaryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DictionaryDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DictionaryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DictionaryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DictionaryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DictionaryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DictionaryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DictionaryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DictionaryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DictionaryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DictionaryDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DictionaryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DictionaryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DictionaryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DictionaryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DictionaryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DictionaryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DictionaryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DictionaryDB] SET RECOVERY FULL 
GO
ALTER DATABASE [DictionaryDB] SET  MULTI_USER 
GO
ALTER DATABASE [DictionaryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DictionaryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DictionaryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DictionaryDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DictionaryDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DictionaryDB', N'ON'
GO
USE [DictionaryDB]
GO
/****** Object:  Table [dbo].[Antonyms]    Script Date: 21.8.2014 г. 18:05:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Antonyms](
	[WordID] [int] NOT NULL,
	[AntonymID] [int] NOT NULL,
 CONSTRAINT [PK_Antonyms] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC,
	[AntonymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hypernims_Hyponims]    Script Date: 21.8.2014 г. 18:05:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hypernims_Hyponims](
	[HypernimID] [int] NOT NULL,
	[HyponimID] [int] NOT NULL,
 CONSTRAINT [PK_Hypernims_Hyponims] PRIMARY KEY CLUSTERED 
(
	[HypernimID] ASC,
	[HyponimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 21.8.2014 г. 18:05:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Part_Of_Speech_Info]    Script Date: 21.8.2014 г. 18:05:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Part_Of_Speech_Info](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Part_Of_Speech_Info] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 21.8.2014 г. 18:05:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[WordID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageID] [int] NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[Description] [text] NOT NULL,
	[PartOfSpeechID] [int] NOT NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words_Synonyms]    Script Date: 21.8.2014 г. 18:05:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words_Synonyms](
	[WordID] [int] NOT NULL,
	[SynonymID] [int] NOT NULL,
 CONSTRAINT [PK_Words_Synonyms] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC,
	[SynonymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words_Translations]    Script Date: 21.8.2014 г. 18:05:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words_Translations](
	[WordID] [int] NOT NULL,
	[TranslationID] [int] NOT NULL,
 CONSTRAINT [PK_Words_Translations] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC,
	[TranslationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Antonyms] ([WordID], [AntonymID]) VALUES (5, 6)
GO
INSERT [dbo].[Antonyms] ([WordID], [AntonymID]) VALUES (6, 5)
GO
INSERT [dbo].[Antonyms] ([WordID], [AntonymID]) VALUES (7, 8)
GO
INSERT [dbo].[Antonyms] ([WordID], [AntonymID]) VALUES (8, 7)
GO
INSERT [dbo].[Hypernims_Hyponims] ([HypernimID], [HyponimID]) VALUES (9, 10)
GO
INSERT [dbo].[Hypernims_Hyponims] ([HypernimID], [HyponimID]) VALUES (11, 9)
GO
SET IDENTITY_INSERT [dbo].[Languages] ON 

GO
INSERT [dbo].[Languages] ([LanguageID], [Name]) VALUES (1, N'Bulgarian')
GO
INSERT [dbo].[Languages] ([LanguageID], [Name]) VALUES (2, N'English')
GO
SET IDENTITY_INSERT [dbo].[Languages] OFF
GO
SET IDENTITY_INSERT [dbo].[Part_Of_Speech_Info] ON 

GO
INSERT [dbo].[Part_Of_Speech_Info] ([ID], [Name]) VALUES (1, N'Verb')
GO
INSERT [dbo].[Part_Of_Speech_Info] ([ID], [Name]) VALUES (2, N'Noun')
GO
INSERT [dbo].[Part_Of_Speech_Info] ([ID], [Name]) VALUES (3, N'Adjective')
GO
SET IDENTITY_INSERT [dbo].[Part_Of_Speech_Info] OFF
GO
SET IDENTITY_INSERT [dbo].[Words] ON 

GO
INSERT [dbo].[Words] ([WordID], [LanguageID], [Word], [Description], [PartOfSpeechID]) VALUES (1, 1, N'Бяга', N'Движи се бързо', 1)
GO
INSERT [dbo].[Words] ([WordID], [LanguageID], [Word], [Description], [PartOfSpeechID]) VALUES (2, 2, N'Run', N'Moving fast', 1)
GO
INSERT [dbo].[Words] ([WordID], [LanguageID], [Word], [Description], [PartOfSpeechID]) VALUES (3, 1, N'Пробвам', N'Консумирам нещо в малко количество', 1)
GO
INSERT [dbo].[Words] ([WordID], [LanguageID], [Word], [Description], [PartOfSpeechID]) VALUES (4, 1, N'Опитвам', N'Правя проба', 1)
GO
INSERT [dbo].[Words] ([WordID], [LanguageID], [Word], [Description], [PartOfSpeechID]) VALUES (5, 1, N'Бърз', N'Който се движи с голяма скорост', 3)
GO
INSERT [dbo].[Words] ([WordID], [LanguageID], [Word], [Description], [PartOfSpeechID]) VALUES (6, 1, N'Бавен', N'Който се движи с ниска скорост', 3)
GO
INSERT [dbo].[Words] ([WordID], [LanguageID], [Word], [Description], [PartOfSpeechID]) VALUES (7, 2, N'Fast', N'Moving at great velocity', 3)
GO
INSERT [dbo].[Words] ([WordID], [LanguageID], [Word], [Description], [PartOfSpeechID]) VALUES (8, 2, N'Slow', N'Moving at slow velocity', 3)
GO
INSERT [dbo].[Words] ([WordID], [LanguageID], [Word], [Description], [PartOfSpeechID]) VALUES (9, 1, N'Дърво', N'Вид растение', 2)
GO
INSERT [dbo].[Words] ([WordID], [LanguageID], [Word], [Description], [PartOfSpeechID]) VALUES (10, 1, N'Дъб', N'Вид дърво', 2)
GO
INSERT [dbo].[Words] ([WordID], [LanguageID], [Word], [Description], [PartOfSpeechID]) VALUES (11, 1, N'Растение', N'Вид живо същество', 2)
GO
SET IDENTITY_INSERT [dbo].[Words] OFF
GO
INSERT [dbo].[Words_Synonyms] ([WordID], [SynonymID]) VALUES (3, 4)
GO
INSERT [dbo].[Words_Synonyms] ([WordID], [SynonymID]) VALUES (4, 3)
GO
INSERT [dbo].[Words_Translations] ([WordID], [TranslationID]) VALUES (1, 2)
GO
INSERT [dbo].[Words_Translations] ([WordID], [TranslationID]) VALUES (2, 1)
GO
INSERT [dbo].[Words_Translations] ([WordID], [TranslationID]) VALUES (5, 7)
GO
INSERT [dbo].[Words_Translations] ([WordID], [TranslationID]) VALUES (6, 8)
GO
INSERT [dbo].[Words_Translations] ([WordID], [TranslationID]) VALUES (7, 5)
GO
INSERT [dbo].[Words_Translations] ([WordID], [TranslationID]) VALUES (8, 6)
GO
ALTER TABLE [dbo].[Antonyms]  WITH CHECK ADD  CONSTRAINT [FK_Antonyms_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Antonyms] CHECK CONSTRAINT [FK_Antonyms_Words]
GO
ALTER TABLE [dbo].[Antonyms]  WITH CHECK ADD  CONSTRAINT [FK_Antonyms_Words1] FOREIGN KEY([AntonymID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Antonyms] CHECK CONSTRAINT [FK_Antonyms_Words1]
GO
ALTER TABLE [dbo].[Hypernims_Hyponims]  WITH CHECK ADD  CONSTRAINT [FK_Hypernims_Hyponims_Words] FOREIGN KEY([HypernimID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Hypernims_Hyponims] CHECK CONSTRAINT [FK_Hypernims_Hyponims_Words]
GO
ALTER TABLE [dbo].[Hypernims_Hyponims]  WITH CHECK ADD  CONSTRAINT [FK_Hypernims_Hyponims_Words1] FOREIGN KEY([HyponimID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Hypernims_Hyponims] CHECK CONSTRAINT [FK_Hypernims_Hyponims_Words1]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Part_Of_Speech_Info] FOREIGN KEY([PartOfSpeechID])
REFERENCES [dbo].[Part_Of_Speech_Info] ([ID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Part_Of_Speech_Info]
GO
ALTER TABLE [dbo].[Words_Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Synonyms_Words_Synonym] FOREIGN KEY([SynonymID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Synonyms] CHECK CONSTRAINT [FK_Words_Synonyms_Words_Synonym]
GO
ALTER TABLE [dbo].[Words_Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Synonyms_Words_Word] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Synonyms] CHECK CONSTRAINT [FK_Words_Synonyms_Words_Word]
GO
ALTER TABLE [dbo].[Words_Translations]  WITH CHECK ADD  CONSTRAINT [FK_Words_Translations_Words_Translation] FOREIGN KEY([TranslationID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Translations] CHECK CONSTRAINT [FK_Words_Translations_Words_Translation]
GO
ALTER TABLE [dbo].[Words_Translations]  WITH CHECK ADD  CONSTRAINT [FK_Words_Translations_Words_Word] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Translations] CHECK CONSTRAINT [FK_Words_Translations_Words_Word]
GO
USE [master]
GO
ALTER DATABASE [DictionaryDB] SET  READ_WRITE 
GO
