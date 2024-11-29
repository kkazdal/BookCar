using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarFeaturesCommands;

public class ChangeCarFeatureAvailableToTrueCommand : IRequest
{
    public int CarFeatureId { get; set; }

    public ChangeCarFeatureAvailableToTrueCommand(int carFeatureId)
    {
        CarFeatureId = carFeatureId;
    }
}
