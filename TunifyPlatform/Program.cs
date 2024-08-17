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

            //swagger config 
            builder.Services.AddSwaggerGen
                (
                option =>
                {
                    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Tunify api doc",
                        Version = "v1",
                        Description = "Api for managing tunify"
                    });
                }

                );

            var app = builder.Build();
            //call swagger services 
            app.UseSwagger
                (
                options =>
                {
                    options.RouteTemplate = "api/{documentName}/swagger.json";
                }
                );
            //call swagger UI
            app.UseSwaggerUI
                (
                options =>
                {
                    options.SwaggerEndpoint("/api/v1/swagger.json", "Tunify Api");
                    options.RoutePrefix = "TunifyApi";
                }
                );

            //=====
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            //=====

            app.MapControllers();
            app.MapGet("/", () => "Hello World!");
            //run
            app.Run();
        }
    }
}
