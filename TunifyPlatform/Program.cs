using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
namespace TunifyPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            string ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<TunifyAppDbContext>(optionsX => optionsX.UseSqlServer(ConnectionStringVar));

            var app = builder.Build();
            app.MapControllers();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
