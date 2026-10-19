using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Dominio.Entidades;

namespace TiendaProductos.Aplicacion.CasosDeUso.Productos.Consultas.FiltrarProductos
{
    internal static class MapeadorExtension
    {
        internal static ProductoFiltradoDTO AProductoFiltradoDTO(this Producto producto)
        {
            return new ProductoFiltradoDTO(
                Id: producto.Id,
                Nombre: producto.Nombre,
                Precio: producto.Precio.Monto,
                Moneda: producto.Precio.Moneda
            );
        }
    }
}
