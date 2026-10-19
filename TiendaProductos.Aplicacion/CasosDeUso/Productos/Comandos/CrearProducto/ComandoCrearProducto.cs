using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Aplicacion.Utilidades.Mediador;

namespace TiendaProductos.Aplicacion.CasosDeUso.Productos.Comandos.CrearProducto;

public record ComandoCrearProducto
(
    string Nombre,
    string? Descripcion,
    decimal Precio,
    string Moneda,
    int InventarioInicial
) : IRequest<Guid>;
