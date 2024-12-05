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

CREATE TABLE [Perfil] (
    [Cod] int NOT NULL IDENTITY,
    [Nome] nvarchar(60) NOT NULL,
    [CPF] int NOT NULL,
    [DataDeNascimento] datetime2 NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Senha] nvarchar(10) NOT NULL,
    CONSTRAINT [PK_Perfil] PRIMARY KEY ([Cod])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241125021715_Initial', N'8.0.11');
GO

COMMIT;
GO

