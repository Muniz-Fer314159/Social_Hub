using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Backend.Data;
using Backend.Models;

[ApiController]

[Route("api/[controller]")]

public class PostController: ControllerBase
{
    private readonly AppDbContext _context;

    public PostController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Authorize]

    public async Task<IActionResult> CreatePostAsync([FromBody] CreatePost dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if(userId == null)
        {
            return Unauthorized();
        }

        var post = new Post
        {
            Content = dto.Text,
            UserId = userId
        };

        _context.Posts.Add(post);

        await _context.SaveChangesAsync();

        return Ok(post);
    }
}