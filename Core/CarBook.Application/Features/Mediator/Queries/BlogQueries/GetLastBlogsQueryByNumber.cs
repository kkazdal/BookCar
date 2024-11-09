using System;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries;

public class GetLastBlogsQueryByNumber : IRequest<List<GetLastBlogsByNumberResult>>
{
    public int BlogNumber { get; set; }

    public GetLastBlogsQueryByNumber(int blogNumber)
    {
        BlogNumber = blogNumber;
    }
}
