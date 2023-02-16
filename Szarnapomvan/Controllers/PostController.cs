using Microsoft.AspNetCore.Mvc;
using Szarnapomvan.Models.Data;
using Szarnapomvan.Models.Request;
using Szarnapomvan.Models.Response;
using Szarnapomvan.Services;

namespace Szarnapomvan.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet("list")]
    public async Task<PostListResponse> GetPostsAsync([FromQuery]PostListRequest postListRequest)
    {
        return await _postService.GetPostListAsync(postListRequest);
    }

    [HttpPost("add")]
    public async Task<Post> AddPost([FromBody]CreatePostRequest createPostRequest)
    {
        return await _postService.AddAsync(createPostRequest);
    }
}