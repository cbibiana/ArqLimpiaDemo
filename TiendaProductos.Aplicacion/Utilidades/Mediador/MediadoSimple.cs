using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaProductos.Aplicacion.Utilidades.Mediador;

public class MediadoSimple(IServiceProvider sp) : IMediador
{
    public async Task<TResponse> Enviar<TResponse>(IRequest<TResponse> request)
    {
        var tipoHandler = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var casoDeUso = sp.GetRequiredService(tipoHandler);
        var metodo = tipoHandler.GetMethod("Handle");
        return await (Task<TResponse>)metodo.Invoke(casoDeUso, new object[] { request });
    }

    public async Task Enviar(IRequest request)
    {
        var tipoHandler = typeof(IRequestHandler<>).MakeGenericType(request.GetType());
        var casoDeUso = sp.GetRequiredService(tipoHandler);
        var metodo = tipoHandler.GetMethod("Handle");
        await (Task)metodo.Invoke(casoDeUso, new object[] { request });

    }
}
