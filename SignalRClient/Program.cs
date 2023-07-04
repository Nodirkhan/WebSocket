using Microsoft.AspNet.SignalR.Client;
using System;
using System.Data;

namespace SignalRClient
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string url = "http://localhost:8080/signalr";
            var connection = new HubConnection(url);

            IHubProxy chatProxy = connection.CreateHubProxy("MainHub");
            
            chatProxy.On<string>("StartSync", (start) => {
                Console.WriteLine($"Message: {start}");
            });

            chatProxy.On<string>("GetState", (status) => {
                Console.WriteLine($"Status: {status}");
            });

            connection.Start().Wait();


            while (true)
            {
                Console.WriteLine("Select menu");
                Console.WriteLine("1. StartSync");
                Console.WriteLine("2. GetState");

                var menu = Console.ReadLine();
                
                if(menu == "1") 
                {
                    chatProxy.Invoke("StartSync").Wait();
                }
                else if(menu == "2")
                {
                    chatProxy.Invoke("GetState").Wait();
                }
            }

            connection.Stop();
        }
    }
}