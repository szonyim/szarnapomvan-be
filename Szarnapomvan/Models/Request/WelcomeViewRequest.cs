namespace Szarnapomvan.Models.Request;

public class WelcomeViewRequest
{
  public long LastId { get; set; }
  public int Take { get; set; } = 25;
}