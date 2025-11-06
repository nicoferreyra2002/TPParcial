using System;
using TPParcial.Modelo;

public class ReservaCuatrimestral : Reserva
{
    public DateTime FechaYHoraComienzo { get; set; } // Requisito [cite: 23]
    public DateTime FechaYHoraFinalizacion { get; set; } // Requisito [cite: 24]
    public string Frecuencia { get; set; } // "Semanal" o "Quincenal" [cite: 21, 25]

    public ReservaCuatrimestral(string carrera, string asignatura, int anio, string comision, string profesor,
                                DateTime inicio, DateTime fin, string frecuencia)
        : base(carrera, asignatura, anio, comision, profesor)
    {
        this.FechaYHoraComienzo = inicio;
        this.FechaYHoraFinalizacion = fin;
        this.Frecuencia = frecuencia;
    }

    public override DateTime GetFechaComienzo()
    {
        return FechaYHoraComienzo;
    }

    public override string ObtenerDetalleTipo()
    {
        return $"Cuatrimestral ({Frecuencia})";
    }
}