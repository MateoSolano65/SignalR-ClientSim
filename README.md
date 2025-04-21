# SignalR-ClientSim

Dos aplicaciones de consola .NET que simulan clientes SignalR (roles de administrador y usuario) comunicándose a través de WebSockets.

## Descripción del Proyecto

SignalR-ClientSim demuestra la comunicación en tiempo real entre diferentes tipos de clientes utilizando ASP.NET Core SignalR. La solución consiste en dos aplicaciones de consola que se conectan a un hub de SignalR y simulan el comportamiento de administradores y usuarios regulares recibiendo mensajes.

## Estructura del Repositorio

- `/SignalR(ReceiveAdmin)/` - Aplicación de consola que simula un cliente administrador
- `/SignalR(ReceiveUser)/` - Aplicación de consola que simula un cliente usuario

## Instrucciones de Configuración

1. Clonar este repositorio
2. Abrir cualquiera de las soluciones en Visual Studio 2022
3. Restaurar paquetes NuGet
4. Configurar ajustes de conexión en `Program.cs` si es necesario
5. Compilar la solución

## Uso

### Cliente Administrador

El cliente administrador se suscribe al evento `ReceiveMessageConnect` en el hub de SignalR y muestra información sobre mensajes no leídos.

```bash
cd SignalR-ClientSim/SignalR(ReceiveAdmin)
dotnet run
```

### Cliente Usuario

El cliente usuario se suscribe al evento `ReceiveMessageApp` y muestra información sobre mensajes no leídos para un usuario específico.

```bash
cd SignalR-ClientSim/SignalR(ReceiveUser)
dotnet run
```

## Detalles Técnicos

- Desarrollado con .NET 8.0
- Utiliza Microsoft.AspNetCore.SignalR.Client
- Demuestra conexión a hub, suscripción a eventos y manejo de mensajes
- Actualizaciones en tiempo real con WebSockets

## Licencia

Este proyecto está licenciado bajo la Licencia MIT - consulte el archivo LICENSE para más detalles.
