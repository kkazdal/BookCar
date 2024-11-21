using System;
using System.Linq.Expressions;
using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.RentACarInterface;

public interface IRentACarRepository
{
    Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter);
}
