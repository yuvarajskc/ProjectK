CREATE DATABASE TodoDb;
GO

USE [TodoDb]
GO

/****** Object:  Table [dbo].[TodoItems]    Script Date: 2/15/2025 6:56:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TodoItems](	[Id] [bigint] IDENTITY(1,1) NOT NULL,	[Name] [varchar](50) NULL,	[IsComplete] [bit] NULL) ON [PRIMARY]
GO


