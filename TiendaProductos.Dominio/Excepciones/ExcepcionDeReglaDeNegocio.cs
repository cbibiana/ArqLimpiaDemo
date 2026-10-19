using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaProductos.Dominio.Excepciones;

public class ExcepcionDeReglaDeNegocio : Exception
{
    public ExcepcionDeReglaDeNegocio(string message) : base(message)
    {

    }
}
