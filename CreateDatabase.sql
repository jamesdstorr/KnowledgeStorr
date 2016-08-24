USE [master]
GO
/****** Object:  Database [KnowledgeStorr]    Script Date: 24/08/2016 13:58:09 ******/
CREATE DATABASE [KnowledgeStorr]

USE [KnowledgeStorr]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [KnowledgeStorr]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 24/08/2016 13:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Article]    Script Date: 24/08/2016 13:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[ArticleName] [nvarchar](max) NULL,
	[ArticleDescription] [nvarchar](max) NULL,
	[ArticleCreated] [datetime] NOT NULL,
	[ArticleContents] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
	[SubcategoryId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ArticleId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_dbo.Article] PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ArticleCategory]    Script Date: 24/08/2016 13:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleCategory](
	[CategoryName] [nvarchar](max) NULL,
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ArticleFilterViewModel_Id] [int] NULL,
 CONSTRAINT [PK_dbo.ArticleCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ArticleFilterViewModel]    Script Date: 24/08/2016 13:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleFilterViewModel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_dbo.ArticleFilterViewModel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ArticleSubcategory]    Script Date: 24/08/2016 13:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleSubcategory](
	[SubcategoryName] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
	[SubcategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ArticleFilterViewModel_Id] [int] NULL,
 CONSTRAINT [PK_dbo.ArticleSubcategory] PRIMARY KEY CLUSTERED 
(
	[SubcategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 24/08/2016 13:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[FirstName] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[UserId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_CategoryId]    Script Date: 24/08/2016 13:58:09 ******/
CREATE NONCLUSTERED INDEX [IX_CategoryId] ON [dbo].[Article]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubcategoryId]    Script Date: 24/08/2016 13:58:09 ******/
CREATE NONCLUSTERED INDEX [IX_SubcategoryId] ON [dbo].[Article]
(
	[SubcategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 24/08/2016 13:58:09 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Article]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ArticleFilterViewModel_Id]    Script Date: 24/08/2016 13:58:09 ******/
CREATE NONCLUSTERED INDEX [IX_ArticleFilterViewModel_Id] ON [dbo].[ArticleCategory]
(
	[ArticleFilterViewModel_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ArticleFilterViewModel_Id]    Script Date: 24/08/2016 13:58:09 ******/
CREATE NONCLUSTERED INDEX [IX_ArticleFilterViewModel_Id] ON [dbo].[ArticleSubcategory]
(
	[ArticleFilterViewModel_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryId]    Script Date: 24/08/2016 13:58:09 ******/
CREATE NONCLUSTERED INDEX [IX_CategoryId] ON [dbo].[ArticleSubcategory]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Article_dbo.ArticleCategory_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ArticleCategory] ([CategoryId])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_dbo.Article_dbo.ArticleCategory_CategoryId]
GO
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Article_dbo.ArticleSubcategory_SubcategoryId] FOREIGN KEY([SubcategoryId])
REFERENCES [dbo].[ArticleSubcategory] ([SubcategoryId])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_dbo.Article_dbo.ArticleSubcategory_SubcategoryId]
GO
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Article_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_dbo.Article_dbo.User_UserId]
GO
ALTER TABLE [dbo].[ArticleCategory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ArticleCategory_dbo.ArticleFilterViewModel_ArticleFilterViewModel_Id] FOREIGN KEY([ArticleFilterViewModel_Id])
REFERENCES [dbo].[ArticleFilterViewModel] ([Id])
GO
ALTER TABLE [dbo].[ArticleCategory] CHECK CONSTRAINT [FK_dbo.ArticleCategory_dbo.ArticleFilterViewModel_ArticleFilterViewModel_Id]
GO
ALTER TABLE [dbo].[ArticleSubcategory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ArticleSubcategory_dbo.ArticleCategory_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ArticleCategory] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ArticleSubcategory] CHECK CONSTRAINT [FK_dbo.ArticleSubcategory_dbo.ArticleCategory_CategoryId]
GO
ALTER TABLE [dbo].[ArticleSubcategory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ArticleSubcategory_dbo.ArticleFilterViewModel_ArticleFilterViewModel_Id] FOREIGN KEY([ArticleFilterViewModel_Id])
REFERENCES [dbo].[ArticleFilterViewModel] ([Id])
GO
ALTER TABLE [dbo].[ArticleSubcategory] CHECK CONSTRAINT [FK_dbo.ArticleSubcategory_dbo.ArticleFilterViewModel_ArticleFilterViewModel_Id]
GO
USE [master]
GO
ALTER DATABASE [KnowledgeStorr] SET  READ_WRITE 
GO


USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [KSAdmin]    Script Date: 24/08/2016 13:59:18 ******/
CREATE LOGIN [KSAdmin] WITH PASSWORD=N'Harewood21', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO


ALTER SERVER ROLE [sysadmin] ADD MEMBER [KSAdmin]
GO