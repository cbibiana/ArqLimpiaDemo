using System;
using System.Collections.Generic;
using System.Text;
using TiendaProductos.Dominio.Excepciones;

namespace TiendaProductos.Dominio.ObjetoDeValor;

public class Dinero
{
    public decimal Monto { get; private set; }
    public string Moneda { get; private set; } = default!;

    private Dinero (decimal monto, string moneda)
    {
        Monto = monto;
        Moneda = moneda;
    }

    public static Dinero Crear(decimal monto, string moneda = "Pesos")
    {
        if (monto < 0)
        {
            throw new ExcepcionDeReglaDeNegocio("El monto no puede ser negativo.");
        }
        if (string.IsNullOrWhiteSpace(moneda))
        {
            throw new ExcepcionDeReglaDeNegocio("La moneda no puede estar vacía.");
        }

        return new Dinero(monto, moneda);
    }
}
