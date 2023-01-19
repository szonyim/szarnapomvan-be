using Microsoft.AspNetCore.Mvc;
using Szarnapomvan.Models.Request;
using Szarnapomvan.Models.Response;
using Szarnapomvan.Services;

namespace Szarnapomvan.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WelcomeController : ControllerBase
{
  private readonly ILocationService _locationService;
  private readonly IPostService _postService;

  public WelcomeController(ILocationService locationService, IPostService postService)
  {
    _locationService = locationService;
    _postService = postService;
  }

  [HttpGet]
  public async Task<WelcomeViewResponse> Welcome([FromQuery]long lastId, [FromQuery]int take)
  {
    return new WelcomeViewResponse
    {
      Locations = await _locationService.FindAllAsync(),
      Posts = await _postService.FindAsync(lastId, take)
    };
  }
}