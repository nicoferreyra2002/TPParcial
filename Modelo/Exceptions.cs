using System;

namespace TPParcial.Modelo
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }

    public class DataMovementException : Exception
    {
        public DataMovementException(string message) : base(message) { }
    }
}