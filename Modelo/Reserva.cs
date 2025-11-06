using System;

namespace TPParcial.Modelo
{
    // Requisito: Aplicar principios de POO y utilizar clases abstractas
    public abstract class Reserva
    {
        public int Id { get; set; } // ID para uso en Repositorio
        public string Carrera { get; set; } // Para todas las reservas
        public string Asignatura { get; set; } // Para todas las reservas
        public int Anio { get; set; } // Para todas las reservas
        public string Comision { get; set; } // Para todas las reservas
        public string Profesor { get; set; } // Para todas las reservas
        public Laboratorio LaboratorioAsignado { get; set; }

        // Constructor base
        protected Reserva(string carrera, string asignatura, int anio, string comision, string profesor)
        {
            if (string.IsNullOrWhiteSpace(profesor))
            {
                throw new InvalidInputException("El campo Profesor es obligatorio.");
            }

            this.Carrera = carrera;
            this.Asignatura = asignatura;
            this.Anio = anio;
            this.Comision = comision;
            this.Profesor = profesor;
        }

        // Requisito: Utilizar métodos abstractos
        public abstract DateTime GetFechaComienzo();

        // Requisito: Utilizar métodos virtuales
        public virtual string ObtenerDetalleTipo()
        {
            return "Reserva genérica";
        }
    }
}