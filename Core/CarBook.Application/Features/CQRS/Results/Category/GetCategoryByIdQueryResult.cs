using System;

namespace CarBook.Application.Features.CQRS.Results.Category;

public class GetCategoryByIdQueryResult
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
}
