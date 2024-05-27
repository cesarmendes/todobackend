IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'DataBase')
BEGIN
    CREATE DATABASE [TODOLIST];
END
GO


USE TODOLIST
GO

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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240517221338_Initial')
BEGIN
    CREATE TABLE [TB_TAREFAS] (
        [ID] INT NOT NULL IDENTITY,
        [TITULO] VARCHAR(300) NOT NULL,
        [DESCRICAO] VARCHAR(3000) NOT NULL,
        [STATUS] INT NOT NULL,
        [CRIADO_EM] DATETIME NOT NULL DEFAULT '2024-05-17T19:13:38.5828867-03:00',
        CONSTRAINT [PK_TB_TAREFAS] PRIMARY KEY ([ID])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Tabela de tarefas';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_TAREFAS';
    SET @description = N'Campo com os valores de chave primária.';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_TAREFAS', 'COLUMN', N'ID';
    SET @description = N'Campo com os valores do título da tarefa.';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_TAREFAS', 'COLUMN', N'TITULO';
    SET @description = N'Campo com os valores da descrição da tarefa.';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_TAREFAS', 'COLUMN', N'DESCRICAO';
    SET @description = N'Campo com os valores do status da tarefa.';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_TAREFAS', 'COLUMN', N'STATUS';
    SET @description = N'Campo com os valores da data de criação da tarefa.';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_TAREFAS', 'COLUMN', N'CRIADO_EM';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240517221338_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240517221338_Initial', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240522131331_Status')
BEGIN
    EXEC sp_rename N'[TB_TAREFAS].[STATUS]', N'ID_STATUS', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240522131331_Status')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_TAREFAS]') AND [c].[name] = N'CRIADO_EM');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TB_TAREFAS] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [TB_TAREFAS] ADD DEFAULT '2024-05-22T10:13:31.4635576-03:00' FOR [CRIADO_EM];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240522131331_Status')
BEGIN
    CREATE TABLE [TB_STATUS] (
        [ID] INT NOT NULL IDENTITY,
        [TITULO] VARCHAR(300) NOT NULL,
        CONSTRAINT [PK_TB_STATUS] PRIMARY KEY ([ID])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Tabela com os possíveis status para uma tarefa.';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_STATUS';
    SET @description = N'Campo com os valores de chave primária.';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_STATUS', 'COLUMN', N'ID';
    SET @description = N'Campo com os valores do título da tarefa.';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_STATUS', 'COLUMN', N'TITULO';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240522131331_Status')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'TITULO') AND [object_id] = OBJECT_ID(N'[TB_STATUS]'))
        SET IDENTITY_INSERT [TB_STATUS] ON;
    EXEC(N'INSERT INTO [TB_STATUS] ([ID], [TITULO])
    VALUES (1, ''Pendente''),
    (2, ''Em andamento''),
    (3, ''Em testes''),
    (4, ''Concluído''),
    (5, ''Bloqueado'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'TITULO') AND [object_id] = OBJECT_ID(N'[TB_STATUS]'))
        SET IDENTITY_INSERT [TB_STATUS] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240522131331_Status')
BEGIN
    CREATE INDEX [IX_TB_TAREFAS_ID_STATUS] ON [TB_TAREFAS] ([ID_STATUS]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240522131331_Status')
BEGIN
    ALTER TABLE [TB_TAREFAS] ADD CONSTRAINT [FK_TB_TAREFAS_TB_STATUS_ID_STATUS] FOREIGN KEY ([ID_STATUS]) REFERENCES [TB_STATUS] ([ID]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240522131331_Status')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240522131331_Status', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240522132829_StatusOptionsAdd')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_TAREFAS]') AND [c].[name] = N'CRIADO_EM');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TB_TAREFAS] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [TB_TAREFAS] ADD DEFAULT '2024-05-22T10:28:29.0998125-03:00' FOR [CRIADO_EM];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240522132829_StatusOptionsAdd')
BEGIN
    EXEC(N'UPDATE [TB_STATUS] SET [TITULO] = ''A fazer''
    WHERE [ID] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240522132829_StatusOptionsAdd')
BEGIN
    EXEC(N'UPDATE [TB_STATUS] SET [TITULO] = ''Revisando''
    WHERE [ID] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240522132829_StatusOptionsAdd')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'TITULO') AND [object_id] = OBJECT_ID(N'[TB_STATUS]'))
        SET IDENTITY_INSERT [TB_STATUS] ON;
    EXEC(N'INSERT INTO [TB_STATUS] ([ID], [TITULO])
    VALUES (6, ''Cancelado'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'TITULO') AND [object_id] = OBJECT_ID(N'[TB_STATUS]'))
        SET IDENTITY_INSERT [TB_STATUS] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240522132829_StatusOptionsAdd')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240522132829_StatusOptionsAdd', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240525173503_DateTask')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_TAREFAS]') AND [c].[name] = N'CRIADO_EM');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [TB_TAREFAS] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [TB_TAREFAS] ALTER COLUMN [CRIADO_EM] DATETIME2 NOT NULL;
    ALTER TABLE [TB_TAREFAS] ADD DEFAULT '2024-05-25T14:35:03.3933381-03:00' FOR [CRIADO_EM];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240525173503_DateTask')
BEGIN
    ALTER TABLE [TB_TAREFAS] ADD [ATUALIZADO_EM] DATETIME2 NOT NULL DEFAULT '2024-05-25T14:35:03.3933585-03:00';
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Campo com os valores da data de atualização da tarefa.';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_TAREFAS', 'COLUMN', N'ATUALIZADO_EM';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240525173503_DateTask')
BEGIN
    ALTER TABLE [TB_TAREFAS] ADD [DATA_ENTREGA] DATETIME2 NOT NULL DEFAULT '2024-05-25T14:35:03.3933179-03:00';
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Campo com os valores da data de entrega da tarefa';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_TAREFAS', 'COLUMN', N'DATA_ENTREGA';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240525173503_DateTask')
BEGIN
    ALTER TABLE [TB_TAREFAS] ADD [DATA_INICIO] DATETIME2 NOT NULL DEFAULT '2024-05-25T14:35:03.3932838-03:00';
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Campo com os valores da data de início da tarefa';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_TAREFAS', 'COLUMN', N'DATA_INICIO';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240525173503_DateTask')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240525173503_DateTask', N'7.0.19');
END;
GO

COMMIT;
GO