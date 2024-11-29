using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarFeaturesCommands;

public class CreateCarFeatureByCarCommand : IRequest
{
    public int CarId { get; set; }
    public int FeatureId { get; set; }
    public bool Available { get; set; }
}
