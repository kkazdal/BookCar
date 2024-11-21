using System;
using System.Linq.Expressions;
using CarBook.Application.Interfaces.RentACarInterface;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.RentACarRespositories;

public class RentACarRepository : IRentACarRepository
{
    private readonly CarBookContext _carBookContext;

    public RentACarRepository(CarBookContext carBookContext)
    {
        _carBookContext = carBookContext;
    }

    public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
    {
        var values = await _carBookContext.RentACar.Where(filter).Include(x => x.Car).ThenInclude(y => y.Brand).ToListAsync();
        return values;
    }
}
