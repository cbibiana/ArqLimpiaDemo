using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Aplicacion.Utilidades.Mediador;

namespace TiendaProductos.Aplicacion.CasosDeUso.Productos.Consultas.ObtenerProductoPorId
{
    public record ConsultaObtenerProductoPorId(Guid IdProducto) : IRequest<ProductoDetalleDTO>
    {
    }

}
