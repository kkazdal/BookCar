using System;

namespace CarBook.Domain.Entities;

public class Comment
{   
    public int CommentId { get; set; }
    public string Name { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}
