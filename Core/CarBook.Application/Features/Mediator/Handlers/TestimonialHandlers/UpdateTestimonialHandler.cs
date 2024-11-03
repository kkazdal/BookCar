using System;
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers;

public class UpdateTestimonialHandler : IRequestHandler<UpdateTestimonialCommand>
{
    private readonly IRepository<Testimonial> _repository;

    public UpdateTestimonialHandler(IRepository<Testimonial> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.TestimonialId);
        response.Title = request.Title;
        response.Description = request.Description;
        response.Comment = request.Comment;
        response.ImageUrl = request.ImageUrl;

        await _repository.UpdateAsync(response);
    }
}
