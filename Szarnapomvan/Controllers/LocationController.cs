using Microsoft.AspNetCore.Mvc;
using Szarnapomvan.Models.Data;
using Szarnapomvan.Services;

namespace Szarnapomvan.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController
{

  private readonly ILocationService _locationService;

  public LocationController(ILocationService locationService)
  {
    _locationService = locationService;
  }

  [HttpGet("list")]
  public async Task<List<Location>> GetLocations()
  {
    return await _locationService.FindAllAsync();
  }
}