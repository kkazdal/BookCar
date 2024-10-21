using CarBook.Application.Features.CQRS.Results.Banner;
using CarBook.Application.Features.CQRS.Results.Brand;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;


public class GetBrandByIdQueryHandle
{
    private readonly IRepository<Brand> _repository;

    public GetBrandByIdQueryHandle(IRepository<Brand> repository)
    {
        _repository = repository;
    }


    public async Task<GetBrandByIdQueryResult> handle(GetBrandQueryByIdQuery getBannerQueryByIdResult)
    {
        var response = await _repository.GetByIdAsync(getBannerQueryByIdResult.id);
        return new GetBrandByIdQueryResult
        {
            BrandId = response.BrandId,
            Name = response.Name
        };
    }
}
