# Prueba técnica Backend .NET Newshore

Este repositorio tiene como finalidad servir de solución a tomar como parámetros el origen y el destino de viaje de un usuario, 
devolviendo vuelos asociados que satisfagan lo solicitado.

### Información:

1. Base de datos de SQL Server.
2. Microservicio en .NetCore6 con tres capas:
    - Capa de aplicación (API).
    - Capa de dominio (Bussiness).
    - Capa de infraestructura (DataAccess).
    - Capa transversal.
3. Inyección de dependencias.
4. MediatR para ejecución de comandos (Esta librería en particular generó dificultades, actualizarla más allá de la versión 11.1.0 generá problemas en las IRequestHandler en la capa Bussiness)
5. CQRS.
6. Manejos de EntityFramework.
7. Logs de aplicación con Serilog.
8. Implementación de pruebas unitarias con xUnit (Los test también pueden generar errores según versiones de Moq o de MediatR).
9. Se tomo la decisión de desarrollar la solución de rutas múltiples y de retorno. 

### Proceso de utilización:

1. Se debe publicar la base de datos desde Newshore.TechnicalTest.DataBase
2. Los parámetros de configuración de la solución pueden modificarse desde appsettings.json en Newshore.TechnicalTest.Api
3. Esta solución fue testeada en Rider 2022.2 y Visual Studio Community 2022.

