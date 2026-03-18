using AutoMapper;
using PostHubAPI.Dtos.Post;
using PostHubAPI.Models;

namespace PostHubAPI.Profiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<CreatePostDto, Post>();
        CreateMap<EditPostDto, Post>();
        CreateMap<Post, ReadPostDto>();
    }
}