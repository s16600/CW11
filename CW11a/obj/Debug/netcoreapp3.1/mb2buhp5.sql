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

