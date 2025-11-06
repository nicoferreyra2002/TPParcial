CREATE DATABASE LabReservasDB;
GO

USE LabReservasDB;
GO

CREATE TABLE Laboratorios (
    NumeroAsignado INT IDENTITY(1,1) PRIMARY KEY,
    UbicacionPiso NVARCHAR(200) NULL,
    CapacidadPuestos INT NOT NULL
);

CREATE TABLE Reservas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Carrera NVARCHAR(200),
    Asignatura NVARCHAR(200),
    Anio INT,
    Comision NVARCHAR(50),
    Profesor NVARCHAR(200),
    FechaComienzo DATETIME NULL,
    FechaFinalizacion DATETIME NULL,
    Frecuencia NVARCHAR(50) NULL,
    LaboratorioId INT NULL,
    FOREIGN KEY (LaboratorioId) REFERENCES Laboratorios(NumeroAsignado)
);