using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaProductos.Aplicacion.CasosDeUso.Productos.Consultas.ObtenerProductoPorId
{
    public record ProductoDetalleDTO(Guid Id, string Nombre, string? Descripcion, decimal Precio, string Moneda, int Inventario, bool Activo)
    {
    }

}
