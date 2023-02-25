using Microsoft.EntityFrameworkCore;
using Szarnapomvan.Application;

namespace Szarnapomvan.Services;

public interface IMigrationService
{
  string Apply();
}

public class MigrationService : IMigrationService
{
  private ILogger<MigrationService> _logger;
  private readonly DataContext _dataContext;
    
  public MigrationService(ILogger<MigrationService> logger, DataContext dataContext)
  {
    _logger = logger;
    _dataContext = dataContext;
  }
  public string Apply()
  {
    try
    {
      _dataContext.Database.Migrate();
      return "success";
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error applying migrations...");
      return e.Message;
    }
  }
}