IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Doctor] (
    [IdDoctor] int NOT NULL IDENTITY,
    [FirstName] nvarchar(100) NULL,
    [LastName] nvarchar(100) NULL,
    [Email] nvarchar(100) NULL,
    CONSTRAINT [PK_Doctor] PRIMARY KEY ([IdDoctor])
);

GO

CREATE TABLE [Medicament] (
    [IdMedicament] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NULL,
    [Description] nvarchar(100) NULL,
    [Type] nvarchar(100) NULL,
    CONSTRAINT [PK_Medicament] PRIMARY KEY ([IdMedicament])
);

GO

CREATE TABLE [Patient] (
    [IdPateient] int NOT NULL IDENTITY,
    [FirstName] nvarchar(100) NULL,
    [LastName] nvarchar(100) NULL,
    [Email] nvarchar(100) NULL,
    CONSTRAINT [PK_Patient] PRIMARY KEY ([IdPateient])
);

GO

CREATE TABLE [Prescription_Medicament] (
    [IdMedicament] int NOT NULL,
    [IdPrescription] int NOT NULL,
    [Dose] int NULL,
    [Details] nvarchar(100) NULL,
    [MedicamentIdMedicament] int NULL,
    CONSTRAINT [PK_Prescription_Medicament] PRIMARY KEY ([IdMedicament], [IdPrescription]),
    CONSTRAINT [FK_Prescription_Medicament_Medicament_MedicamentIdMedicament] FOREIGN KEY ([MedicamentIdMedicament]) REFERENCES [Medicament] ([IdMedicament]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Prescription] (
    [IdPrescription] int NOT NULL IDENTITY,
    [Date] datetime2 NOT NULL,
    [DueDate] datetime2 NOT NULL,
    [Patient] int NULL,
    [Doctor] int NULL,
    CONSTRAINT [PK_Prescription] PRIMARY KEY ([IdPrescription]),
    CONSTRAINT [FK_Prescription_Doctor_Doctor] FOREIGN KEY ([Doctor]) REFERENCES [Doctor] ([IdDoctor]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Prescription_Patient_Patient] FOREIGN KEY ([Patient]) REFERENCES [Patient] ([IdPateient]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Prescription_Doctor] ON [Prescription] ([Doctor]);

GO

CREATE INDEX [IX_Prescription_Patient] ON [Prescription] ([Patient]);

GO

CREATE INDEX [IX_Prescription_Medicament_MedicamentIdMedicament] ON [Prescription_Medicament] ([MedicamentIdMedicament]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200611101352_M1', N'3.1.5');

GO

ALTER TABLE [Prescription] DROP CONSTRAINT [FK_Prescription_Patient_Patient];

GO

ALTER TABLE [Patient] DROP CONSTRAINT [PK_Patient];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Patient]') AND [c].[name] = N'IdPateient');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Patient] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Patient] DROP COLUMN [IdPateient];

GO

ALTER TABLE [Patient] ADD [IdPatient] int NOT NULL IDENTITY;

GO

ALTER TABLE [Patient] ADD CONSTRAINT [PK_Patient] PRIMARY KEY ([IdPatient]);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdDoctor', N'Email', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Doctor]'))
    SET IDENTITY_INSERT [Doctor] ON;
INSERT INTO [Doctor] ([IdDoctor], [Email], [FirstName], [LastName])
VALUES (1, N'jkowalski@wp.pl', N'Jan', N'Kowalski');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdDoctor', N'Email', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Doctor]'))
    SET IDENTITY_INSERT [Doctor] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPatient', N'Email', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Patient]'))
    SET IDENTITY_INSERT [Patient] ON;
INSERT INTO [Patient] ([IdPatient], [Email], [FirstName], [LastName])
VALUES (1, N'pnowak@wp.pl', N'Piotr', N'Nowak');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPatient', N'Email', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Patient]'))
    SET IDENTITY_INSERT [Patient] OFF;

GO

ALTER TABLE [Prescription] ADD CONSTRAINT [FK_Prescription_Patient_Patient] FOREIGN KEY ([Patient]) REFERENCES [Patient] ([IdPatient]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200611103751_M2', N'3.1.5');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPrescription', N'Date', N'Doctor', N'DueDate', N'Patient') AND [object_id] = OBJECT_ID(N'[Prescription]'))
    SET IDENTITY_INSERT [Prescription] ON;
