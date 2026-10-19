using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Aplicacion.Contratos;
using TiendaProductos.Aplicacion.Utilidades.Mediador;
using TiendaProductos.Dominio.Entidades;
using TiendaProductos.Dominio.Excepciones;
using TiendaProductos.Dominio.ObjetoDeValor;

namespace TiendaProductos.Aplicacion.CasosDeUso.Productos.Comandos.CrearProducto;

public class CasoDeUsoCrearProducto(IRepositorioProductos repositorioProductos): IRequestHandler<ComandoCrearProducto, Guid>
{
    public async Task<Guid> Handle(ComandoCrearProducto comando)
    {
        var existeProducto = await repositorioProductos.Existe(comando.Nombre);
        if (existeProducto)
        {
            throw new ExcepcionDeReglaDeNegocio($"Ya existe un producto con el nombre {comando.Nombre}");
        }

        // Crear el objeto de valor Dinero
        var dinero = Dinero.Crear(comando.Precio, comando.Moneda);
        var invetario = CantidadInventario.Crear(comando.InventarioInicial);

        var producto = Producto.Crear(
             nombre: comando.Nombre,
             precio: dinero,
             descripcion: comando.Descripcion,
             inventarioInicial: invetario
        );

        await repositorioProductos.Agregar(producto);
        return producto.Id;


    }
}
