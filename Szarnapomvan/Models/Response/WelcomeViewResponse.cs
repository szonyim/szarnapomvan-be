using Szarnapomvan.Models.Data;

namespace Szarnapomvan.Models.Response;

public class WelcomeViewResponse
{
  public List<Location> Locations { get; set; }
  public List<Post> Posts { get; set; }
}