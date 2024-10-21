using System;
using CarBook.Application.Features.CQRS.Commands.Banner;
using CarBook.Application.Features.CQRS.Commands.Brand;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class UpdateBrandHandle
{
    private readonly IRepository<Brand> _repository;

    public UpdateBrandHandle(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task handle(UpdateBrandCommand updateBrandCommand)
    {
        Brand brand = await _repository.GetByIdAsync(updateBrandCommand.BrandId);

        brand.Name = updateBrandCommand.Name;

        await _repository.UpdateAsync(brand);
    }
}
