CREATE DATABASE [BddTraining]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BddTraining', FILENAME = N'C:\Bdd\Databases\BddTraining.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BddTraining_log', FILENAME = N'C:\Bdd\Databases\BddTraining_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

USE [BddTraining]
GO

CREATE TABLE [dbo].[Products](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[IsImported] [bit] NOT NULL,
	[Type] [int] NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ShoppingCarts](
	[ID] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ShoppingCartItems](
	[ID] [uniqueidentifier] NOT NULL,
	[ShoppingCartID] [uniqueidentifier] NOT NULL,
	[ProductID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Tax] [decimal](18, 0) NOT NULL
) ON [PRIMARY]

GO
