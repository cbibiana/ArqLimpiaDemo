using System.Net;
using System.Text.Json;
using TiendaProductos.Aplicacion.Excepciones;
using TiendaProductos.Dominio.Excepciones;

namespace TiendaProductos.WebAPI.Middlewares;

public class ManejoExcepcionesMiddleware
{
    private readonly RequestDelegate _next;
    public ManejoExcepcionesMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await ManejarExcepcionAsync(context, ex);
        }
    }

    private Task ManejarExcepcionAsync(HttpContext context, Exception excepcion)
    {
       HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var resultado = string.Empty;

        switch (excepcion)
        {
            case ExcepcionDeReglaDeNegocio excepcionReglaDeNegocio:
                httpStatusCode = HttpStatusCode.BadRequest;
                resultado = JsonSerializer.Serialize(excepcionReglaDeNegocio.Message);
            break;
            case ExcepcionNoEncontrado:
                httpStatusCode = HttpStatusCode.NotFound;
            break;
        }

        context.Response.StatusCode = (int)httpStatusCode;
        return context.Response.WriteAsync(resultado);

    }

}

public static class ManejoExcepcionesMiddlewareExtensions
{
    public static IApplicationBuilder UseManejoExcepcionesMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ManejoExcepcionesMiddleware>();
    }
}
