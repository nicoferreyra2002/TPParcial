using TPParcial.Modelo;
using System.Collections.Generic;

public class ReporteController
{
    private RepositorioReserva _repoReserva;
    private RepositorioLaboratorio _repoLab;

    public ReporteController(RepositorioReserva repoReserva, RepositorioLaboratorio repoLab)
    {
        _repoReserva = repoReserva;
        _repoLab = repoLab;
    }

    // Requisito: Confeccionaran diversos reportes por pantalla e impresos.
    public string GenerarReporteUsoLaboratorios()
    {
        var totalReservas = _repoReserva.ObtenerTodos().Count;
        var totalLabs = _repoLab.ObtenerTodos().Count;

        return $"Reporte Generado:\nTotal de Laboratorios: {totalLabs}\nTotal de Reservas activas: {totalReservas}\n(Lógica de detalles de uso pendiente de implementación)";
    }
}
