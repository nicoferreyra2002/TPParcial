using System;
using System.Data.SqlClient;

public class ManejadorPersistencia
{
    // Cadena de conexión de ejemplo (debe ser configurada por el usuario)
    private readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Database=LabReservasDB;Integrated Security=True;";

    public ManejadorPersistencia()
    {
        // En un proyecto real, se inicializaría la conexión o se verificaría el estado de la DB
    }

    // Método de ejemplo para guardar datos (simula la interacción con SQL Server)
    public void GuardarReserva(Reserva reserva)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Aquí iría el comando SQL para INSERT o UPDATE
                Console.WriteLine($"[DB] Guardando Reserva {reserva.Id} en SQL Server.");
            }
        }
        catch (Exception ex)
        {
            // Requisito: Implementar excepciones para todas las operaciones de movimiento de datos
            throw new DataMovementException($"Error al intentar guardar la reserva en la DB: {ex.Message}");
        }
    }

    // Implementar otros métodos como ObtenerDatos, EliminarDatos, etc.
}