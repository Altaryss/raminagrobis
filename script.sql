USE [master]
GO
/****** Object:  Database [raminagrobis]    Script Date: 06/02/2022 22:56:27 ******/
CREATE DATABASE [raminagrobis]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'raminagrobis', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\raminagrobis.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'raminagrobis_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\raminagrobis_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [raminagrobis] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [raminagrobis].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [raminagrobis] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [raminagrobis] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [raminagrobis] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [raminagrobis] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [raminagrobis] SET ARITHABORT OFF 
GO
ALTER DATABASE [raminagrobis] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [raminagrobis] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [raminagrobis] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [raminagrobis] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [raminagrobis] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [raminagrobis] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [raminagrobis] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [raminagrobis] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [raminagrobis] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [raminagrobis] SET  DISABLE_BROKER 
GO
ALTER DATABASE [raminagrobis] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [raminagrobis] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [raminagrobis] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [raminagrobis] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [raminagrobis] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [raminagrobis] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [raminagrobis] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [raminagrobis] SET RECOVERY FULL 
GO
ALTER DATABASE [raminagrobis] SET  MULTI_USER 
GO
ALTER DATABASE [raminagrobis] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [raminagrobis] SET DB_CHAINING OFF 
GO
ALTER DATABASE [raminagrobis] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [raminagrobis] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [raminagrobis] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [raminagrobis] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'raminagrobis', N'ON'
GO
ALTER DATABASE [raminagrobis] SET QUERY_STORE = OFF
GO
USE [raminagrobis]
GO
/****** Object:  Table [dbo].[cart]    Script Date: 06/02/2022 22:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cart](
	[id] [int] NOT NULL,
	[id_member] [int] NULL,
	[week_order] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cart_details]    Script Date: 06/02/2022 22:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cart_details](
	[id_cart] [int] NULL,
	[id_references] [int] NULL,
	[id_global_details] [int] NULL,
	[quantity] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[global_cart]    Script Date: 06/02/2022 22:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[global_cart](
	[id] [int] NOT NULL,
	[id_cart] [int] NULL,
	[week_order] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[global_cart_details]    Script Date: 06/02/2022 22:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[global_cart_details](
	[id] [int] NOT NULL,
	[id_global_cart] [int] NULL,
	[id_references] [int] NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[member]    Script Date: 06/02/2022 22:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[member](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[company] [nvarchar](255) NULL,
	[civility] [nvarchar](255) NULL,
	[surname] [nvarchar](255) NULL,
	[name] [nvarchar](255) NULL,
	[email] [nvarchar](255) NULL,
	[address] [nvarchar](255) NULL,
	[create_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mtm_pr]    Script Date: 06/02/2022 22:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mtm_pr](
	[id] [int] NOT NULL,
	[id_references] [int] NULL,
	[id_supplier] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Price]    Script Date: 06/02/2022 22:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Price](
	[id] [int] NOT NULL,
	[id_global_details] [int] NULL,
	[id_supplier] [int] NULL,
	[price] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[references]    Script Date: 06/02/2022 22:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[references](
	[id] [int] NOT NULL,
	[reference] [nvarchar](255) NULL,
	[wording] [nvarchar](255) NULL,
	[brand] [nvarchar](255) NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[supplier]    Script Date: 06/02/2022 22:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[supplier](
	[id] [int] NOT NULL,
	[company] [nvarchar](255) NULL,
	[civility] [nvarchar](255) NULL,
	[surname] [nvarchar](255) NULL,
	[name] [nvarchar](255) NULL,
	[email] [nvarchar](255) NULL,
	[address] [nvarchar](255) NULL,
	[create_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cart]  WITH CHECK ADD FOREIGN KEY([id_member])
REFERENCES [dbo].[member] ([id])
GO
ALTER TABLE [dbo].[cart_details]  WITH CHECK ADD FOREIGN KEY([id_cart])
REFERENCES [dbo].[cart] ([id])
GO
ALTER TABLE [dbo].[cart_details]  WITH CHECK ADD  CONSTRAINT [FK_cart_details_global_cart_details] FOREIGN KEY([id_global_details])
REFERENCES [dbo].[global_cart_details] ([id])
GO
ALTER TABLE [dbo].[cart_details] CHECK CONSTRAINT [FK_cart_details_global_cart_details]
GO
ALTER TABLE [dbo].[cart_details]  WITH CHECK ADD  CONSTRAINT [FK_cart_details_references] FOREIGN KEY([id_references])
REFERENCES [dbo].[references] ([id])
GO
ALTER TABLE [dbo].[cart_details] CHECK CONSTRAINT [FK_cart_details_references]
GO
ALTER TABLE [dbo].[global_cart]  WITH CHECK ADD FOREIGN KEY([id_cart])
REFERENCES [dbo].[cart] ([id])
GO
ALTER TABLE [dbo].[global_cart_details]  WITH CHECK ADD  CONSTRAINT [FK_global_cart_details_global_cart] FOREIGN KEY([id_global_cart])
REFERENCES [dbo].[global_cart] ([id])
GO
ALTER TABLE [dbo].[global_cart_details] CHECK CONSTRAINT [FK_global_cart_details_global_cart]
GO
ALTER TABLE [dbo].[global_cart_details]  WITH CHECK ADD  CONSTRAINT [FK_global_cart_details_references] FOREIGN KEY([id_references])
REFERENCES [dbo].[references] ([id])
GO
ALTER TABLE [dbo].[global_cart_details] CHECK CONSTRAINT [FK_global_cart_details_references]
GO
ALTER TABLE [dbo].[mtm_pr]  WITH CHECK ADD  CONSTRAINT [FK__mtm_pr__id_ref__35BCFE0A] FOREIGN KEY([id_references])
REFERENCES [dbo].[references] ([id])
GO
ALTER TABLE [dbo].[mtm_pr] CHECK CONSTRAINT [FK__mtm_pr__id_ref__35BCFE0A]
GO
ALTER TABLE [dbo].[mtm_pr]  WITH CHECK ADD FOREIGN KEY([id_supplier])
REFERENCES [dbo].[supplier] ([id])
GO
ALTER TABLE [dbo].[Price]  WITH CHECK ADD FOREIGN KEY([id_supplier])
REFERENCES [dbo].[supplier] ([id])
GO
ALTER TABLE [dbo].[Price]  WITH CHECK ADD  CONSTRAINT [FK_Price_global_cart_details] FOREIGN KEY([id_global_details])
REFERENCES [dbo].[global_cart_details] ([id])
GO
ALTER TABLE [dbo].[Price] CHECK CONSTRAINT [FK_Price_global_cart_details]
GO
USE [master]
GO
ALTER DATABASE [raminagrobis] SET  READ_WRITE 
GO
