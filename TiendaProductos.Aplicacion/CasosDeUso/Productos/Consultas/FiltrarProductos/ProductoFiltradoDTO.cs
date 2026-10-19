using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaProductos.Aplicacion.CasosDeUso.Productos.Consultas.FiltrarProductos
{
    public record ProductoFiltradoDTO(Guid Id, string Nombre, decimal Precio, string Moneda);
   
}
