using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using TunifyPlatform.Repositories.interfaces;
using TunifyPlatform.Repositories.Services;
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
            builder.Services.AddScoped<IUsers,UsersServices>();
            builder.Services.AddScoped<IArtists, ArtistServices>();
            builder.Services.AddScoped<IPlaylists, PlaylistServices>();
            builder.Services.AddScoped<ISongs, SongServices>();

            var app = builder.Build();
            app.MapControllers();
            app.MapGet("/", () => "Hello World!");
            //run
            app.Run();
        }
    }
}
