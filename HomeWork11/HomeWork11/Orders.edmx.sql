
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/16/2021 13:52:00
-- Generated from EDMX file: E:\C#\HomeWork_CSharp\HomeWork11\HomeWork11\Orders.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [E:\C#\HomeWork_CSharp\HomeWork11\Orders.mdf];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_OrderDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderDetailSet] DROP CONSTRAINT [FK_OrderDetails];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[OrderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderSet];
GO
IF OBJECT_ID(N'[dbo].[OrderDetailSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderDetailSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'OrderSet'
CREATE TABLE [dbo].[OrderSet] (
    [OrderNumber] int IDENTITY(1,1) NOT NULL,
    [Client] nvarchar(max)  NOT NULL,
    [OrderAddress] nvarchar(max)  NOT NULL,
    [OrderAmount] int  NOT NULL,
    [OrderTime] datetime  NOT NULL
);
GO

-- Creating table 'OrderDetailSet'
CREATE TABLE [dbo].[OrderDetailSet] (
    [TradeId] int  NOT NULL,
    [TradeName] nvarchar(450)  NOT NULL,
    [TradeAmount] int  NOT NULL,
    [TradePrice] int  NOT NULL,
    [OrderNumber] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [OrderNumber] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [PK_OrderSet]
    PRIMARY KEY CLUSTERED ([OrderNumber] ASC);
GO

-- Creating primary key on [TradeId] in table 'OrderDetailSet'
ALTER TABLE [dbo].[OrderDetailSet]
ADD CONSTRAINT [PK_OrderDetailSet]
    PRIMARY KEY CLUSTERED ([TradeId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OrderNumber] in table 'OrderDetailSet'
ALTER TABLE [dbo].[OrderDetailSet]
ADD CONSTRAINT [FK_OrderDetails]
    FOREIGN KEY ([OrderNumber])
    REFERENCES [dbo].[OrderSet]
        ([OrderNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderDetails'
CREATE INDEX [IX_FK_OrderDetails]
ON [dbo].[OrderDetailSet]
    ([OrderNumber]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------