using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarFeaturesCommands;

public class ChangeCarFeatureAvailableToFalseCommand : IRequest
{
    public int CarFeatureId { get; set; }

    public ChangeCarFeatureAvailableToFalseCommand(int carFeatureId)
    {
        CarFeatureId = carFeatureId;
    }
}
