using Microsoft.AspNetCore.Mvc;
using TiendaProductos.Aplicacion.CasosDeUso.Productos.Comandos.ActualizarProducto;
using TiendaProductos.Aplicacion.CasosDeUso.Productos.Comandos.AjusteInventario;
using TiendaProductos.Aplicacion.CasosDeUso.Productos.Comandos.CrearProducto;
using TiendaProductos.Aplicacion.CasosDeUso.Productos.Consultas.FiltrarProductos;
using TiendaProductos.Aplicacion.CasosDeUso.Productos.Consultas.ObtenerProductoPorId;
using TiendaProductos.Aplicacion.Utilidades.Mediador;
using TiendaProductos.WebAPI.DTOs;

namespace TiendaProductos.WebAPI.Controllers;

[Route("api/productos")]
public class ProductosController(IMediador mediador) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoDetalleDTO>> Get(Guid id)
    {
        var consulta = new ConsultaObtenerProductoPorId(id);
        var producto = await mediador.Enviar(consulta);
        return producto;
    }

    [HttpGet("filtrado")]
    public async Task<ActionResult<List<ProductoFiltradoDTO>>> GetFiltrar(string? nombre, bool? activo)
    {
        var consulta = new ConsultaFiltrarProductos(nombre, activo);
        return await mediador.Enviar(consulta);

    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CrearProductoDTO modelo)
    {
        var comando = new ComandoCrearProducto (
            
            Nombre: modelo.Nombre,
            Descripcion: modelo.Descripcion,
            Precio: modelo.Precio,
            Moneda: modelo.Moneda,
            InventarioInicial: modelo.InventarioInicial
        );

        var id = await mediador.Enviar(comando);
        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] ActualizarProductoDTO modelo)
    {
        var comando = new ComandoActualizarProducto(
            Id: id,
            Nombre: modelo.Nombre,
            Descripcion: modelo.Descripcion,
            Precio: modelo.Precio,
            Moneda: modelo.Moneda,
            Activo: modelo.Activo
        );

        await mediador.Enviar(comando);
        return NoContent();
    }

    [HttpPost("{id}/inventario")]
    public async Task<ActionResult> AjusteInventario(Guid id, [FromBody] AjusteInventarioDTO modelo)
    {
        var comando = new ComandoAjusteInventario(
            IdProducto: id,
            Delta: modelo.Delta
        );

        await mediador.Enviar(comando);
        return NoContent();
    }
}
