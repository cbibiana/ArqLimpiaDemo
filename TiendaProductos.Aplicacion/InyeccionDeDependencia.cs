using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Aplicacion.CasosDeUso.Productos.Comandos.ActualizarProducto;
using TiendaProductos.Aplicacion.CasosDeUso.Productos.Comandos.AjusteInventario;
using TiendaProductos.Aplicacion.CasosDeUso.Productos.Comandos.CrearProducto;
using TiendaProductos.Aplicacion.CasosDeUso.Productos.Consultas.FiltrarProductos;
using TiendaProductos.Aplicacion.CasosDeUso.Productos.Consultas.ObtenerProductoPorId;
using TiendaProductos.Aplicacion.Utilidades.Mediador;

namespace TiendaProductos.Aplicacion;

public static class InyeccionDeDependencia
{
    public static IServiceCollection AgregarAplicacion(this IServiceCollection services)
    {
       
        services.AddTransient<IMediador, MediadoSimple>();
        services.AddScoped<IRequestHandler<ComandoCrearProducto, Guid>, CasoDeUsoCrearProducto>();
        services.AddScoped<IRequestHandler<ComandoActualizarProducto>, CasoDeUsoActualizarProducto>();
        services.AddScoped<IRequestHandler<ComandoAjusteInventario>, CasoDeUsoAjusteInventario>();
        services.AddScoped<IRequestHandler<ConsultaObtenerProductoPorId, ProductoDetalleDTO>, CasoDeUsoObtenerPorId>();
        services.AddScoped<IRequestHandler<ConsultaFiltrarProductos, List<ProductoFiltradoDTO>>, CasoDeUsoFiltrarProductos>();

        return services;
    }
}
