using Microsoft.AspNetCore.Mvc;
using Szarnapomvan.Services;

namespace Szarnapomvan.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MigrationController : ControllerBase
{
  private readonly IMigrationService _migrationService;

  public MigrationController(IMigrationService migrationService)
  {
    _migrationService = migrationService;
  }

  [HttpGet("apply")]
  public string Apply()
  {
    return _migrationService.Apply();
  }
  
}
