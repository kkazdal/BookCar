using System;

namespace CarBook.Application.Features.CQRS.Queries.Car;

public class GetCarQueryByIdQuery
{
    public int Id { get; set; }
    public GetCarQueryByIdQuery(int id)
    {
        this.Id = id;
    }
}
