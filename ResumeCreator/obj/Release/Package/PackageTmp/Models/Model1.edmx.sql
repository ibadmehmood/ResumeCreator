
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/28/2019 16:26:09
-- Generated from EDMX file: C:\Users\user\documents\visual studio 2013\Projects\ResumeCreator\ResumeCreator\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ResumeCreator];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Education]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Education];
GO
IF OBJECT_ID(N'[dbo].[Experience]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Experience];
GO
IF OBJECT_ID(N'[dbo].[PersonalInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonalInfo];
GO
IF OBJECT_ID(N'[dbo].[Skill]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Skill];
GO
IF OBJECT_ID(N'[dbo].[Summary]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Summary];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL,
    [User_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [UserId] nvarchar(128)  NOT NULL,
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [Discriminator] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Educations'
CREATE TABLE [dbo].[Educations] (
    [id] int IDENTITY(1,1) NOT NULL,
    [school_name] nvarchar(max)  NULL,
    [city] nvarchar(max)  NULL,
    [state] nvarchar(max)  NULL,
    [degree] nvarchar(max)  NULL,
    [field_of_study] nvarchar(max)  NULL,
    [end_date] nvarchar(max)  NULL,
    [PersonalInfo_id] int  NOT NULL
);
GO

-- Creating table 'Skills'
CREATE TABLE [dbo].[Skills] (
    [id] int IDENTITY(1,1) NOT NULL,
    [skill1] nvarchar(max)  NULL,
    [level] nvarchar(max)  NULL,
    [PersonalInfo_id] int  NOT NULL
);
GO

-- Creating table 'Summaries'
CREATE TABLE [dbo].[Summaries] (
    [id] int IDENTITY(1,1) NOT NULL,
    [text] nvarchar(max)  NULL,
    [PersonalInfo_id] int  NOT NULL
);
GO

-- Creating table 'Experiences'
CREATE TABLE [dbo].[Experiences] (
    [id] int IDENTITY(1,1) NOT NULL,
    [employer] nvarchar(max)  NULL,
    [job_title] nvarchar(max)  NULL,
    [city] nvarchar(max)  NULL,
    [state] nvarchar(max)  NULL,
    [start_date] nvarchar(max)  NULL,
    [end_date] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL,
    [PersonalInfo_id] int  NOT NULL
);
GO

-- Creating table 'PersonalInfoes'
CREATE TABLE [dbo].[PersonalInfoes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [first_name] nvarchar(max)  NULL,
    [last_name] nvarchar(max)  NULL,
    [address] nvarchar(max)  NULL,
    [city] nvarchar(max)  NOT NULL,
    [state] nvarchar(max)  NULL,
    [zip_code] nvarchar(max)  NULL,
    [email] nvarchar(max)  NULL,
    [phone] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId], [LoginProvider], [ProviderKey] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([UserId], [LoginProvider], [ProviderKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Educations'
ALTER TABLE [dbo].[Educations]
ADD CONSTRAINT [PK_Educations]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Skills'
ALTER TABLE [dbo].[Skills]
ADD CONSTRAINT [PK_Skills]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Summaries'
ALTER TABLE [dbo].[Summaries]
ADD CONSTRAINT [PK_Summaries]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Experiences'
ALTER TABLE [dbo].[Experiences]
ADD CONSTRAINT [PK_Experiences]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'PersonalInfoes'
ALTER TABLE [dbo].[PersonalInfoes]
ADD CONSTRAINT [PK_PersonalInfoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]
ON [dbo].[AspNetUserClaims]
    ([User_Id]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [PersonalInfo_id] in table 'Skills'
ALTER TABLE [dbo].[Skills]
ADD CONSTRAINT [FK_PersonalInfoSkill]
    FOREIGN KEY ([PersonalInfo_id])
    REFERENCES [dbo].[PersonalInfoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonalInfoSkill'
CREATE INDEX [IX_FK_PersonalInfoSkill]
ON [dbo].[Skills]
    ([PersonalInfo_id]);
GO

-- Creating foreign key on [PersonalInfo_id] in table 'Educations'
ALTER TABLE [dbo].[Educations]
ADD CONSTRAINT [FK_PersonalInfoEducation]
    FOREIGN KEY ([PersonalInfo_id])
    REFERENCES [dbo].[PersonalInfoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonalInfoEducation'
CREATE INDEX [IX_FK_PersonalInfoEducation]
ON [dbo].[Educations]
    ([PersonalInfo_id]);
GO

-- Creating foreign key on [PersonalInfo_id] in table 'Summaries'
ALTER TABLE [dbo].[Summaries]
ADD CONSTRAINT [FK_PersonalInfoSummary]
    FOREIGN KEY ([PersonalInfo_id])
    REFERENCES [dbo].[PersonalInfoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonalInfoSummary'
CREATE INDEX [IX_FK_PersonalInfoSummary]
ON [dbo].[Summaries]
    ([PersonalInfo_id]);
GO

-- Creating foreign key on [PersonalInfo_id] in table 'Experiences'
ALTER TABLE [dbo].[Experiences]
ADD CONSTRAINT [FK_PersonalInfoExperience]
    FOREIGN KEY ([PersonalInfo_id])
    REFERENCES [dbo].[PersonalInfoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonalInfoExperience'
CREATE INDEX [IX_FK_PersonalInfoExperience]
ON [dbo].[Experiences]
    ([PersonalInfo_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------