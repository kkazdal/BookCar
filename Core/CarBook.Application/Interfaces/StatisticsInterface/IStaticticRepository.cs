using System;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;

namespace CarBook.Application.Interfaces.StatisticsInterface;

public interface IStaticticRepository
{
    public Task<GetLocationCountResult> GetLocationCount();//Lokasyon sayısı
    public Task<int> GetAuthorCount();//Yazar sayısı
    public Task<int> GetBlogCount();//blog sayısı
    public Task<int> GetBrandCount();//marka sayısı
    public Task<decimal> GetAvgRentPriceForDaily();//Günlük ortalama araç kiralama sayısı
    public Task<decimal> GetAvgRentPriceForWeekly();//Haftalık ortalama araç kiralama sayısı
    public Task<decimal> GetAvgRentPriceForMontly();//Aylık ortalama araç kiralama sayısı
    public Task<int> GetCarCountByTransmissionIsAuto();//Otomatik vites araç sayısı
    public Task<string> BrandNameByMaxCar();//En fazla araçlı marka
    public Task<string> BlogTitleByMaxBlogComment();//en fazla yorum alan blog başlığı
    public Task<int> GetCarCountByKmSmallerThan1000();//1000 km den düşük araç sayısı
    public Task<int> GetCarCountByFuelGasolineOrDiesel();//Benzin veya dizel araçlar sayısı
    public Task<int> GetCarCountByFuelElectric();//elektrikli sayısı
    public Task<decimal> GetCarBrandAndModelByRentPriceDailyMax();//en pahalı araç
    public Task<decimal> GetCarBrandAndModelByRentPriceDailyMin();//en ucuz araç
    public Task<List<NumberOfRentalByYearResult>> GetNumberOfRentalByYearResult();
    public Task<List<NumberOfVehiclesByCarResult>> GetNumberOfVehiclesByCar();

}
