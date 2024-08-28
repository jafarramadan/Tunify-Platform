using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using TunifyPlatform.Repositories.interfaces;
using TunifyPlatform.Repositories.Services;
using Microsoft.AspNetCore.Identity;
using TunifyPlatform.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
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
            builder.Services.AddScoped<IUsers, UsersServices>();
            builder.Services.AddScoped<IArtists, ArtistServices>();
            builder.Services.AddScoped<IPlaylists, PlaylistServices>();
            builder.Services.AddScoped<ISongs, SongServices>();

            builder.Services.AddScoped<IAccountt, IdentityAccountServices>();

            builder.Services.AddScoped<JwtTokenService>();

            //identity service
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<TunifyAppDbContext>();

            //add auth service to the app using jwt 
            builder.Services.AddAuthentication(
                options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                } 
                ).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = JwtTokenService.ValidatToken(builder.Configuration);
                }
                );

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                options.AddPolicy("RequireUpdatePermission", policy =>
                    policy.RequireClaim("permission", "update"));
                options.AddPolicy("RequireFullAccess", policy =>
                    policy.RequireClaim("permission", "full_access"));
            });

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
                    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Please enter user token below."
                    });
                    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

                }
                );
            var app = builder.Build();
            app.UseAuthentication();
            app.UseAuthorization();

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
                    options.RoutePrefix = "";
                }
                );
            //// =====
            // app.MapControllerRoute(
            //     name: "default",
            //     pattern: "{controller=Home}/{action=Index}/{id?}");
            //// =====

            app.MapControllers();
            app.MapGet("/", () => "Hello World!");
            //run
            app.Run();
        }
    }
}