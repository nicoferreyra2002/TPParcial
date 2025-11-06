using System.Collections.Generic;
using System.Linq;

// Requisito: Implementar repositorios
public class RepositorioLaboratorio : IRepositorio<Laboratorio>
{
    private List<Laboratorio> _laboratorios = new List<Laboratorio>();
    private int _nextId = 1;

    // Dependencia: Necesitas una referencia al repositorio de reservas
    private RepositorioReserva _repositorioReserva;

    public RepositorioLaboratorio(RepositorioReserva repoReserva)
    {
        _repositorioReserva = repoReserva;
        // Opcional: Cargar los 6 laboratorios iniciales aquí.
    }

    public void Agregar(Laboratorio lab)
    {
        lab.NumeroAsignado = _nextId++;
        _laboratorios.Add(lab);
        // Aquí iría la llamada a ManejadorPersistencia si volcamos a DB
    }

    public void Eliminar(int id)
    {
        // Requisito: NO se podrá eliminar un laboratorio si tiene reservas asignadas.
        var reservasAsignadas = _repositorioReserva.ObtenerPorLaboratorio(id);

        if (reservasAsignadas.Any())
        {
            // Requisito: advertir que se perderán las reservas (listarlas)
            string detalles = string.Join(", ", reservasAsignadas.Select(r => r.Asignatura));
            throw new LaboratorioReservadoException($"El laboratorio {id} no puede eliminarse. Tiene reservas asignadas: {detalles}");
        }

        var lab = ObtenerPorId(id);
        if (lab != null)
        {
            _laboratorios.Remove(lab);
        }
        else
        {
            throw new KeyNotFoundException($"Laboratorio con ID {id} no encontrado.");
        }
    }

    public List<Laboratorio> ObtenerTodos()
    {
        return _laboratorios;
    }

    // Implementa el resto de los métodos (Modificar, ObtenerPorId)
    public void Modificar(Laboratorio entidad) { /* Lógica de modificación */ }
    public Laboratorio ObtenerPorId(int id) { return _laboratorios.FirstOrDefault(l => l.NumeroAsignado == id); }
}