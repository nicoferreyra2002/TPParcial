using System;

public class ReservaEventual : Reserva
{
    public DateTime FechaComienzoReserva { get; set; } // Requisito
    public int CantidadSemanas { get; set; } // Requisito "¿Cuantas semanas?"

    public ReservaEventual(string carrera, string asignatura, int anio, string comision, string profesor,
                           DateTime fechaComienzo, int semanas)
        : base(carrera, asignatura, anio, comision, profesor)
    {
        if (semanas <= 0)
        {
            throw new InvalidInputException("La cantidad de semanas debe ser mayor a cero.");
        }

        this.FechaComienzoReserva = fechaComienzo;
        this.CantidadSemanas = semanas;
    }

    public override DateTime GetFechaComienzo()
    {
        return FechaComienzoReserva;
    }

    public override string ObtenerDetalleTipo()
    {
        return $"Eventual ({CantidadSemanas} semanas)";
    }
}