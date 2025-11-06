using System.Collections.Generic;
using System.Linq;
using TPParcial.Modelo;

// Corregido: Debe ser una CLASE, no una INTERFAZ
public class RepositorioReserva : IRepositorio<Reserva>
{
    private List<Reserva> _reservas = new List<Reserva>();
    private int _nextId = 1;

    // Simulación de la DB para el ejercicio (debería usar ManejadorPersistencia)
    private ManejadorPersistencia _dbManager = new ManejadorPersistencia();

    public void Agregar(Reserva reserva)
    {
        reserva.Id = _nextId++;
        _reservas.Add(reserva);
        // Implementar excepción para movimiento de datos
        _dbManager.GuardarReserva(reserva); // Simula el volcado a DB
    }

    public void Eliminar(int id)
    {
        var reserva = ObtenerPorId(id);
        if (reserva != null)
        {
            _reservas.Remove(reserva);
            // _dbManager.EliminarDatos(reserva); // Llamada de ejemplo a DB
        }
        else
        {
            throw new KeyNotFoundException($"Reserva con ID {id} no encontrada.");
        }
    }

    // Método Modificar: Agregado para cumplir el contrato de IRepositorio<T>
    public void Modificar(Reserva entidad)
    {
        var reservaExistente = ObtenerPorId(entidad.Id);
        if (reservaExistente == null)
        {
            throw new KeyNotFoundException($"No se puede modificar la Reserva con ID {entidad.Id} porque no existe.");
        }

        // Lógica de Modificación: Reemplazar propiedades
        reservaExistente.Carrera = entidad.Carrera;
        reservaExistente.Asignatura = entidad.Asignatura;
        reservaExistente.Profesor = entidad.Profesor;
        // ... modificar todas las propiedades necesarias

        // Opcional: Llamada a la DB si se usa persistencia
        // _dbManager.GuardarReserva(reservaExistente);
    }

    // Métodos para cumplir los requisitos de consulta
    public Reserva ObtenerPorId(int id)
    {
        return _reservas.FirstOrDefault(r => r.Id == id);
    }

    public List<Reserva> ObtenerTodos()
    {
        return _reservas;
    }

    // Utilizado por RepositorioLaboratorio para verificar si hay reservas
    public List<Reserva> ObtenerPorLaboratorio(int labId)
    {
        // Uso de LINQ y Lambda
        return _reservas.Where(r => r.LaboratorioAsignado != null && r.LaboratorioAsignado.NumeroAsignado == labId).ToList();
    }
}