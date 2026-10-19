using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Dominio.Entidades;

namespace TiendaProductos.Aplicacion.CasosDeUso.Productos.Consultas.ObtenerProductoPorId;

internal static class MapeadorExtension
{
    internal static ProductoDetalleDTO AProductoDetalleDTO(this Producto producto)
    {
        return new ProductoDetalleDTO(
            Id: producto.Id,
            Nombre: producto.Nombre,
            Descripcion: producto.Descripcion,
            Precio: producto.Precio.Monto,
            Moneda: producto.Precio.Moneda,
            Inventario: producto.CantidadInventario.Valor,
            Activo: producto.Activo
        );
    }
}
