using Microsoft.EntityFrameworkCore;
using Szarnapomvan.Models.Data;

namespace Szarnapomvan.Application;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options)
    : base(options)
  {
  }

  // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  // {
  //   if (!optionsBuilder.IsConfigured)
  //   {
  //     IConfigurationRoot configuration = new ConfigurationBuilder()
  //       .SetBasePath(Directory.GetCurrentDirectory())
  //       .AddJsonFile("appsettings.json")
  //       .Build();
  //     var connectionString = configuration.GetConnectionString("DatabaseConnection");
  //     optionsBuilder.UseNpgsql(connectionString);
  //   }
  // }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    var locationNames = new List<string>
    {
      "Budapest",
      "Baranya megye",
      "Bács-Kiskun megye",
      "Békés megye",
      "Borsod-Abaúj-Zemplén megye",
      "Csongrád-Csanád megye",
      "Fejér megye",
      "Győr-Moson-Sopron megye",
      "Hajdú-Bihar megye",
      "Heves megye",
      "Jász-Nagykun-Szolnok megye",
      "Komárom-Esztergom megye",
      "Nógrád megye",
      "Pest megye",
      "Somogy megye",
      "Szabolcs-Szatmár-Bereg megye",
      "Tolna megye",
      "Vas megye",
      "Veszprém megye",
      "Zala megye",
      "Egyéb",
      "Külföld"
    };

    long newId = 1;
    modelBuilder.Entity<Location>().HasData(
      locationNames.ConvertAll(element => new Location { Id = newId++, Name = element })
    );
  }

  public DbSet<Location> Locations { get; set; }
  public DbSet<Post> Posts { get; set; }
}