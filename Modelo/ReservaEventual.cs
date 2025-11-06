using System;
using TPParcial.Modelo;

public class ReservaEventual : Reserva
{
    public DateTime FechaComienzoReserva { get; set; }
    public int CantidadSemanas { get; set; }

    public ReservaEventual(string carrera, string asignatura, int anio, string comision, string profesor,
                           DateTime inicio, int semanas)
        : base(carrera, asignatura, anio, comision, profesor)
    {
        FechaComienzoReserva = inicio;
        CantidadSemanas = semanas;
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