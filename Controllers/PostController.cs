using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostHubAPI.Dtos.Post;
using PostHubAPI.Exceptions;
using PostHubAPI.Services.Interfaces;

namespace PostHubAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController(IPostService postService) : ControllerBase
{
    private readonly IPostService _postService = postService;

    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await _postService.GetAllPostsAsync();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        try
        {
            var post = await _postService.GetPostByIdAsync(id);
            return Ok(post);
        }
        catch (NotFoundException exception)
        {
            return NotFound(exception.Message);
        }
    }

    /// <summary>
    /// Creates a new post. Requires authorization.
    /// </summary>
    /// <param name="dto">The post data transfer object containing post details</param>
    /// <returns>Created status with location URI and new post ID if successful; BadRequest if model is invalid</returns>
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostDto dto)
    {
        // Validate the model state before proceeding
        if (ModelState.IsValid)
        {
            // Create the new post and get its ID
            var newPostId = await _postService.CreateNewPostAsync(dto);

            // Build the URI for the newly created resource
            var locationUri = $"{Request.Scheme}://{Request.Host}/api/Post/{newPostId}";

            // Return 201 Created with the location and ID
            return Created(locationUri, newPostId);
        }

        // Return 400 Bad Request if validation fails
        return BadRequest(ModelState);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> EditPost(int id, EditPostDto dto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var editedPost = await _postService.EditPostAsync(id, dto);
                return Ok(editedPost);
            }

            return BadRequest(ModelState);
        }
        catch (NotFoundException exception)
        {
            return NotFound(exception.Message);
        }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        try
        {
            await _postService.DeletePostAsync(id);
            return NoContent();
        }
        catch (NotFoundException exception)
        {
            return NotFound(exception.Message);
        }
    }
}
