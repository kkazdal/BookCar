using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries;

public class GetBlogQueryById : IRequest<GetQueryBlogByIdResult>
{
    public int Id { get; set; }

    public GetBlogQueryById(int id)
    {
        Id = id;
    }
}
