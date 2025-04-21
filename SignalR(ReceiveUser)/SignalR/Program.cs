using Microsoft.AspNetCore.SignalR.Client;
using SignalR;

//var hubUrl = "https://rdglobaldx.com/rdstp_api_qa/messageHub";
var hubUrl = "https://localhost:7236/messageHub";
var userId = "6"; // Esto debería obtenerse de tu JWT o del local storage

// Crear el cliente de SignalR
var connection = new HubConnectionBuilder()
    .WithUrl($"{hubUrl}?user_id={userId}")
    .Build();

/*
 var members = GetAdminChannelMembers(1);
                var message = await GetUnreadMessagesAndConversations(null, members.data, 9);
                // Inicializamos los contadores
                int unreadMessages = (int)message.data.Sum(c => c.unread_messages);

                Console.WriteLine("!-- Mensajes sin leer: " + unreadMessages);
                // Imprimir todos los elementos del arreglo 'message.data'
                foreach (var channel in message.data)
                {
                    Console.WriteLine($"Mensajes sin leer: {channel.unread_messages}");
                    // Aquí puedes imprimir otras propiedades de cada canal, si las tiene
                }
 */


// Suscribirse a los mensajes que llegan desde el servidor (evento "ReceiveMessage")
connection.On<DateTime, List<GetChannels>>("ReceiveMessageApp", (hora_envio, messages_unread) =>
{
    //if (ids.Contains("idUser"))
    //{
        Console.WriteLine($"Hora: {hora_envio}. Mensajes sin leer: {messages_unread}");
    //}
    foreach (var channel in messages_unread)
    {
        Console.WriteLine($"Id usuario: {channel.user_id}");
        Console.WriteLine($"Mensajes sin leer: {channel.unread_messages}");
        // Aquí puedes imprimir otras propiedades de cada canal, si las tiene
    }

});

try
{
    // Iniciar la conexión
    await connection.StartAsync();
    Console.WriteLine("Conectado al Hub de SignalR del lado del APP");

    // Mantén la conexión abierta hasta que el usuario decida salir
    Console.WriteLine("Presiona cualquier tecla para cerrar la conexión...");
    Console.ReadKey();

    // Enviar un mensaje al Hub
    /*Console.WriteLine("Escribe tu nombre:");
    var user = Console.ReadLine();

    while (true)
    {
        Console.WriteLine("Escribe un mensaje (o 'exit' para salir):");
        var message = Console.ReadLine();

        if (message == "exit")
            break;

        // Invoca un método en el Hub (puedes ajustar el nombre del método y parámetros según tu hub)
        await connection.InvokeAsync("SendMessageToUsers", user, message, new List<string> { "user1" });
    }*/
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
