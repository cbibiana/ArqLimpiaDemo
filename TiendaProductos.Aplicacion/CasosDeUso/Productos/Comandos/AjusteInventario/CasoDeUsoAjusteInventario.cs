using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Aplicacion.Contratos;
using TiendaProductos.Aplicacion.Excepciones;
using TiendaProductos.Aplicacion.Utilidades.Mediador;

namespace TiendaProductos.Aplicacion.CasosDeUso.Productos.Comandos.AjusteInventario;

internal class CasoDeUsoAjusteInventario(IRepositorioProductos repositorioProductos) : IRequestHandler<ComandoAjusteInventario>
{
    public async Task Handle(ComandoAjusteInventario request)
    {
        var producto = await repositorioProductos.ObtenerPorId(request.IdProducto);
        
        if (producto is null)
        {
            throw new ExcepcionNoEncontrado();
        }

        producto.AjustarInventario(request.Delta);

        await repositorioProductos.Actualizar(producto);

    }
}
