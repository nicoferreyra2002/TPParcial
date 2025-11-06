using TPParcial.Modelo;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Controladores
{
    public class ReservaController
    {
        private RepositorioReserva _repositorio;

        public ReservaController(RepositorioReserva repositorio)
        {
            _repositorio = repositorio;
        }

        // --- Operaciones CRUD ---

        // Alta de Reserva
        public void AltaReserva(Reserva reserva)
        {
            // Se puede agregar lógica adicional de validación de solapamiento de horario aquí
            _repositorio.Agregar(reserva);
        }

        // Bajas y Modificaciones (implementar de manera similar a Alta)
        // public void BajaReserva(int id) { _repositorio.Eliminar(id); }
        // public void ModificarReserva(Reserva reserva) { _repositorio.Modificar(reserva); }

        // --- Consultas (Requisito: LINQ / Lambda) ---

        // Método auxiliar para carga inicial
        public List<Reserva> ObtenerTodasLasReservas()
        {
            return _repositorio.ObtenerTodos();
        }

        // Consulta de Reservas: Por asignatura
        // Requisito: Utilizar las características del lenguaje como consultas LINQ
        public List<Reserva> ConsultarPorAsignatura(string asignatura)
        {
            if (string.IsNullOrWhiteSpace(asignatura))
            {
                return ObtenerTodasLasReservas();
            }

            // Uso de LINQ y expresiones Lambda
            return _repositorio.ObtenerTodos()
                               .Where(r => r.Asignatura.Equals(asignatura, StringComparison.OrdinalIgnoreCase))
                               .ToList();
        }

        // Consulta de Reservas: Por profesor a cargo
        public List<Reserva> ConsultarPorProfesor(string profesor)
        {
            if (string.IsNullOrWhiteSpace(profesor))
            {
                return ObtenerTodasLasReservas();
            }

            // Uso de LINQ
            return _repositorio.ObtenerTodos()
                               .Where(r => r.Profesor.Equals(profesor, StringComparison.OrdinalIgnoreCase))
                               .ToList();
        }

        // Consulta de Reservas: Por fecha de reserva
        public List<Reserva> ConsultarPorFecha(DateTime fecha)
        {
            // Usamos la propiedad .Date para comparar solo la fecha sin la hora.
            // Esto funciona tanto para ReservaCuatrimestral como para Eventual debido a GetFechaComienzo().
            return _repositorio.ObtenerTodos()
                               .Where(r => r.GetFechaComienzo().Date == fecha.Date)
                               .ToList();
        }
    }
}