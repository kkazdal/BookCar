using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries;

public class GetBlogQuery : IRequest<List<GetQueryBlogResult>>
{

}
