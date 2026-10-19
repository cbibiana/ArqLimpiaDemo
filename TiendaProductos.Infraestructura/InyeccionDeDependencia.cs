using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Aplicacion.Contratos;
using TiendaProductos.Infraestructura.Persistencia;
using TiendaProductos.Infraestructura.Persistencia.Respositorios;

namespace TiendaProductos.Infraestructura
{
    public static class InyeccionDeDependencia
    {
        public static IServiceCollection AgregarInfraestructura(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("name=DefaultConnection"));
            
            services.AddScoped<IRepositorioProductos, RepositoriosProductos>();
            return services;
        }
    }
}
