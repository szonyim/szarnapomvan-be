using Microsoft.Extensions.FileProviders;
using Szarnapomvan.Application;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

AppInitializer.AddControllers(builder);
AppInitializer.AddServices(builder);
AppInitializer.AddSwagger(builder);
AppInitializer.AddDatabaseContext(builder);
AppInitializer.AddSpaStaticFiles(builder);
AppInitializer.AddCors(builder);

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseCors(AppInitializer.AllowAllCorsPolicy);
}

app.UseSpaStaticFiles();
app.UseSpaStaticFiles(new StaticFileOptions
{
  FileProvider = new PhysicalFileProvider(
    Path.Combine(app.Environment.ContentRootPath, "wwwroot", ".well-known")),
  RequestPath = "/.well-known",
  ServeUnknownFileTypes = true
});
app.UseSpa(configuration: spaBuilder => { });

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();