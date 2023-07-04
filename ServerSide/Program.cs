using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ServerSide.Hubs;

namespace ServerSide
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSignalR();
            builder.Services.AddCors();
            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseRouting();

            app.UseCors(builder => 
                builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/offers");
            }); 
            app.MapControllers();

            app.Run();
        }
    }
}