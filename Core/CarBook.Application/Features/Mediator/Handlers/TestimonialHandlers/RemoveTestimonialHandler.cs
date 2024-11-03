using System;
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers;

public class RemoveTestimonialHandler : IRequestHandler<RemoveTestimonialCommand>
{
    private readonly IRepository<Testimonial> _repository;

    public RemoveTestimonialHandler(IRepository<Testimonial> repository)
    {
        _repository = repository;
    }
    public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.TestimonialId);
        await _repository.RemoveAsync(response);
    }

}
