using System;

namespace CarBook.Application.Features.CQRS.Commands.Brand;

public class UpdateBrandCommand
{
    public int BrandId { get; set; }
    public string Name { get; set; }
}
