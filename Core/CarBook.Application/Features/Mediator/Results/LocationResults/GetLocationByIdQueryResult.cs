using System;

namespace CarBook.Application.Features.Mediator.Results.Location;

public class GetLocationByIdQueryResult
{
    public int LocationId { get; set; }
    public string Name { get; set; }
}
