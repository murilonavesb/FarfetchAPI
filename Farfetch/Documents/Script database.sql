/*    ==Parâmetros de Script==

    Versão do Servidor de Origem : SQL Server 2008 (10.0.1600)
    Edição do Mecanismo de Banco de Dados de Origem : Microsoft SQL Server Express Edition
    Tipo do Mecanismo de Banco de Dados de Origem : SQL Server Autônomo

    Versão do Servidor de Destino : SQL Server 2017
    Edição de Mecanismo de Banco de Dados de Destino : Microsoft SQL Server Standard Edition
    Tipo de Mecanismo de Banco de Dados de Destino : SQL Server Autônomo
*/
USE [master]
GO
/****** Object:  Database [DB_Farfetch]    Script Date: 18/09/17 19:02:38 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'DB_Farfetch')
BEGIN
CREATE DATABASE [DB_Farfetch] ON  PRIMARY 
( NAME = N'DB_Farfetch', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\DB_Farfetch.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB_Farfetch_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\DB_Farfetch_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END
GO
ALTER DATABASE [DB_Farfetch] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Farfetch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Farfetch] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Farfetch] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Farfetch] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Farfetch] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Farfetch] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Farfetch] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_Farfetch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Farfetch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Farfetch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Farfetch] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Farfetch] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Farfetch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Farfetch] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Farfetch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Farfetch] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_Farfetch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Farfetch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Farfetch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Farfetch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Farfetch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Farfetch] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Farfetch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Farfetch] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_Farfetch] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Farfetch] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Farfetch] SET DB_CHAINING OFF 
GO
USE [DB_Farfetch]
GO
/****** Object:  Table [dbo].[tabControlToggle]    Script Date: 18/09/17 19:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tabControlToggle]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tabControlToggle](
	[idApplication] [int] NOT NULL,
	[idVersion] [int] NOT NULL,
	[strKey] [varchar](100) NOT NULL,
	[strValue] [bit] NOT NULL,
 CONSTRAINT [PK_tabControlToggle_1] PRIMARY KEY CLUSTERED 
(
	[idApplication] ASC,
	[idVersion] ASC,
	[strKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
USE [master]
GO
ALTER DATABASE [DB_Farfetch] SET  READ_WRITE 
GO
