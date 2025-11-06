using System;
using System.Data.SqlClient;
using System.Configuration;
using TPParcial.Modelo;

public class ManejadorPersistencia
{
    private readonly string connectionString;

    public ManejadorPersistencia()
    {
        connectionString = ConfigurationManager.ConnectionStrings["LabReservasDb"]?.ConnectionString
                           ?? throw new InvalidOperationException("Falta la cadena 'LabReservasDb' en App.config");
    }

    public void GuardarReserva(Reserva reserva)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Implementar INSERT/UPDATE parametrizado aquí
            }
        }
        catch (Exception ex)
        {
            throw new DataMovementException($"Error al intentar guardar la reserva en la DB: {ex.Message}");
        }
    }
}