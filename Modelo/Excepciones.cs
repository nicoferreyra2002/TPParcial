using System;

// Requisito: Implementar excepciones para todas las operaciones de movimiento de datos
public class DataMovementException : Exception
{
    public DataMovementException(string message) : base(message) { }
}

// Requisito: Validar entradas de datos usando excepciones
public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message) { }
}

// Excepción específica para la Baja de Laboratorio
public class LaboratorioReservadoException : Exception
{
    public LaboratorioReservadoException(string message) : base(message) { }
}