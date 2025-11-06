using TPParcial.Modelo;
using System.Collections.Generic;
using System;

public class LaboratorioController
{
    private RepositorioLaboratorio _repositorioLab;

    // El controlador recibe los repositorios que necesita
    public LaboratorioController(RepositorioLaboratorio repositorioLab)
    {
        _repositorioLab = repositorioLab;
    }

    // Alta de Laboratorio
    public void AltaLaboratorio(string piso, int capacidad)
    {
        if (capacidad <= 0)
        {
            throw new InvalidInputException("La capacidad debe ser un número positivo.");
        }

        Laboratorio nuevoLab = new Laboratorio { UbicacionPiso = piso, CapacidadPuestos = capacidad };
        _repositorioLab.Agregar(nuevoLab);
    }

    // Baja de Laboratorio
    public void BajaLaboratorio(int id)
    {
        // La lógica de la restricción (verificar reservas) está en RepositorioLaboratorio.
        _repositorioLab.Eliminar(id);
    }

    // Consulta de Laboratorios: Listar todos
    public List<Laboratorio> ObtenerTodos()
    {
        return _repositorioLab.ObtenerTodos();
    }
}