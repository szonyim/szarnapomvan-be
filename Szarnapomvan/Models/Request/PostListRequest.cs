namespace Szarnapomvan.Models.Request;

public class PostListRequest
{
  public int PageSize { get; set; } = 10;

  private int _page = 1;

  public int Page {
    get => _page;
    set {

      if (value < 1) { 
        _page = 1;
      }
      else
      {
        _page = value;
      }
    } 
  }
}