using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Aplicacion.Utilidades.Mediador;

namespace TiendaProductos.Aplicacion.CasosDeUso.Productos.Comandos.AjusteInventario;

public record ComandoAjusteInventario(Guid IdProducto, int Delta) : IRequest;

