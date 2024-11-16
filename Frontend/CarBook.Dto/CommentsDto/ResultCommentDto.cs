using System;

namespace CarBook.Dto.CommentsDto;

public class ResultCommentDto
{
    public int CommentId { get; set; }
    public string Name { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public int BlogId { get; set; }
}
