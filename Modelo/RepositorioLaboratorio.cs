using System;
using System.Collections.Generic;
using System.Linq;

namespace TPParcial.Modelo
{
    public class RepositorioLaboratorio : IRepositorio<Laboratorio>
    {
        private List<Laboratorio> _laboratorios = new List<Laboratorio>();
        private int _nextId = 1;
        private RepositorioReserva _repositorioReserva;

        public RepositorioLaboratorio(RepositorioReserva repoReserva)
        {
            _repositorioReserva = repoReserva ?? throw new ArgumentNullException(nameof(repoReserva));
        }

        public void Agregar(Laboratorio lab)
        {
            lab.NumeroAsignado = _nextId++;
            _laboratorios.Add(lab);
        }

        public void Eliminar(int id)
        {
            var reservas = _repositorioReserva.ObtenerPorLaboratorio(id);
            if (reservas != null && reservas.Count > 0)
                throw new InvalidOperationException("No se puede eliminar el laboratorio: existen reservas asignadas.");

            var lab = ObtenerPorId(id);
            if (lab == null) throw new KeyNotFoundException($"Laboratorio {id} no encontrado.");
            _laboratorios.Remove(lab);
        }

        public List<Laboratorio> ObtenerTodos() => _laboratorios;

        public void Modificar(Laboratorio entidad)
        {
            var existing = ObtenerPorId(entidad.NumeroAsignado);
            if (existing == null) throw new KeyNotFoundException($"Laboratorio {entidad.NumeroAsignado} no encontrado.");
            existing.UbicacionPiso = entidad.UbicacionPiso;
            existing.CapacidadPuestos = entidad.CapacidadPuestos;
        }

        public Laboratorio ObtenerPorId(int id) => _laboratorios.FirstOrDefault(l => l.NumeroAsignado == id);
    }
}