using Microsoft.AspNetCore.Mvc;

namespace Szarnapomvan.Controllers;

[Route("api/[controller]")]
[ApiController]
public class About
{
  [HttpGet]
  public string GetAbout()
  {
    return "ver. 1.0.1";
  }
}