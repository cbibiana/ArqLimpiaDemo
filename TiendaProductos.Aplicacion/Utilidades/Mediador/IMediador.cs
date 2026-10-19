using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaProductos.Aplicacion.Utilidades.Mediador;

public interface IMediador
{
    Task<TResponse> Enviar<TResponse>(IRequest<TResponse> request);
    Task Enviar(IRequest request);
}
