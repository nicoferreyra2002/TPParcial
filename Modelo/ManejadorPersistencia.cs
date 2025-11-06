using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TPParcial.Modelo;

namespace TPParcial.Modelo
{
    public class ManejadorPersistencia
    {
        private readonly string _connectionString;

        public ManejadorPersistencia()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LabReservasDb"]?.ConnectionString;
            if (string.IsNullOrWhiteSpace(_connectionString))
                throw new InvalidOperationException("Falta la cadena 'LabReservasDb' en App.config");
        }

        public void GuardarReserva(Reserva reserva)
        {
            if (reserva == null) throw new ArgumentNullException(nameof(reserva));

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = connection.CreateCommand())
                {
                    connection.Open();

                    // Preparar valores comunes
                    var carrera = (object)reserva.Carrera ?? DBNull.Value;
                    var asignatura = (object)reserva.Asignatura ?? DBNull.Value;
                    var anio = (object)reserva.Anio;
                    var comision = (object)reserva.Comision ?? DBNull.Value;
                    var profesor = (object)reserva.Profesor ?? DBNull.Value;
                    DateTime? fechaComienzo = null;
                    DateTime? fechaFinalizacion = null;
                    object frecuencia = DBNull.Value;

                    // Rellenar según tipo concreto
                    if (reserva is ReservaCuatrimestral rc)
                    {
                        fechaComienzo = rc.FechaYHoraComienzo;
                        fechaFinalizacion = rc.FechaYHoraFinalizacion;
                        frecuencia = (object)rc.Frecuencia ?? DBNull.Value;
                    }
                    else if (reserva is ReservaEventual re)
                    {
                        fechaComienzo = re.FechaComienzoReserva;
                        // puedes almacenar fecha final calculada o NULL; aquí calculo fin por semanas
                        fechaFinalizacion = re.FechaComienzoReserva.AddDays(re.CantidadSemanas * 7);
                        frecuencia = (object)$"{re.CantidadSemanas} semanas";
                    }

                    command.CommandText = @"
INSERT INTO dbo.Reservas
    (Carrera, Asignatura, Anio, Comision, Profesor, FechaComienzo, FechaFinalizacion, Frecuencia, LaboratorioId)
VALUES
    (@Carrera, @Asignatura, @Anio, @Comision, @Profesor, @FechaComienzo, @FechaFinalizacion, @Frecuencia, @LaboratorioId);
SELECT CAST(SCOPE_IDENTITY() AS int);";

                    command.Parameters.AddWithValue("@Carrera", carrera);
                    command.Parameters.AddWithValue("@Asignatura", asignatura);
                    command.Parameters.AddWithValue("@Anio", anio ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Comision", comision);
                    command.Parameters.AddWithValue("@Profesor", profesor);
                    command.Parameters.Add("@FechaComienzo", SqlDbType.DateTime).Value = (object)fechaComienzo ?? DBNull.Value;
                    command.Parameters.Add("@FechaFinalizacion", SqlDbType.DateTime).Value = (object)fechaFinalizacion ?? DBNull.Value;
                    command.Parameters.AddWithValue("@Frecuencia", frecuencia);
                    command.Parameters.AddWithValue("@LaboratorioId", (object)reserva.LaboratorioAsignado?.NumeroAsignado ?? DBNull.Value);

                    // Ejecutar y obtener id
                    var result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int newId))
                    {
                        reserva.Id = newId;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataMovementException($"Error SQL al guardar reserva: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new DataMovementException($"Error al intentar guardar la reserva: {ex.Message}");
            }
        }
    }
}