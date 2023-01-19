using Microsoft.EntityFrameworkCore;
using Szarnapomvan.Application;
using Szarnapomvan.Models.Data;

namespace Szarnapomvan.Services;

public interface ILocationService
{
    Task<List<Location>> FindAllAsync();
    Task<Location> Create(string name);
}

public class LocationService : ILocationService
{
    private ILogger<LocationService> _logger;
    private readonly DataContext _dataContext;
    
    public LocationService(ILogger<LocationService> logger, DataContext dataContext)
    {
        _logger = logger;
        _dataContext = dataContext;
    }

    public async Task<List<Location>> FindAllAsync()
    {
        return await _dataContext.Locations.ToListAsync();
    }

    public async Task<Location> Create(string name)
    {
        var location = new Location
        {
            Name = name
        };
        _dataContext.Locations.Add(location);
        await _dataContext.SaveChangesAsync();

        return location;
    }
    
    
}