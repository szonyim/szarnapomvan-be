using Szarnapomvan.Application;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

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
    app.UseCors(AppInitializer.AllowAllCorsPolicy);
}

app.UseSpaStaticFiles();
app.UseSpa(configuration: spaBuilder =>
{
    spaBuilder.Options.DevServerPort = 8080;
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();