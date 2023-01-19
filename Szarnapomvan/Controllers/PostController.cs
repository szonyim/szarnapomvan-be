using Microsoft.AspNetCore.Mvc;
using Szarnapomvan.Models.Data;
using Szarnapomvan.Models.Request;
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
    public async Task<List<Post>> GetPosts([FromQuery]long lastId, [FromQuery]int take = 25)
    {
        return await _postService.FindAsync(lastId, take);
    }

    [HttpPost("add")]
    public async Task<Post> AddPost([FromBody]CreatePostRequest createPostRequest)
    {
        return await _postService.AddAsync(createPostRequest);
    }
}