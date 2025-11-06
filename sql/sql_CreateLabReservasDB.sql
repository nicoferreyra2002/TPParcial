CREATE DATABASE LabReservasDB;
GO

USE LabReservasDB;
GO

-- Crear tabla Laboratorios si no existe
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Laboratorios]') AND type in (N'U'))
BEGIN
    CREATE TABLE dbo.Laboratorios (
        NumeroAsignado INT IDENTITY(1,1) PRIMARY KEY,
        UbicacionPiso NVARCHAR(200) NULL,
        CapacidadPuestos INT NOT NULL
    );
END
GO

-- Crear tabla Reservas si no existe
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservas]') AND type in (N'U'))
BEGIN
    CREATE TABLE dbo.Reservas (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Carrera NVARCHAR(200) NULL,
        Asignatura NVARCHAR(200) NULL,
        Anio INT NULL,
        Comision NVARCHAR(50) NULL,
        Profesor NVARCHAR(200) NULL,
        FechaComienzo DATETIME NULL,
        FechaFinalizacion DATETIME NULL,
        Frecuencia NVARCHAR(50) NULL,
        LaboratorioId INT NULL,
        CONSTRAINT FK_Reservas_Laboratorios FOREIGN KEY (LaboratorioId) REFERENCES dbo.Laboratorios(NumeroAsignado)
    );
END
GO