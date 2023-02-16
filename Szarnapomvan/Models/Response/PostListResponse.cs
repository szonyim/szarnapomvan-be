using Szarnapomvan.Models.Data;

namespace Szarnapomvan.Models.Response;

public class PostListResponse
{
  public int CurrentPage { get; set; }
  public int MaxPage { get; set; }
  public List<Post> Items { get; set; } = new List<Post>();
}