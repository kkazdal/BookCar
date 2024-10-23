using System;

namespace CarBook.Application.Features.CQRS.Queries.Category;

public class GetCategoryQueryByIdQuery
{
    public int Id { get; set; }
    public GetCategoryQueryByIdQuery(int id)
    {
        this.Id = id;
    }
}
