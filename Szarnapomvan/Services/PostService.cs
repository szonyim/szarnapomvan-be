using Szarnapomvan.Application;
using Szarnapomvan.Models.Data;
using Microsoft.EntityFrameworkCore;
using Szarnapomvan.Models.Request;
using Szarnapomvan.Models.Response;

namespace Szarnapomvan.Services;

public interface IPostService
{
  Task<Post> AddAsync(CreatePostRequest createPostRequest);
  Task<int> Delete(long id);
  PostListResponse GetPostList(PostListRequest request);
  Task<PostListResponse> GetPostListAsync(PostListRequest request);
}

public class PostService : IPostService
{
  private readonly ILogger<PostService> _logger;
  private readonly DataContext _dataContext;
  private IPostService _postServiceImplementation;

  public PostService(ILogger<PostService> logger, DataContext dataContext)
  {
    _logger = logger;
    _dataContext = dataContext;
  }

  public PostListResponse GetPostList(PostListRequest request)
  {
    int page = request.Page;
    int skip = (page - 1) * request.PageSize;

    int count = _dataContext.Posts.Count();
    int maxPage = Convert.ToInt32(Math.Ceiling((double) count / request.PageSize));

    if (page > maxPage)
      page = maxPage;

    List<Post> posts = _dataContext.Posts
      .OrderByDescending(p => p.Id)
      .Skip(skip)
      .Take(request.PageSize)
      .ToList();

    return new PostListResponse
    {
      CurrentPage = page,
      MaxPage = maxPage,
      Posts = posts
    };
  }

  public async Task<PostListResponse> GetPostListAsync(PostListRequest request)
  {
    int page = request.Page;
    int skip = (page - 1) * request.PageSize;

    int count = _dataContext.Posts.Count();
    int maxPage = Convert.ToInt32(Math.Ceiling((double) count / request.PageSize));

    if (page > maxPage)
      page = maxPage;

    Task<List<Post>> posts = _dataContext.Posts
      .OrderByDescending(p => p.Id)
      .Skip(skip)
      .Take(request.PageSize)
      .ToListAsync();

    return new PostListResponse
    {
      CurrentPage = page,
      MaxPage = maxPage,
      Posts = await posts
    };
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