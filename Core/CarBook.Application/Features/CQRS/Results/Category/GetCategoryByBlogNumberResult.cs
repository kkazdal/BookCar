using System;

namespace CarBook.Application.Features.CQRS.Results.Category;

public class GetCategoryByBlogNumberResult
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public int BlogNumber { get; set; }
}
