using System;
using CarBook.Application.Features.Mediator.Results.UserResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.UserQueries;

public class GetCheckUserQuery : IRequest<GetCheckUserQueryResult>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
