USE [master]
GO
/****** Object:  Database [QuanLyKho]    Script Date: 1/2/2021 9:37:26 PM ******/
CREATE DATABASE [QuanLyKho]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyKho', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyKho.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyKho_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyKho_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyKho] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyKho].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyKho] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyKho] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyKho] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyKho] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyKho] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyKho] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyKho] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyKho] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyKho] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyKho] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyKho] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyKho] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyKho] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyKho] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyKho] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyKho] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyKho] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyKho] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyKho] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyKho] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyKho] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyKho] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyKho] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyKho] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyKho] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyKho] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyKho] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyKho] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QuanLyKho] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyKho', N'ON'
GO
USE [QuanLyKho]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 1/2/2021 9:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](200) NULL,
	[MoreInfo] [nvarchar](max) NULL,
	[ContractDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Input]    Script Date: 1/2/2021 9:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Input](
	[Id] [nvarchar](128) NOT NULL,
	[DateInput] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InputInfo]    Script Date: 1/2/2021 9:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InputInfo](
	[Id] [nvarchar](128) NOT NULL,
	[IdObject] [nvarchar](128) NOT NULL,
	[IdInput] [nvarchar](128) NOT NULL,
	[Count] [int] NULL,
	[InputPrice] [float] NULL,
	[OutputPrice] [float] NULL,
	[Status] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Object]    Script Date: 1/2/2021 9:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Object](
	[Id] [nvarchar](128) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[IdUnit] [int] NOT NULL,
	[IdSuplier] [int] NOT NULL,
	[QRCode] [nvarchar](max) NULL,
	[BarCode] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Output]    Script Date: 1/2/2021 9:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Output](
	[Id] [nvarchar](128) NOT NULL,
	[DateOutput] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OutputInfo]    Script Date: 1/2/2021 9:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutputInfo](
	[Id] [nvarchar](128) NOT NULL,
	[IdObject] [nvarchar](128) NOT NULL,
	[IdInputInfo] [nvarchar](128) NOT NULL,
	[IdCustomer] [int] NOT NULL,
	[Count] [int] NULL,
	[Status] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Suplier]    Script Date: 1/2/2021 9:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](200) NULL,
	[MoreInfo] [nvarchar](max) NULL,
	[ContractDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Unit]    Script Date: 1/2/2021 9:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 1/2/2021 9:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/2/2021 9:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](max) NULL,
	[IdRole] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (2, N'Nhân viên')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (1, N'haichau', N'admin', N'db69fc039dcbd2962cb4d28f5891aae1', 1)
INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (2, N'Nhân viên', N'staff', N'978aae9bb6bee8fb75de3e4830a1be46', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[InputInfo] ADD  DEFAULT ((0)) FOR [InputPrice]
GO
ALTER TABLE [dbo].[InputInfo] ADD  DEFAULT ((0)) FOR [OutputPrice]
GO
ALTER TABLE [dbo].[InputInfo]  WITH CHECK ADD FOREIGN KEY([IdInput])
REFERENCES [dbo].[Input] ([Id])
GO
ALTER TABLE [dbo].[InputInfo]  WITH CHECK ADD FOREIGN KEY([IdObject])
REFERENCES [dbo].[Object] ([Id])
GO
ALTER TABLE [dbo].[Object]  WITH CHECK ADD FOREIGN KEY([IdUnit])
REFERENCES [dbo].[Unit] ([Id])
GO
ALTER TABLE [dbo].[Object]  WITH CHECK ADD FOREIGN KEY([IdSuplier])
REFERENCES [dbo].[Suplier] ([Id])
GO
ALTER TABLE [dbo].[OutputInfo]  WITH CHECK ADD FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[OutputInfo]  WITH CHECK ADD FOREIGN KEY([IdInputInfo])
REFERENCES [dbo].[InputInfo] ([Id])
GO
ALTER TABLE [dbo].[OutputInfo]  WITH CHECK ADD FOREIGN KEY([IdObject])
REFERENCES [dbo].[Object] ([Id])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([IdRole])
REFERENCES [dbo].[UserRole] ([Id])
GO
USE [master]
GO
ALTER DATABASE [QuanLyKho] SET  READ_WRITE 
GO
