USE [master]
GO
/****** Object:  Database [NhibernateDB]    Script Date: 21/11/2017 16:37:26 ******/
CREATE DATABASE [NhibernateDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NhibernateDB', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\NhibernateDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NhibernateDB_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\NhibernateDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NhibernateDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NhibernateDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NhibernateDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NhibernateDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NhibernateDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NhibernateDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NhibernateDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [NhibernateDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NhibernateDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [NhibernateDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NhibernateDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NhibernateDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NhibernateDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NhibernateDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NhibernateDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NhibernateDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NhibernateDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NhibernateDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NhibernateDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NhibernateDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NhibernateDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NhibernateDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NhibernateDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NhibernateDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NhibernateDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NhibernateDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NhibernateDB] SET  MULTI_USER 
GO
ALTER DATABASE [NhibernateDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NhibernateDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NhibernateDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NhibernateDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [NhibernateDB]
GO
/****** Object:  Table [dbo].[Inventions]    Script Date: 21/11/2017 16:37:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventions](
	[InventionID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ScientistID] [int] NULL,
 CONSTRAINT [PK_dbo.Inventions] PRIMARY KEY CLUSTERED 
(
	[InventionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Scientists]    Script Date: 21/11/2017 16:37:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scientists](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ScientistEntities] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Inventions] ON 

INSERT [dbo].[Inventions] ([InventionID], [Description], [ScientistID]) VALUES (1, N'Wolden Cliff', 1)
INSERT [dbo].[Inventions] ([InventionID], [Description], [ScientistID]) VALUES (2, N'Gravity Euroke', 2)
INSERT [dbo].[Inventions] ([InventionID], [Description], [ScientistID]) VALUES (4, N'Electric Motorin diesel', 2)
INSERT [dbo].[Inventions] ([InventionID], [Description], [ScientistID]) VALUES (5, N'Moon Lighter', 4)
INSERT [dbo].[Inventions] ([InventionID], [Description], [ScientistID]) VALUES (6, N'Jupiter Venuses', 3)
INSERT [dbo].[Inventions] ([InventionID], [Description], [ScientistID]) VALUES (7, N'Wireless', 1)
INSERT [dbo].[Inventions] ([InventionID], [Description], [ScientistID]) VALUES (26, N'Artificial Intelligence', 13)
INSERT [dbo].[Inventions] ([InventionID], [Description], [ScientistID]) VALUES (27, N'Deep Learning', 13)
INSERT [dbo].[Inventions] ([InventionID], [Description], [ScientistID]) VALUES (36, N'This is a success message, it is green', 2)
INSERT [dbo].[Inventions] ([InventionID], [Description], [ScientistID]) VALUES (97, N'Salih', 13)
INSERT [dbo].[Inventions] ([InventionID], [Description], [ScientistID]) VALUES (100, N'stressfull', 30)
SET IDENTITY_INSERT [dbo].[Inventions] OFF
SET IDENTITY_INSERT [dbo].[Scientists] ON 

INSERT [dbo].[Scientists] ([ID], [FirstName], [LastName], [Title]) VALUES (1, N'Nikola', N'Tesla', N'Engineer')
INSERT [dbo].[Scientists] ([ID], [FirstName], [LastName], [Title]) VALUES (2, N'Albert', N'Einstian', N'Scientist')
INSERT [dbo].[Scientists] ([ID], [FirstName], [LastName], [Title]) VALUES (3, N'Galip', N'Galilio', N'Scientist')
INSERT [dbo].[Scientists] ([ID], [FirstName], [LastName], [Title]) VALUES (4, N'Jhonnes', N'Kepler', N'Space Expert')
INSERT [dbo].[Scientists] ([ID], [FirstName], [LastName], [Title]) VALUES (13, N'Erhan', N'Gidici', N'Developer')
INSERT [dbo].[Scientists] ([ID], [FirstName], [LastName], [Title]) VALUES (30, N'Nila', N'Dirisanti', N'Botanic')
SET IDENTITY_INSERT [dbo].[Scientists] OFF
USE [master]
GO
ALTER DATABASE [NhibernateDB] SET  READ_WRITE 
GO
