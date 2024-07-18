IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Course] (
    [CourseId] int NOT NULL IDENTITY,
    [CourseName] nvarchar(50) NULL,
    [AmountLimit] int NULL,
    [CourseWeek] nvarchar(50) NULL,
    [CourseTime] nvarchar(50) NULL,
    CONSTRAINT [PK__Course__C92D71A72310B94D] PRIMARY KEY ([CourseId])
);
GO

CREATE TABLE [Material] (
    [MaterialId] int NOT NULL IDENTITY,
    [CreateTime] datetime NULL,
    [UpdateTime] datetime NULL,
    [FileName] nvarchar(100) NULL,
    [FileType] nvarchar(50) NULL,
    CONSTRAINT [PK__Material__C50610F7CA45FD2A] PRIMARY KEY ([MaterialId])
);
GO

CREATE TABLE [Student] (
    [StudentId] int NOT NULL IDENTITY,
    [StudentName] nvarchar(50) NULL,
    [Email] nvarchar(50) NULL,
    [Department] nvarchar(50) NULL,
    [SPassword] nvarchar(50) NULL,
    CONSTRAINT [PK__Student__32C52B99986BB5C6] PRIMARY KEY ([StudentId])
);
GO

CREATE TABLE [Has] (
    [HasId] int NOT NULL IDENTITY,
    [MaterialId] int NULL,
    [CourseId] int NULL,
    CONSTRAINT [PK__Has__C8ABBCAD3C393339] PRIMARY KEY ([HasId]),
    CONSTRAINT [FK_CourseMaterial] FOREIGN KEY ([CourseId]) REFERENCES [Course] ([CourseId]),
    CONSTRAINT [FK_Material] FOREIGN KEY ([MaterialId]) REFERENCES [Material] ([MaterialId])
);
GO

CREATE TABLE [Enroll] (
    [EnrollId] int NOT NULL IDENTITY,
    [StudentId] int NULL,
    [CourseId] int NULL,
    [Score] decimal(5,2) NULL,
    CONSTRAINT [PK__Enroll__405B562C4C58DEEE] PRIMARY KEY ([EnrollId]),
    CONSTRAINT [FK_Course] FOREIGN KEY ([CourseId]) REFERENCES [Course] ([CourseId]),
    CONSTRAINT [FK_Student] FOREIGN KEY ([StudentId]) REFERENCES [Student] ([StudentId])
);
GO

CREATE INDEX [IX_Enroll_CourseId] ON [Enroll] ([CourseId]);
GO

CREATE INDEX [IX_Enroll_StudentId] ON [Enroll] ([StudentId]);
GO

CREATE INDEX [IX_Has_CourseId] ON [Has] ([CourseId]);
GO

CREATE INDEX [IX_Has_MaterialId] ON [Has] ([MaterialId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240718100508_InitialCreate', N'8.0.7');
GO

COMMIT;
GO

