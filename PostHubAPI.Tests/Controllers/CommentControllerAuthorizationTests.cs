using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PostHubAPI.Dtos.Comment;
using PostHubAPI.Dtos.Post;

namespace PostHubAPI.Tests.Controllers;

public class CommentControllerAuthorizationTests
{
    private const string ValidIssuer = "https://localhost:5001";
    private const string ValidAudience = "https://localhost:4200";
    private const string Secret = "integration-test-secret-value-1234567890";

    [Fact]
    public async Task GetComment_ReturnsUnauthorized_WhenRequestIsAnonymous()
    {
        using var factory = CreateFactory();
        using var client = CreateClient(factory);

        var response = await client.GetAsync("/api/Comment/1");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task CreateNewComment_ReturnsUnauthorized_WhenRequestIsAnonymous()
    {
        using var factory = CreateFactory();
        using var client = CreateClient(factory);
        var postId = await CreateAuthorizedPostAsync(client);

        var response = await client.PostAsJsonAsync($"/api/Comment/{postId}", CreateCommentDto());

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task EditComment_ReturnsUnauthorized_WhenRequestIsAnonymous()
    {
        using var factory = CreateFactory();
        using var client = CreateClient(factory);
        var postId = await CreateAuthorizedPostAsync(client);
        var commentId = await CreateAuthorizedCommentAsync(client, postId);

        var response = await client.PutAsJsonAsync($"/api/Comment/{commentId}", CreateEditCommentDto());

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task DeleteComment_ReturnsUnauthorized_WhenRequestIsAnonymous()
    {
        using var factory = CreateFactory();
        using var client = CreateClient(factory);
        var postId = await CreateAuthorizedPostAsync(client);
        var commentId = await CreateAuthorizedCommentAsync(client, postId);

        var response = await client.DeleteAsync($"/api/Comment/{commentId}");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task CreateNewComment_ReturnsCreated_WhenRequestHasValidJwt()
    {
        using var factory = CreateFactory();
        using var client = CreateClient(factory);
        var postId = await CreateAuthorizedPostAsync(client);

        using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/Comment/{postId}")
        {
            Content = JsonContent.Create(CreateCommentDto())
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", CreateJwt());

        var response = await client.SendAsync(request);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var newCommentId = await response.Content.ReadFromJsonAsync<int>();
        Assert.True(newCommentId > 0);
    }

    [Fact]
    public async Task GetComment_ReturnsOk_WhenRequestHasValidJwt()
    {
        using var factory = CreateFactory();
        using var client = CreateClient(factory);
        var postId = await CreateAuthorizedPostAsync(client);
        var commentId = await CreateAuthorizedCommentAsync(client, postId);

        using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Comment/{commentId}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", CreateJwt());

        var response = await client.SendAsync(request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var payload = await response.Content.ReadFromJsonAsync<ReadCommentDto>();
        Assert.NotNull(payload);
        Assert.Equal(commentId, payload.Id);
    }

    [Fact]
    public async Task EditComment_ReturnsOk_WhenRequestHasValidJwt()
    {
        using var factory = CreateFactory();
        using var client = CreateClient(factory);
        var postId = await CreateAuthorizedPostAsync(client);
        var commentId = await CreateAuthorizedCommentAsync(client, postId);

        using var request = new HttpRequestMessage(HttpMethod.Put, $"/api/Comment/{commentId}")
        {
            Content = JsonContent.Create(CreateEditCommentDto())
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", CreateJwt());

        var response = await client.SendAsync(request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var payload = await response.Content.ReadFromJsonAsync<ReadCommentDto>();
        Assert.NotNull(payload);
        Assert.Equal(commentId, payload.Id);
        Assert.Equal("Edited comment body", payload.Body);
    }

    [Fact]
    public async Task DeleteComment_ReturnsNoContent_WhenRequestHasValidJwt()
    {
        using var factory = CreateFactory();
        using var client = CreateClient(factory);
        var postId = await CreateAuthorizedPostAsync(client);
        var commentId = await CreateAuthorizedCommentAsync(client, postId);

        using var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/Comment/{commentId}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", CreateJwt());

        var response = await client.SendAsync(request);

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    private static WebApplicationFactory<Program> CreateFactory()
    {
        Environment.SetEnvironmentVariable("JWT__ValidIssuer", ValidIssuer);
        Environment.SetEnvironmentVariable("JWT__ValidAudience", ValidAudience);
        Environment.SetEnvironmentVariable("JWT__Secret", Secret);

        return new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment(Environments.Development);
                builder.ConfigureAppConfiguration((_, configBuilder) =>
                {
                    configBuilder.AddInMemoryCollection(new Dictionary<string, string?>
                    {
                        ["JWT:ValidIssuer"] = ValidIssuer,
                        ["JWT:ValidAudience"] = ValidAudience,
                        ["JWT:Secret"] = Secret
                    });
                });
            });
    }

    private static HttpClient CreateClient(WebApplicationFactory<Program> factory)
    {
        return factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false,
            BaseAddress = new Uri("https://localhost")
        });
    }

    private static async Task<int> CreateAuthorizedPostAsync(HttpClient client)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "/api/Post")
        {
            Content = JsonContent.Create(CreatePostDto())
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", CreateJwt());

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var postId = await response.Content.ReadFromJsonAsync<int>();
        Assert.True(postId > 0);
        return postId;
    }

    private static async Task<int> CreateAuthorizedCommentAsync(HttpClient client, int postId)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/Comment/{postId}")
        {
            Content = JsonContent.Create(CreateCommentDto())
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", CreateJwt());

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var commentId = await response.Content.ReadFromJsonAsync<int>();
        Assert.True(commentId > 0);
        return commentId;
    }

    private static string CreateJwt()
    {
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
        var token = new JwtSecurityToken(
            issuer: ValidIssuer,
            audience: ValidAudience,
            claims:
            [
                new Claim(ClaimTypes.Name, "integration-user"),
                new Claim(ClaimTypes.Email, "integration@example.com")
            ],
            expires: DateTime.UtcNow.AddMinutes(5),
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static CreatePostDto CreatePostDto() =>
        new()
        {
            Title = "Post for comments",
            Body = "Post body"
        };

    private static CreateCommentDto CreateCommentDto() =>
        new()
        {
            Body = "Original comment body"
        };

    private static EditCommentDto CreateEditCommentDto() =>
        new()
        {
            Body = "Edited comment body"
        };
}