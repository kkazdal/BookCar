using System;

namespace CarBook.Dto.BlogDtos;

public class LastBlogsDto
{
    public int BlogId { get; set; }
    public string AuthorName { get; set; }
    public string BlogTitle { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CategoryName { get; set; }
}
