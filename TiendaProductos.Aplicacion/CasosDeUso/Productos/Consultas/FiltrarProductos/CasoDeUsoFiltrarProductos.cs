using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Aplicacion.Contratos;
using TiendaProductos.Aplicacion.Utilidades.Mediador;
using TiendaProductos.Dominio.Entidades;

namespace TiendaProductos.Aplicacion.CasosDeUso.Productos.Consultas.FiltrarProductos
{
    internal class CasoDeUsoFiltrarProductos(IRepositorioProductos repositorio) : IRequestHandler<ConsultaFiltrarProductos, List<ProductoFiltradoDTO>>
    {
        public async Task<List<ProductoFiltradoDTO>> Handle(ConsultaFiltrarProductos request)
        {
            List<Producto> productos = await repositorio.ObtenerFiltrado(request.Nombre, request.Activo);
            var productosDTO = productos.Select(p => p.AProductoFiltradoDTO()).ToList();
            return productosDTO;
        }
    }
}
