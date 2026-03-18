using AutoMapper;
using PostHubAPI.Dtos.Comment;
using PostHubAPI.Models;

namespace PostHubAPI.Profiles;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<CreateCommentDto, Comment>();
        CreateMap<EditCommentDto, Comment>();
        CreateMap<Comment, ReadCommentDto>();
    }
}