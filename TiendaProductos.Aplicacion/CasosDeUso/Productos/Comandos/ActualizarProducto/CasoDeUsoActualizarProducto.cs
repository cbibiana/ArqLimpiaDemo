using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Aplicacion.Contratos;
using TiendaProductos.Aplicacion.Excepciones;
using TiendaProductos.Aplicacion.Utilidades.Mediador;
using TiendaProductos.Dominio.ObjetoDeValor;

namespace TiendaProductos.Aplicacion.CasosDeUso.Productos.Comandos.ActualizarProducto;

internal class CasoDeUsoActualizarProducto(IRepositorioProductos repositorioProductos) : IRequestHandler<ComandoActualizarProducto>
{
    public async Task Handle(ComandoActualizarProducto request)
    {
        var producto = await repositorioProductos.ObtenerPorId(request.Id);
        if (producto is null)
        {
            throw new ExcepcionNoEncontrado();
        }
       var dinero = Dinero.Crear(request.Precio, request.Moneda);
        producto.Actualizar(request.Nombre, request.Descripcion, dinero, request.Activo);
        await repositorioProductos.Actualizar(producto);
    }
}
