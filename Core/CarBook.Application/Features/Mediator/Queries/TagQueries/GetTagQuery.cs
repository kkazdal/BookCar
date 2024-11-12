using System;
using CarBook.Application.Features.Mediator.Results.TagResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TagQueries;

public class GetTagQuery : IRequest<List<GetTagQueryResult>>
{
    public int Id { get; set; }
    public string TagName { get; set; }
}
