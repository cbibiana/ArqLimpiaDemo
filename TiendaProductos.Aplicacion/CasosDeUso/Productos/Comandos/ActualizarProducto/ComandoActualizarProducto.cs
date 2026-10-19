using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Aplicacion.Utilidades.Mediador;

namespace TiendaProductos.Aplicacion.CasosDeUso.Productos.Comandos.ActualizarProducto;

public record ComandoActualizarProducto(
    Guid Id,
    string Nombre,
    string? Descripcion,
    decimal Precio,
    string Moneda,
    bool Activo
) : IRequest;