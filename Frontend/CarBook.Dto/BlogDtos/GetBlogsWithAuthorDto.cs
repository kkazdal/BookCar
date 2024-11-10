using System;

namespace CarBook.Dto.BlogDtos;

public class GetBlogsWithAuthorDto
{
    public int BlogId { get; set; }
    public int AuthorId { get; set; }
    public required string AuthorName { get; set; }
    public DateTime CreatedDate { get; set; }
    public required string BlogTitle { get; set; }
    public required string ImageUrl { get; set; }
    public string Description { get; set; }

}
