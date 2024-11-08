using System;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.AuthorQueries;

public class GetAuthorQueryById : IRequest<GetQueryAuthorByIdResult>
{
    public int Id { get; set; }

    public GetAuthorQueryById(int id)
    {
        Id = id;
    }
}
