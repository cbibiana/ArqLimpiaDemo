using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaProductos.Dominio.ObjetoDeValor;

public class CantidadInventario
{
    public int Valor { get; private set; }

    private CantidadInventario(int valor)
    {
        Valor = valor;
    }
    
    public static CantidadInventario Crear(int valor)
    {
        if (valor < 0)
        {
            throw new ArgumentException("La cantidad en inventario no puede ser negativa.", nameof(valor));
        }

        return new CantidadInventario(valor);
    }
}
