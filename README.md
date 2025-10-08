# Evoltis - Prueba T�cnica Backend (.NET)

Tiene como objetivo evaluar tus conocimientos t�cnicos en el desarrollo de APIs RESTful utilizando .NET 6 y buenas pr�cticas de arquitectura y testing.

## Tecnolog�as utilizadas

- .NET 6
- Entity Framework Core (incluye Code First)
- AutoMapper
- xUnit (para testing)
- MySql como base de datos.
- Swagger (para documentaci�n de endpoints).

## Estructura del Proyecto

El proyecto est� basado en una arquitectura **monol�tica por capas**. Las carpetas principales son:

- `Controllers`: Controladores con los endpoints de la API.
- `Domain`: Configuraci�n del `DbContext` y archivos de configuraci�n EF Core.
- `Models`: Modelos de dominio (Code First).
- `Repositories`: Implementaci�n del patr�n repositorio.
- `Services`: Contiene la l�gica de negocio.
- `MappingServices`: Configuraci�n de AutoMapper.
- `UnitTests`: Pruebas unitarias separadas por repositorio y servicios.
- `Program.cs` y `appsettings.json`: Archivos base para levantar la app.

## Consideraciones.
- Verificar la configuracion de program.cs para levantar el proyecto.