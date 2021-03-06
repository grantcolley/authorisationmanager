USE [master]
GO

CREATE DATABASE [AuthorisationManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AuthorisationManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\AuthorisationManager.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AuthorisationManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\AuthorisationManager_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AuthorisationManager] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AuthorisationManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AuthorisationManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AuthorisationManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AuthorisationManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AuthorisationManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AuthorisationManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [AuthorisationManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AuthorisationManager] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [AuthorisationManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AuthorisationManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AuthorisationManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AuthorisationManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AuthorisationManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AuthorisationManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AuthorisationManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AuthorisationManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AuthorisationManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AuthorisationManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AuthorisationManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AuthorisationManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AuthorisationManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AuthorisationManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AuthorisationManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AuthorisationManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AuthorisationManager] SET RECOVERY FULL 
GO
ALTER DATABASE [AuthorisationManager] SET  MULTI_USER 
GO
ALTER DATABASE [AuthorisationManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AuthorisationManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AuthorisationManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AuthorisationManager] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AuthorisationManager', N'ON'
GO
USE [AuthorisationManager]
GO

CREATE USER [authmanager] FOR LOGIN [authmanager] WITH DEFAULT_SCHEMA=[am]
GO

CREATE ROLE [db_authorisationmanager]
GO
ALTER ROLE [db_authorisationmanager] ADD MEMBER [authmanager]
GO

CREATE SCHEMA [am]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [am].[Activity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ActivityCode] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [am].[ActivityActivity](
	[ParentActivityId] [int] NOT NULL,
	[ActivityId] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [am].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RoleCode] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [am].[RoleActivity](
	[RoleId] [int] NOT NULL,
	[ActivityId] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [am].[RoleRole](
	[ParentRoleId] [int] NOT NULL,
	[RoleId] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [am].[UserAuthorisation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_UserAuthorisation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [am].[UserRole](
	[Id] [int] NOT NULL,
	[RoleId] [int] NOT NULL
) ON [PRIMARY]

GO

CREATE UNIQUE NONCLUSTERED INDEX [IXActivityActivity] ON [am].[ActivityActivity]
(
	[ParentActivityId] ASC,
	[ActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IXRoleActivity] ON [am].[RoleActivity]
(
	[RoleId] ASC,
	[ActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IXRoleRole] ON [am].[RoleRole]
(
	[ParentRoleId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IXUserRole] ON [am].[UserRole]
(
	[Id] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [AuthorisationManager] SET  READ_WRITE 
GO
