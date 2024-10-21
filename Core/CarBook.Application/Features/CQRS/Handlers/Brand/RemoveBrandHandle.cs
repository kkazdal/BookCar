using CarBook.Application.Features.CQRS.Commands.Banner;
using CarBook.Application.Features.CQRS.Commands.Brand;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class RemoveBrandHandle
{
    private readonly IRepository<Brand> _repository;

    public RemoveBrandHandle(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task handle(RemoveBrandCommand removeBrandHandle)
    {
        Brand brand = await _repository.GetByIdAsync(removeBrandHandle.Id);

        await _repository.RemoveAsync(brand);
    }
}
