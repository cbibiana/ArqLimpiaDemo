#
cd C:\Users\User\source\repos\ArqLimpiaDemo

@"
# TiendaProductos API - Clean Architecture

API RESTful desarrollada con ASP.NET Core siguiendo los principios de Arquitectura Limpia y CQRS.

## Arquitectura

- **TiendaProductos.Dominio** - Entidades, Value Objects y reglas de negocio
- **TiendaProductos.Aplicacion** - Casos de uso, Commands, Queries (CQRS) con Mediador
- **TiendaProductos.Infraestructura** - Entity Framework Core, repositorios, persistencia
- **TiendaProductos.WebAPI** - Controladores, DTOs, middlewares y configuracion

## Tecnologias

- ASP.NET Core (.NET 10)
- Entity Framework Core
- SQL Server
- Clean Architecture
- CQRS con Mediador
- Swagger / OpenAPI

## Endpoints

| Metodo | Endpoint | Descripcion |
|--------|----------|-------------|
| GET | /api/productos/{id} | Obtener producto por ID |
| GET | /api/productos/filtrado?nombre=x&activo=true | Filtrar productos por nombre y estado |
| POST | /api/productos | Crear un nuevo producto |
| PUT | /api/productos/{id} | Actualizar un producto existente |
| POST | /api/productos/{id}/inventario | Ajustar inventario de un producto |

## Ejemplo de uso

### Crear producto (POST /api/productos)
``json
{
    "nombre": "Laptop HP",
    "descripcion": "Laptop HP 15 pulgadas",
    "precio": 2500000,
    "moneda": "COP",
    "inventarioInicial": 10
}
``

### Actualizar producto (PUT /api/productos/{id})
``json
{
    "nombre": "Laptop HP Actualizada",
    "descripcion": "Laptop HP 15 pulgadas 16GB RAM",
    "precio": 2800000,
    "moneda": "COP",
    "activo": true
}
``

### Ajustar inventario (POST /api/productos/{id}/inventario)
``json
{
    "delta": 5
}
``

## Como ejecutar

1. Clonar el repositorio
2. Configurar la cadena de conexion en appsettings.json:
   Server=localhost;Database=TiendaProductosDb;Trusted_Connection=True;TrustServerCertificate=True
3. Ejecutar migraciones: Update-Database
4. Ejecutar la aplicacion con F5 en Visual Studio

## Autora

Bibiana Sepulveda


