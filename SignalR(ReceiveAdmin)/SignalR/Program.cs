using Microsoft.AspNetCore.SignalR.Client;
using SignalR;

//var hubUrl = "https://rdglobaldx.com/rdstp_api_qa/messageHub";
var hubUrl = "https://localhost:7236/messageHub";
//var userId = "1"; // Esto debería obtenerse de tu JWT o del local storage

// Crear el cliente de SignalR, incluyendo el user_id como parámetro de conexión
var connection = new HubConnectionBuilder()
    .WithUrl(hubUrl)
    .Build();

// Suscribirse a los mensajes que llegan desde el servidor (evento "ReceiveMessage")
connection.On<DateTime, List<GetChannels>>("ReceiveMessageConnect", (hora_envio, messages_unread) =>
{
    Console.WriteLine($"Hora: {hora_envio}. Mensajes sin leer: {messages_unread}");
    //}
    foreach (var channel in messages_unread)
    {
        Console.WriteLine($"Mensajes sin leer: {channel.unread_messages}");
        Console.WriteLine($"Id admin: {channel.admin_id}");
    }
});

try
{
    // Iniciar la conexión
    await connection.StartAsync();
    Console.WriteLine("Conectado al Hub de SignalR del lado del Connect");

    // Mantén la conexión abierta hasta que el usuario decida salir
    Console.WriteLine("Presiona cualquier tecla para cerrar la conexión...");
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine($"Error conectando al Hub: {ex.Message} \nStack Trace: {ex.StackTrace}");
}
finally
{
    // Cerrar la conexión al finalizar
    await connection.StopAsync();
    Console.WriteLine("Conexión cerrada");
}
