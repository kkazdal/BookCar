using System;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TestimonialQueries;

public class GetTestimonialByIdQuery : IRequest<GetTestimonialQueryResult>
{
    public int Id { get; set; }

    public GetTestimonialByIdQuery(int id)
    {
        Id = id;
    }
}
