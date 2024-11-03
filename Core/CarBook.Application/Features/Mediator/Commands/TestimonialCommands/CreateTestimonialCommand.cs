using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands;

public class CreateTestimonialCommand : IRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
    public string Name { get; set; }
}
