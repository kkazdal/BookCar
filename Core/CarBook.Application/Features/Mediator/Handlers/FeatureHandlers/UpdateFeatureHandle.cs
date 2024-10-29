

using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;

public class UpdateFeatureHandle : IRequestHandler<UpdateFeatureCommand>
{
    private readonly IRepository<Feature> _repository;

    public UpdateFeatureHandle(IRepository<Feature> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
        var feature = await _repository.GetByIdAsync(request.Id);
        feature.Name = request.Name;
        await _repository.UpdateAsync(feature);
    }
}
