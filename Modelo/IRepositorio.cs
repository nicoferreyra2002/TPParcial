using System.Collections.Generic;

// Requisito: Utilizar Interfaces
public interface IRepositorio<T> where T : class
{
    // CRUD Básico
    void Agregar(T entidad);
    void Eliminar(int id);
    void Modificar(T entidad);
    T ObtenerPorId(int id);
    List<T> ObtenerTodos();
}