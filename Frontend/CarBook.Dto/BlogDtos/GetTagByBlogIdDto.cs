using System;

namespace CarBook.Dto.BlogDtos;

public class GetTagByBlogIdDto
{
    public int TagId { get; set; }
    public int BlogId { get; set; }
    public required string TagName { get; set; }
}
