using System;
using CarBook.Application.Features.Mediator.Results.TagResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TagQueries;
public class GetTagByIdQuery : IRequest<GetTagByIdQueryResult>
{
    public int Id { get; set; }

    public GetTagByIdQuery(int id)
    {
        Id = id;
    }
}
