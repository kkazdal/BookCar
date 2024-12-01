using System;
using CarBook.Application.Features.Mediator.Queries;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarDescriptionRepositories;
using CarBook.CarBookDomain.Entities;
using MediatR;


public class GetCarDescriptionHandler : IRequestHandler<GetCarDescriptionQuery, GetCarDescriptionResult>
{
    private readonly ICarDescriptionRepository _repository;

    public GetCarDescriptionHandler(ICarDescriptionRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetCarDescriptionResult> Handle(GetCarDescriptionQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetDescriptionByCarId(request.CarId);

        return response;
    }
}
