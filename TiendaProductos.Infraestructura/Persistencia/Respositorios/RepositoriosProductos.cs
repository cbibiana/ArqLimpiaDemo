using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Aplicacion.Contratos;
using TiendaProductos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace TiendaProductos.Infraestructura.Persistencia.Respositorios
{
    internal class RepositoriosProductos(ApplicationDbContext context) : IRepositorioProductos
    {
        public async Task Actualizar(Producto producto)
        {
            context.Update(producto);
            await context.SaveChangesAsync();
        }

        public async Task Agregar(Producto producto)
        {
            context.Add(producto);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Existe(string nombre)
        {
            return await context.Productos.AnyAsync(p => p.Nombre == nombre);
        }

        public async Task<Producto?> ObtenerPorId(Guid id)
        {
            return await context.Productos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Producto>> ObtenerFiltrado(string? nombre, bool? activo)
        {
            var queryable = context.Productos.AsQueryable();

            if (nombre is not null)
            {
                queryable = queryable.Where(p => p.Nombre == nombre);
            }

            if (activo is not null)
            {
                queryable = queryable.Where(p => p.Activo == activo);
            }

            return await queryable.ToListAsync();

        }


    }
}
