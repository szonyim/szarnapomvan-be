using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Szarnapomvan.Services;

namespace Szarnapomvan.Application;

public static class AppInitializer
{
  public const string AllowAllCorsPolicy = "allow_all_cors_policy";
  
  public static void AddControllers(WebApplicationBuilder builder)
  {
    builder.Services.AddControllers()
      .AddJsonOptions(option =>
      {
        option.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
      });
  }

  public static void AddServices(WebApplicationBuilder builder)
  {
    builder.Services.AddScoped<ILocationService, LocationService>();
    builder.Services.AddScoped<IPostService, PostService>();
    builder.Services.AddScoped<IMigrationService, MigrationService>();
  }

  public static void AddSwagger(WebApplicationBuilder builder)
  {
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
  }

  public static void AddDatabaseContext(WebApplicationBuilder builder)
  {
    builder.Services.AddDbContext<DataContext>(options =>
    {
      // options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"));
      options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection"));
    });
  }

  public static void AddSpaStaticFiles(WebApplicationBuilder builder)
  {
    builder.Services.AddSpaStaticFiles(configuration: options => { options.RootPath = "wwwroot"; });
  }

  public static void AddCors(WebApplicationBuilder builder)
  {
    builder.Services.AddCors(options =>
    {
      options.AddPolicy(name: AllowAllCorsPolicy,
        policy  =>
        {
          policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
    });
  }

  public static void ApplyMigrations(WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.Migrate();
  }
}