
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/20/2024 13:42:09
-- Generated from EDMX file: C:\Users\MSİ\Desktop\16221625009 FATMA BUSE ÇİL GÖRSELPROG2\ModelFirstEf\ModelFirstEf\VeriTabaniModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [VeriTabani];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Urunler'
CREATE TABLE [dbo].[Urunler] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [urunAdi] nvarchar(max)  NOT NULL,
    [birimFiyat] decimal(18,0)  NULL,
    [stokMiktar] int  NULL,
    [Kategori_ID] int  NOT NULL
);
GO

-- Creating table 'Kategoriler'
CREATE TABLE [dbo].[Kategoriler] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [kategoriAdi] nvarchar(200)  NOT NULL,
    [aciklama] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Urunler'
ALTER TABLE [dbo].[Urunler]
ADD CONSTRAINT [PK_Urunler]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Kategoriler'
ALTER TABLE [dbo].[Kategoriler]
ADD CONSTRAINT [PK_Kategoriler]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Kategori_ID] in table 'Urunler'
ALTER TABLE [dbo].[Urunler]
ADD CONSTRAINT [FK_KategoriUrun]
    FOREIGN KEY ([Kategori_ID])
    REFERENCES [dbo].[Kategoriler]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KategoriUrun'
CREATE INDEX [IX_FK_KategoriUrun]
ON [dbo].[Urunler]
    ([Kategori_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------