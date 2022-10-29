
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/28/2022 15:45:36
-- Generated from EDMX file: D:\Documents\Visual studio Proyectos\EjercicioMVC16\Models\EjercicioMVC16Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Ejercicio16];
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

-- Creating table 'Flores'
CREATE TABLE [dbo].[Flores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nchar(3)  NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Descripcion] nvarchar(50)  NOT NULL,
    [Fotografia] varbinary(max)  NULL,
    [EspecieId] int  NOT NULL
);
GO

-- Creating table 'Especies'
CREATE TABLE [dbo].[Especies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [EpcFloración] nvarchar(max)  NOT NULL,
    [EstPlantacion] nvarchar(max)  NOT NULL,
    [TpSuelo] nvarchar(max)  NOT NULL,
    [TmpExposicion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Agentes'
CREATE TABLE [dbo].[Agentes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Tipo] nvarchar(max)  NOT NULL,
    [SubTipo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Poliniza'
CREATE TABLE [dbo].[Poliniza] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Reclamo] nvarchar(max)  NOT NULL,
    [FlorId] int  NOT NULL,
    [AgenteId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Flores'
ALTER TABLE [dbo].[Flores]
ADD CONSTRAINT [PK_Flores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Especies'
ALTER TABLE [dbo].[Especies]
ADD CONSTRAINT [PK_Especies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Agentes'
ALTER TABLE [dbo].[Agentes]
ADD CONSTRAINT [PK_Agentes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Poliniza'
ALTER TABLE [dbo].[Poliniza]
ADD CONSTRAINT [PK_Poliniza]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EspecieId] in table 'Flores'
ALTER TABLE [dbo].[Flores]
ADD CONSTRAINT [FK_EspecieFlor]
    FOREIGN KEY ([EspecieId])
    REFERENCES [dbo].[Especies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EspecieFlor'
CREATE INDEX [IX_FK_EspecieFlor]
ON [dbo].[Flores]
    ([EspecieId]);
GO

-- Creating foreign key on [FlorId] in table 'Poliniza'
ALTER TABLE [dbo].[Poliniza]
ADD CONSTRAINT [FK_FlorPoliniza]
    FOREIGN KEY ([FlorId])
    REFERENCES [dbo].[Flores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FlorPoliniza'
CREATE INDEX [IX_FK_FlorPoliniza]
ON [dbo].[Poliniza]
    ([FlorId]);
GO

-- Creating foreign key on [AgenteId] in table 'Poliniza'
ALTER TABLE [dbo].[Poliniza]
ADD CONSTRAINT [FK_AgentePoliniza]
    FOREIGN KEY ([AgenteId])
    REFERENCES [dbo].[Agentes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AgentePoliniza'
CREATE INDEX [IX_FK_AgentePoliniza]
ON [dbo].[Poliniza]
    ([AgenteId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------