
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/12/2024 23:15:55
-- Generated from EDMX file: C:\Users\danse\source\repos\FEIService\DataAccess\FEIDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FEIDB];
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

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [IdUser] int IDENTITY(1,1) NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tutors'
CREATE TABLE [dbo].[Tutors] (
    [IdTutor] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Appointments'
CREATE TABLE [dbo].[Appointments] (
    [IdAppointment] int IDENTITY(1,1) NOT NULL,
    [AttendedDate] datetime  NOT NULL,
    [Duration] bigint  NOT NULL,
    [Status] smallint  NOT NULL,
    [NotAttendedReason] nvarchar(max)  NOT NULL,
    [Student_IdStudent] nvarchar(max)  NOT NULL,
    [Procedure_IdProcedure] int  NOT NULL
);
GO

-- Creating table 'Careers'
CREATE TABLE [dbo].[Careers] (
    [IdCareer] int IDENTITY(1,1) NOT NULL,
    [CareerName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Administrators'
CREATE TABLE [dbo].[Administrators] (
    [IdAdministrator] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [Users_IdUser] int  NOT NULL
);
GO

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [IdStudent] nvarchar(max)  NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [Tutor_IdTutor] int  NOT NULL,
    [Career_IdCareer] int  NOT NULL,
    [Users_IdUser] int  NOT NULL
);
GO

-- Creating table 'Procedures'
CREATE TABLE [dbo].[Procedures] (
    [IdProcedure] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdUser] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([IdUser] ASC);
GO

-- Creating primary key on [IdTutor] in table 'Tutors'
ALTER TABLE [dbo].[Tutors]
ADD CONSTRAINT [PK_Tutors]
    PRIMARY KEY CLUSTERED ([IdTutor] ASC);
GO

-- Creating primary key on [IdAppointment] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [PK_Appointments]
    PRIMARY KEY CLUSTERED ([IdAppointment] ASC);
GO

-- Creating primary key on [IdCareer] in table 'Careers'
ALTER TABLE [dbo].[Careers]
ADD CONSTRAINT [PK_Careers]
    PRIMARY KEY CLUSTERED ([IdCareer] ASC);
GO

-- Creating primary key on [IdAdministrator] in table 'Administrators'
ALTER TABLE [dbo].[Administrators]
ADD CONSTRAINT [PK_Administrators]
    PRIMARY KEY CLUSTERED ([IdAdministrator] ASC);
GO

-- Creating primary key on [IdStudent] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([IdStudent] ASC);
GO

-- Creating primary key on [IdProcedure] in table 'Procedures'
ALTER TABLE [dbo].[Procedures]
ADD CONSTRAINT [PK_Procedures]
    PRIMARY KEY CLUSTERED ([IdProcedure] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Tutor_IdTutor] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_TutorStudent]
    FOREIGN KEY ([Tutor_IdTutor])
    REFERENCES [dbo].[Tutors]
        ([IdTutor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TutorStudent'
CREATE INDEX [IX_FK_TutorStudent]
ON [dbo].[Students]
    ([Tutor_IdTutor]);
GO

-- Creating foreign key on [Career_IdCareer] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_CareerStudent]
    FOREIGN KEY ([Career_IdCareer])
    REFERENCES [dbo].[Careers]
        ([IdCareer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CareerStudent'
CREATE INDEX [IX_FK_CareerStudent]
ON [dbo].[Students]
    ([Career_IdCareer]);
GO

-- Creating foreign key on [Student_IdStudent] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_StudentAppointment]
    FOREIGN KEY ([Student_IdStudent])
    REFERENCES [dbo].[Students]
        ([IdStudent])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentAppointment'
CREATE INDEX [IX_FK_StudentAppointment]
ON [dbo].[Appointments]
    ([Student_IdStudent]);
GO

-- Creating foreign key on [Users_IdUser] in table 'Administrators'
ALTER TABLE [dbo].[Administrators]
ADD CONSTRAINT [FK_AdministratorUser]
    FOREIGN KEY ([Users_IdUser])
    REFERENCES [dbo].[Users]
        ([IdUser])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdministratorUser'
CREATE INDEX [IX_FK_AdministratorUser]
ON [dbo].[Administrators]
    ([Users_IdUser]);
GO

-- Creating foreign key on [Users_IdUser] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_StudentUser]
    FOREIGN KEY ([Users_IdUser])
    REFERENCES [dbo].[Users]
        ([IdUser])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentUser'
CREATE INDEX [IX_FK_StudentUser]
ON [dbo].[Students]
    ([Users_IdUser]);
GO

-- Creating foreign key on [Procedure_IdProcedure] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_ProcedureAppointment]
    FOREIGN KEY ([Procedure_IdProcedure])
    REFERENCES [dbo].[Procedures]
        ([IdProcedure])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProcedureAppointment'
CREATE INDEX [IX_FK_ProcedureAppointment]
ON [dbo].[Appointments]
    ([Procedure_IdProcedure]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------