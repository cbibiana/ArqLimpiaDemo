using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Dominio.Entidades;

namespace TiendaProductos.Infraestructura.Persistencia.Configuraciones
{
    internal class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(prop => prop.Nombre)
                .IsUnique();

            builder.Property(prop => prop.Descripcion)
                .HasMaxLength(2000);

            builder.ComplexProperty(prop => prop.Precio, accion =>
            {
                accion.Property(e => e.Monto)
                    .HasColumnName("Precio")
                    .HasPrecision(18, 2);
                accion.Property(e => e.Moneda)
                    .HasColumnName("Moneda");
            });

            builder.ComplexProperty(prop => prop.CantidadInventario, accion =>
            {
                accion.Property(e => e.Valor)
                    .HasColumnName("Inventario");
            });

        }

    }
}
