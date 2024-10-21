using CarBook.Application.Features.CQRS.Commands.Banner;
using CarBook.Application.Features.CQRS.Commands.Brand;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;

public class CreateBrandHandle
{
    private readonly IRepository<Brand> _repository;

    public CreateBrandHandle(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateBrandCommand createBrandCommand)
    {
        await _repository.CreateAsync(new Brand
        {
            Name = createBrandCommand.Name
        });
    }
}
