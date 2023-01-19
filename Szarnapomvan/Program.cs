using Szarnapomvan.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

AppInitializer.AddControllers(builder);
AppInitializer.AddServices(builder);
AppInitializer.AddSwagger(builder);
AppInitializer.AddDatabaseContext(builder);
AppInitializer.AddSpaStaticFiles(builder);
AppInitializer.AddCors(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSpaStaticFiles();
app.UseSpa(configuration: spaBuilder =>
{
    spaBuilder.Options.DevServerPort = 8080;
});

app.UseCors(AppInitializer.CorsPolicy);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();