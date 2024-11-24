using System;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.ViewModels;
using CarBook.CarBookDomain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandler;

public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
{
    private readonly ICarPricingRepository _repository;

    public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetCarPricingWithTimePeriod();
        return values.Select(x => new GetCarPricingWithTimePeriodQueryResult
        {
            Brand = x.Brand,
            Model = x.Model,
            CoverImageUrl = x.CoverImageUrl,
            DailyAmount = x.Amounts[0],
            WeeklyAmount = x.Amounts[1],
            MonthlyAmount = x.Amounts[2]
        }).ToList();
    }
}
