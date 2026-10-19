using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Dominio.Entidades;

namespace TiendaProductos.Aplicacion.Contratos;

public interface IRepositorioProductos
{
    Task Agregar(Producto producto);
    Task <bool> Existe(string nombre);
    Task<Producto?> ObtenerPorId(Guid id);
    Task Actualizar(Producto producto);
    Task<List<Producto>> ObtenerFiltrado(string? nombre, bool? activo);
}
