using System;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.ViewModels;
using CarBook.CarBookDomain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarPricingRepositories;

public class CarPricingRepository : ICarPricingRepository
{
    private readonly CarBookContext _carBookContext;

    public CarPricingRepository(CarBookContext carBookContext)
    {
        this._carBookContext = carBookContext;
    }

    public async Task<List<CarPricingViewModel>> GetCarPricingWithTimePeriod()
    {
        List<CarPricingViewModel> values = new List<CarPricingViewModel>();
        using (var command = _carBookContext.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "Select * From (Select Model,Name,CoverImageUrl,PricingID,Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarId Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([2],[3],[4])) as PivotTable;";
            command.CommandType = System.Data.CommandType.Text;
            _carBookContext.Database.OpenConnection();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                    {
                        Brand = reader["Name"].ToString(),
                        Model = reader["Model"].ToString(),
                        CoverImageUrl = reader["CoverImageUrl"].ToString(),
                        Amounts = new List<decimal>
                        {
                            reader["2"] != DBNull.Value ? Convert.ToDecimal(reader["2"]) : 0, // If DBNull, assign 0
                            reader["3"] != DBNull.Value ? Convert.ToDecimal(reader["3"]) : 0, // If DBNull, assign 0
                            reader["4"] != DBNull.Value ? Convert.ToDecimal(reader["4"]) : 0  // If DBNull, assign 0
                        }
                    };
                    values.Add(carPricingViewModel);
                }
            }
            _carBookContext.Database.CloseConnection();
            return values;
        }
    }
}