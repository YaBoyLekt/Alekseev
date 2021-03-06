USE [master]
GO
/****** Object:  Database [MeteringApp]    Script Date: 06.06.2021 22:57:01 ******/
CREATE DATABASE [MeteringApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MeteringApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MeteringApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MeteringApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MeteringApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MeteringApp] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MeteringApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MeteringApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MeteringApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MeteringApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MeteringApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MeteringApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [MeteringApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MeteringApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MeteringApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MeteringApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MeteringApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MeteringApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MeteringApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MeteringApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MeteringApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MeteringApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MeteringApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MeteringApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MeteringApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MeteringApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MeteringApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MeteringApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MeteringApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MeteringApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MeteringApp] SET  MULTI_USER 
GO
ALTER DATABASE [MeteringApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MeteringApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MeteringApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MeteringApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MeteringApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MeteringApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MeteringApp] SET QUERY_STORE = OFF
GO
USE [MeteringApp]
GO
/****** Object:  Table [dbo].[LoginHistory]    Script Date: 06.06.2021 22:57:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Datetime] [datetime] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Successfull] [bit] NOT NULL,
 CONSTRAINT [PK_LoginHistory_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meters]    Script Date: 06.06.2021 22:57:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meters](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClientFirstName] [nvarchar](50) NOT NULL,
	[ClientSecondName] [nvarchar](50) NOT NULL,
	[ColdWaterMeter] [int] NOT NULL,
	[HotWaterMeter] [int] NOT NULL,
	[Datetime] [datetime] NOT NULL,
 CONSTRAINT [PK_Meters] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 06.06.2021 22:57:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[UserType] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 06.06.2021 22:57:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LoginHistory] ON 

INSERT [dbo].[LoginHistory] ([ID], [Datetime], [Username], [Successfull]) VALUES (1, CAST(N'2021-06-05T13:30:58.307' AS DateTime), N'a', 1)
INSERT [dbo].[LoginHistory] ([ID], [Datetime], [Username], [Successfull]) VALUES (2, CAST(N'2021-06-05T13:55:46.290' AS DateTime), N'a', 1)
INSERT [dbo].[LoginHistory] ([ID], [Datetime], [Username], [Successfull]) VALUES (3, CAST(N'2021-06-05T14:38:48.040' AS DateTime), N'a', 1)
INSERT [dbo].[LoginHistory] ([ID], [Datetime], [Username], [Successfull]) VALUES (4, CAST(N'2021-06-05T14:39:46.750' AS DateTime), N'a', 1)
INSERT [dbo].[LoginHistory] ([ID], [Datetime], [Username], [Successfull]) VALUES (5, CAST(N'2021-06-05T14:40:57.830' AS DateTime), N'aa', 1)
INSERT [dbo].[LoginHistory] ([ID], [Datetime], [Username], [Successfull]) VALUES (6, CAST(N'2021-06-05T14:43:11.470' AS DateTime), N'aa', 1)
SET IDENTITY_INSERT [dbo].[LoginHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[Meters] ON 

INSERT [dbo].[Meters] ([ID], [ClientFirstName], [ClientSecondName], [ColdWaterMeter], [HotWaterMeter], [Datetime]) VALUES (2, N'Andrey', N'Aaa', 36, 23, CAST(N'2021-06-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Meters] ([ID], [ClientFirstName], [ClientSecondName], [ColdWaterMeter], [HotWaterMeter], [Datetime]) VALUES (1003, N'aaa', N'aaa', 35, 24, CAST(N'2021-06-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Meters] ([ID], [ClientFirstName], [ClientSecondName], [ColdWaterMeter], [HotWaterMeter], [Datetime]) VALUES (1005, N'aaaa', N'aaaa', 36, 25, CAST(N'2021-06-03T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Meters] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (1, N'Никита', N'Абрамов', N'abramov', N'nikita', 1)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (2, N'Всеволод', N'Александров', N'aleksandrov', N'seva', 2)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (3, N'София', N'Андреева', N'andreeva', N'sonya', 2)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (4, N'Елизавета', N'Афанасьева', N'afanas', N'liza', 2)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (5, N'Игорь', N'Белов', N'belov', N'igor', 2)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (6, N'София', N'Богданова', N'bogdanova', N'sonya', 2)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (7, N'Федор', N'Васильев', N'vasilev', N'fedor', 1)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (1032, N'a', N'a', N'a', N'a', 1)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Username], [Password], [UserType]) VALUES (1033, N'aa', N'aa', N'aa', N'aa', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[UserType] ON 

INSERT [dbo].[UserType] ([ID], [UserType]) VALUES (1, N'Admin')
INSERT [dbo].[UserType] ([ID], [UserType]) VALUES (2, N'Accountant')
SET IDENTITY_INSERT [dbo].[UserType] OFF
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserType] FOREIGN KEY([UserType])
REFERENCES [dbo].[UserType] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserType]
GO
USE [master]
GO
ALTER DATABASE [MeteringApp] SET  READ_WRITE 
GO
