using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Aplicacion.Contratos;
using TiendaProductos.Aplicacion.Excepciones;
using TiendaProductos.Aplicacion.Utilidades.Mediador;

namespace TiendaProductos.Aplicacion.CasosDeUso.Productos.Consultas.ObtenerProductoPorId
{
    internal class CasoDeUsoObtenerPorId : IRequestHandler<ConsultaObtenerProductoPorId, ProductoDetalleDTO>
    {
        private readonly IRepositorioProductos _repositorio;

        public CasoDeUsoObtenerPorId(IRepositorioProductos repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ProductoDetalleDTO> Handle(ConsultaObtenerProductoPorId request)
        {
            var producto = await _repositorio.ObtenerPorId(request.IdProducto);

            if (producto is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            return producto.AProductoDetalleDTO();
        }
    }
}
