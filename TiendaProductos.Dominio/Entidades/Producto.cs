using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Dominio.Excepciones;
using TiendaProductos.Dominio.ObjetoDeValor;

namespace TiendaProductos.Dominio.Entidades;

public class Producto
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public string Nombre { get; private set; } = default!;
    public string? Descripcion { get; private set; } = default!;
    public Dinero Precio { get; private set; } = Dinero.Crear(0, "Pesos");
    public CantidadInventario CantidadInventario { get; private set; } = CantidadInventario.Crear(0);
    public bool Activo { get; private set; } = true;
    public static Producto Crear(string nombre, Dinero precio, string? descripcion, CantidadInventario inventarioInicial)
    {
        ValidarNombre(nombre);

        return new Producto
        {
            Nombre = nombre,
            Descripcion = descripcion,
            Precio = precio,
            CantidadInventario = inventarioInicial
        };

    }

    public void Actualizar(string nombre, string? descripcion, Dinero precio, bool activo)
    {
        ValidarNombre(nombre);
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
        Activo = activo;

    }

    public void AjustarInventario(int delta)
    {
        var nuevoValor = CantidadInventario.Valor + delta;

        if (nuevoValor < 0)
        {
            throw new ExcepcionDeReglaDeNegocio("No hay suficiente inventario para realizar esta operación.");
        }

        CantidadInventario = CantidadInventario.Crear(nuevoValor);
    }

    private static void ValidarNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ExcepcionDeReglaDeNegocio("El nombre del producto es requerido");
        }
        if (nombre.Trim().Length > 200)
        {
            throw new ExcepcionDeReglaDeNegocio("La longitud del nombre del producto no puede exceder los 200 caracteres.");
        }
        
    }




}

