using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Aplicacion.Utilidades.Mediador;

namespace TiendaProductos.Aplicacion.CasosDeUso.Productos.Consultas.FiltrarProductos
{
    public record ConsultaFiltrarProductos(string? Nombre, bool? Activo) : IRequest<List<ProductoFiltradoDTO>>;
 

}
