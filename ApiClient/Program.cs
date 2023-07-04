using Microsoft.AspNetCore.SignalR.Client;

namespace ApiClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            string url = "http://localhost:5000/chatHub";
            var connection = new HubConnectionBuilder().WithUrl(url).Build();

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Console.WriteLine($"{user}: {message}");
            });

            await connection.StartAsync();

            Console.WriteLine("Connected to SignalR server. Press Q to quit.");

            while (true)
            {
                var message = Console.ReadLine();
                if (string.IsNullOrEmpty(message) || message.ToUpper() == "Q")
                    break;

                await connection.InvokeAsync("SendMessage", "YourName", message);
            }

            await connection.StopAsync();
        }
    }
}