INSERT INTO [Prescription] ([IdPrescription], [Date], [Doctor], [DueDate], [Patient])
VALUES (1, '2020-06-11T12:47:43.2813360+02:00', NULL, '2021-06-11T12:47:43.2873661+02:00', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPrescription', N'Date', N'Doctor', N'DueDate', N'Patient') AND [object_id] = OBJECT_ID(N'[Prescription]'))
    SET IDENTITY_INSERT [Prescription] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200611104743_M3', N'3.1.5');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMedicament', N'Description', N'Name', N'Type') AND [object_id] = OBJECT_ID(N'[Medicament]'))
    SET IDENTITY_INSERT [Medicament] ON;
INSERT INTO [Medicament] ([IdMedicament], [Description], [Name], [Type])
VALUES (1, N'Pomocniczo w leczeniu grypy', N'Aspiryna', N'Niesteroidowy lek przeciwzapalny');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMedicament', N'Description', N'Name', N'Type') AND [object_id] = OBJECT_ID(N'[Medicament]'))
    SET IDENTITY_INSERT [Medicament] OFF;

GO

UPDATE [Prescription] SET [Date] = '2020-06-11T12:55:40.1064472+02:00', [DueDate] = '2021-06-11T12:55:40.1095327+02:00'
WHERE [IdPrescription] = 1;
SELECT @@ROWCOUNT;


GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMedicament', N'IdPrescription', N'Details', N'Dose', N'MedicamentIdMedicament') AND [object_id] = OBJECT_ID(N'[Prescription_Medicament]'))
    SET IDENTITY_INSERT [Prescription_Medicament] ON;
INSERT INTO [Prescription_Medicament] ([IdMedicament], [IdPrescription], [Details], [Dose], [MedicamentIdMedicament])
VALUES (1, 1, N'Bez refundacji', 50, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMedicament', N'IdPrescription', N'Details', N'Dose', N'MedicamentIdMedicament') AND [object_id] = OBJECT_ID(N'[Prescription_Medicament]'))
    SET IDENTITY_INSERT [Prescription_Medicament] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200611105540_M4', N'3.1.5');

GO

ALTER TABLE [Prescription] DROP CONSTRAINT [FK_Prescription_Doctor_Doctor];

GO

ALTER TABLE [Prescription] DROP CONSTRAINT [FK_Prescription_Patient_Patient];

GO

DROP INDEX [IX_Prescription_Doctor] ON [Prescription];

GO

DROP INDEX [IX_Prescription_Patient] ON [Prescription];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Prescription]') AND [c].[name] = N'Doctor');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Prescription] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Prescription] DROP COLUMN [Doctor];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Prescription]') AND [c].[name] = N'Patient');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Prescription] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Prescription] DROP COLUMN [Patient];

GO

ALTER TABLE [Prescription] ADD [DoctorIdDoctor] int NULL;

GO

ALTER TABLE [Prescription] ADD [IdDoctor] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Prescription] ADD [IdPatient] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Prescription] ADD [PatientIdPatient] int NULL;

GO

UPDATE [Prescription] SET [Date] = '2020-06-11T12:59:26.1278718+02:00', [DueDate] = '2021-06-11T12:59:26.1318778+02:00', [IdDoctor] = 1, [IdPatient] = 1
WHERE [IdPrescription] = 1;
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_Prescription_DoctorIdDoctor] ON [Prescription] ([DoctorIdDoctor]);

GO

CREATE INDEX [IX_Prescription_PatientIdPatient] ON [Prescription] ([PatientIdPatient]);

GO

ALTER TABLE [Prescription] ADD CONSTRAINT [FK_Prescription_Doctor_DoctorIdDoctor] FOREIGN KEY ([DoctorIdDoctor]) REFERENCES [Doctor] ([IdDoctor]) ON DELETE NO ACTION;

GO

ALTER TABLE [Prescription] ADD CONSTRAINT [FK_Prescription_Patient_PatientIdPatient] FOREIGN KEY ([PatientIdPatient]) REFERENCES [Patient] ([IdPatient]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200611105926_M5', N'3.1.5');

GO

