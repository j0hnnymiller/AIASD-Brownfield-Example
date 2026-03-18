namespace PostHubAPI.Dtos.Comment;

public class ReadCommentDto
{
    public int Id { get; set; }
    public string Body { get; set; }
    public DateTime CreationTime { get; set; } = DateTime.Now;
}