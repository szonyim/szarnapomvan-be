using Szarnapomvan.Application;
using Szarnapomvan.Models.Data;
using Microsoft.EntityFrameworkCore;
using Szarnapomvan.Models.Request;

namespace Szarnapomvan.Services;

public interface IPostService
{
  Task<List<Post>> FindAsync(long lastId, int take = 25);
  Task<Post> AddAsync(CreatePostRequest createPostRequest);
  Task<int> Delete(long id);
}

public class PostService : IPostService
{
  private ILogger<PostService> _logger;
  private readonly DataContext _dataContext;

  public PostService(ILogger<PostService> logger, DataContext dataContext)
  {
    _logger = logger;
    _dataContext = dataContext;
  }

  public async Task<List<Post>> FindAsync(long lastId, int take)
  {

    return lastId == 0 ? 
      await FindFirstPageAsync(take) : 
      await FindPageByLastId(lastId, take);
  }

  private async Task<List<Post>> FindPageByLastId(long lastId, int take)
  {
    return await _dataContext.Posts
      .OrderByDescending(p => p.Id)
      .Where(p => p.Id < lastId)
      .Take(take)
      .ToListAsync();
  }

  private async Task<List<Post>> FindFirstPageAsync(int take)
  {
    return await _dataContext.Posts
      .OrderByDescending(p => p.Id)
      .Take(take)
      .ToListAsync();
  }

  public async Task<Post> AddAsync(CreatePostRequest createPostRequest)
  {
    Location location = await _dataContext.Locations.SingleAsync(l => l.Id == createPostRequest.LocationId);
    
    Post post = new Post
    {
      CreatedBy = createPostRequest.CreatedBy,
      Content = createPostRequest.Content,
      Location = location
    };
    
    _dataContext.Posts.Add(post);
    await _dataContext.SaveChangesAsync();

    _logger.LogDebug($"New post created with id: {post.Id}");
    
    return post;
  }

  public async Task<int> Delete(long id)
  {
    var post = await _dataContext.Posts.FindAsync(id);
    if (post != null)
    {
      _dataContext.Posts.Remove(post);
    }

    return await _dataContext.SaveChangesAsync();
  }
}