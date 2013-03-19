USE [master]
GO
/****** Object:  Database [PromoveoDB]    Script Date: 19.03.2013 17:47:02 ******/
CREATE DATABASE [PromoveoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PromoveoDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PromoveoDB.mdf' , SIZE = 6016KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PromoveoDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PromoveoDB.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PromoveoDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PromoveoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PromoveoDB] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [PromoveoDB] SET ANSI_NULLS ON 
GO
ALTER DATABASE [PromoveoDB] SET ANSI_PADDING ON 
GO
ALTER DATABASE [PromoveoDB] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [PromoveoDB] SET ARITHABORT ON 
GO
ALTER DATABASE [PromoveoDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PromoveoDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PromoveoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PromoveoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PromoveoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PromoveoDB] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [PromoveoDB] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [PromoveoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PromoveoDB] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [PromoveoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PromoveoDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PromoveoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PromoveoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PromoveoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PromoveoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PromoveoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PromoveoDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PromoveoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PromoveoDB] SET RECOVERY FULL 
GO
ALTER DATABASE [PromoveoDB] SET  MULTI_USER 
GO
ALTER DATABASE [PromoveoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PromoveoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PromoveoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PromoveoDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [PromoveoDB]
GO
/****** Object:  User [spadmin]    Script Date: 19.03.2013 17:47:02 ******/
CREATE USER [spadmin] FOR LOGIN [spadmin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  StoredProcedure [dbo].[TestProcedure]    Script Date: 19.03.2013 17:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery2.sql|15|0|C:\Users\blel\AppData\Local\Temp\~vs8144.sql
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TestProcedure]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.ProcessModel
END

GO
/****** Object:  UserDefinedFunction [dbo].[GetUsersAsString]    Script Date: 19.03.2013 17:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetUsersAsString]
(
	@ModelUserGroupID int
)
RETURNS  nvarchar(max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ResultString nvarchar(max)

	-- Add the T-SQL statements to compute the return value here
	SELECT @ResultString = coalesce(@ResultString +', ','') + Shortname
	FROM dbo.PublishingPlatformUser
	LEFT OUTER JOIN dbo.UserToModelUserGroupAssignment ON  dbo.PublishingPlatformUser.Id = dbo.UserToModelUserGroupAssignment.FK_User
	WHERE dbo.UserToModelUserGroupAssignment.FK_ModelUserGroup = @ModelUserGroupID

	-- Return the result of the function
	RETURN @ResultString

END

GO
/****** Object:  Table [dbo].[Configuration]    Script Date: 19.03.2013 17:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModelUserGroup]    Script Date: 19.03.2013 17:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelUserGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FK_Configuration] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProcessModel]    Script Date: 19.03.2013 17:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessModel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcessModel] [nvarchar](50) NOT NULL,
	[PublishingVersion] [nvarchar](50) NOT NULL,
	[FK_PublishingPlatformUser] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProcessModel_PublishingPlatformRole]    Script Date: 19.03.2013 17:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessModel_PublishingPlatformRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FK_ProcessModel] [int] NOT NULL,
	[FK_PublishingPlatformRole] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PublishingPlatformRole]    Script Date: 19.03.2013 17:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PublishingPlatformRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PublishingPlatformUser]    Script Date: 19.03.2013 17:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PublishingPlatformUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Shortname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PublishingPlatformUser_PublishingPlatformRole]    Script Date: 19.03.2013 17:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PublishingPlatformUser_PublishingPlatformRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FK_PublishingPlatformRole] [int] NOT NULL,
	[FK_PublishingPlatformUser] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserToModelUserGroupAssignment]    Script Date: 19.03.2013 17:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserToModelUserGroupAssignment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FK_User] [int] NOT NULL,
	[FK_ModelUserGroup] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[ModelUserGroupUsers]    Script Date: 19.03.2013 17:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ModelUserGroupUsers]
AS
SELECT Id, Name, dbo.GetUsersAsString(Id) AS Users
FROM     dbo.ModelUserGroup

GO
/****** Object:  View [dbo].[ProcessModelAndOwner]    Script Date: 19.03.2013 17:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ProcessModelAndOwner]
AS
SELECT dbo.ProcessModel.Id, dbo.ProcessModel.ProcessModel, dbo.PublishingPlatformUser.Name, dbo.PublishingPlatformUser.Shortname, 
                  'mailto://' + dbo.PublishingPlatformUser.Email + '?subject=User Feedback for process ' + dbo.ProcessModel.ProcessModel + '&body=Dear ' + dbo.PublishingPlatformUser.Name
                   + ',' AS Email
FROM     dbo.ProcessModel INNER JOIN
                  dbo.PublishingPlatformUser ON dbo.ProcessModel.Id = dbo.PublishingPlatformUser.Id

GO
ALTER TABLE [dbo].[ModelUserGroup]  WITH CHECK ADD  CONSTRAINT [FK_ModelUserGroup_ToConfiguration] FOREIGN KEY([FK_Configuration])
REFERENCES [dbo].[Configuration] ([Id])
GO
ALTER TABLE [dbo].[ModelUserGroup] CHECK CONSTRAINT [FK_ModelUserGroup_ToConfiguration]
GO
ALTER TABLE [dbo].[ProcessModel_PublishingPlatformRole]  WITH CHECK ADD  CONSTRAINT [FK_ProcessModel_PublishingPlatformRole_ToProcessModel] FOREIGN KEY([FK_ProcessModel])
REFERENCES [dbo].[ProcessModel] ([Id])
GO
ALTER TABLE [dbo].[ProcessModel_PublishingPlatformRole] CHECK CONSTRAINT [FK_ProcessModel_PublishingPlatformRole_ToProcessModel]
GO
ALTER TABLE [dbo].[ProcessModel_PublishingPlatformRole]  WITH CHECK ADD  CONSTRAINT [FK_ProcessModel_PublishingPlatformRole_ToPublishingPlatformRole] FOREIGN KEY([FK_PublishingPlatformRole])
REFERENCES [dbo].[PublishingPlatformRole] ([Id])
GO
ALTER TABLE [dbo].[ProcessModel_PublishingPlatformRole] CHECK CONSTRAINT [FK_ProcessModel_PublishingPlatformRole_ToPublishingPlatformRole]
GO
ALTER TABLE [dbo].[PublishingPlatformUser_PublishingPlatformRole]  WITH CHECK ADD  CONSTRAINT [FK_PublishingPlatformUser_PublishingPlatformRole_ToPublishingPlatformRole] FOREIGN KEY([FK_PublishingPlatformRole])
REFERENCES [dbo].[PublishingPlatformRole] ([Id])
GO
ALTER TABLE [dbo].[PublishingPlatformUser_PublishingPlatformRole] CHECK CONSTRAINT [FK_PublishingPlatformUser_PublishingPlatformRole_ToPublishingPlatformRole]
GO
ALTER TABLE [dbo].[PublishingPlatformUser_PublishingPlatformRole]  WITH CHECK ADD  CONSTRAINT [FK_PublishingPlatformUser_PublishingPlatformRole_ToPublishingPlatformUser] FOREIGN KEY([FK_PublishingPlatformUser])
REFERENCES [dbo].[PublishingPlatformUser] ([Id])
GO
ALTER TABLE [dbo].[PublishingPlatformUser_PublishingPlatformRole] CHECK CONSTRAINT [FK_PublishingPlatformUser_PublishingPlatformRole_ToPublishingPlatformUser]
GO
ALTER TABLE [dbo].[UserToModelUserGroupAssignment]  WITH CHECK ADD  CONSTRAINT [FK_UserToModelUserGroupAssignment_ToModelUserGroup] FOREIGN KEY([FK_ModelUserGroup])
REFERENCES [dbo].[ModelUserGroup] ([Id])
GO
ALTER TABLE [dbo].[UserToModelUserGroupAssignment] CHECK CONSTRAINT [FK_UserToModelUserGroupAssignment_ToModelUserGroup]
GO
ALTER TABLE [dbo].[UserToModelUserGroupAssignment]  WITH CHECK ADD  CONSTRAINT [FK_UserToModelUserGroupAssignment_ToUser] FOREIGN KEY([FK_User])
REFERENCES [dbo].[PublishingPlatformUser] ([Id])
GO
ALTER TABLE [dbo].[UserToModelUserGroupAssignment] CHECK CONSTRAINT [FK_UserToModelUserGroupAssignment_ToUser]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[11] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ModelUserGroup"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 148
               Right = 256
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1512
         Width = 7644
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ModelUserGroupUsers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ModelUserGroupUsers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[27] 2[14] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ProcessModel"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 319
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PublishingPlatformUser"
            Begin Extent = 
               Top = 7
               Left = 367
               Bottom = 213
               Right = 650
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 10128
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProcessModelAndOwner'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProcessModelAndOwner'
GO
USE [master]
GO
ALTER DATABASE [PromoveoDB] SET  READ_WRITE 
GO
