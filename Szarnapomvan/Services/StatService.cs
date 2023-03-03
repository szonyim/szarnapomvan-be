using Microsoft.EntityFrameworkCore;
using Szarnapomvan.Application;
using Szarnapomvan.Models.Data;

namespace Szarnapomvan.Services;

public interface IStatService
{
  
}

public class StatService : IStatService
{

  private readonly DataContext _dataContext;

  public StatService(DataContext dataContext)
  {
    _dataContext = dataContext;
  }
  public void CreateMonthlyStat()
  {
    // string startDate = DateTime.Now.ToString("yyyy-MM-01");
    // int lastDayOfMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
    // string endDate = DateTime.Now.ToString($"yyyy-MM-{lastDayOfMonth}");
    
    // List<Post> posts = _dataContext.Posts.
    //   Where(p => p)
  }

  public void CreateAnnulStat()
  {
    // string startDate = DateTime.Now.ToString("yyyy-01-01");
    // string endDate = DateTime.Now.ToString("yyyy-12-31");
  }

  public void CreateEntireStat()
  {
    
  }
  
}