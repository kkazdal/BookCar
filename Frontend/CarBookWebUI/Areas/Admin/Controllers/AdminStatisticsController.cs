using System.Diagnostics;
using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private async Task<int> GetCountAsync(HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetCountDto>(jsonData);
                return values.count;
            }
            return 0; // Başarısız olursa varsayılan olarak 0 döner
        }

        private async Task<string> GetStringAsync(HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetNameDto>(jsonData);
                return values.Name;
            }
            return ""; // Başarısız olursa varsayılan olarak 0 döner
        }

        private async Task<decimal> GetAmountAsync(HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetAmountDto>(jsonData);
                return values.Amount;
            }
            return 0; // Başarısız olursa varsayılan olarak 0 döner
        }


        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            // Tüm çağrıları paralel olarak başlatıyoruz
            var blogCountTask = GetCountAsync(client, "http://localhost:5002/api/Statistics/GetBlogCount");
            var locationCountTask = GetCountAsync(client, "http://localhost:5002/api/Statistics/GetLocationCount");
            var carCountTask = GetCountAsync(client, "http://localhost:5002/api/Statistics/GetTotalCarCount");
            var authorCountTask = GetCountAsync(client, "http://localhost:5002/api/Statistics/GetAuthorCount");

            var carCountByKmTask = GetCountAsync(client, "http://localhost:5002/api/Statistics/GetCarCountByKmSmallerThan1000");
            var carCountByFuelElectricTask = GetCountAsync(client, "http://localhost:5002/api/Statistics/GetCarCountByFuelElectric");
            var carCountByFuelGasolineOrDieselTask = GetCountAsync(client, "http://localhost:5002/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            var carCountByTransmissionAutoTask = GetCountAsync(client, "http://localhost:5002/api/Statistics/GetCarCountByTransmissionIsAuto");

            var blogTitleTask = GetStringAsync(client, "http://localhost:5002/api/Statistics/GetBlogTitleByMaxComment");

            var dailyAmountTask = GetAmountAsync(client, "http://localhost:5002/api/Statistics/GetAvgRentPriceForDaily");
            var weeklyAmountTask = GetAmountAsync(client, "http://localhost:5002/api/Statistics/GetAvgRentPriceForWeekly");
            var monthlyAmountTask = GetAmountAsync(client, "http://localhost:5002/api/Statistics/GetAvgRentPriceForMontly");
            var rentPriceDailyMaxTask = GetAmountAsync(client, "http://localhost:5002/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            var rentPriceDailyMinTask = GetAmountAsync(client, "http://localhost:5002/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");

            // Tüm task'leri bekliyoruz
            await Task.WhenAll(
                blogCountTask, locationCountTask, carCountTask, authorCountTask,
                carCountByKmTask, carCountByFuelElectricTask, carCountByFuelGasolineOrDieselTask, carCountByTransmissionAutoTask,
                blogTitleTask,
                dailyAmountTask, weeklyAmountTask, monthlyAmountTask, rentPriceDailyMaxTask, rentPriceDailyMinTask
            );

            // Sonuçları atama
            ViewBag.BlogCount = blogCountTask.Result;
            ViewBag.LocationCount = locationCountTask.Result;
            ViewBag.CarCount = carCountTask.Result;
            ViewBag.AuthorCount = authorCountTask.Result;

            ViewBag.CarCountByKmSmallerThan1000 = carCountByKmTask.Result;
            ViewBag.CarCountByFuelElectric = carCountByFuelElectricTask.Result;
            ViewBag.CarCountByFuelGasolineOrDiesel = carCountByFuelGasolineOrDieselTask.Result;
            ViewBag.CarCountByTransmissionIsAuto = carCountByTransmissionAutoTask.Result;

            ViewBag.BlogTitle = blogTitleTask.Result;

            ViewBag.DailyAmount = dailyAmountTask.Result.ToString("F2");
            ViewBag.WeeklyAmount = weeklyAmountTask.Result.ToString("F2");
            ViewBag.MontlyAmount = monthlyAmountTask.Result.ToString("F2");
            ViewBag.RentPriceDailyMax = rentPriceDailyMaxTask.Result.ToString("F2");
            ViewBag.RentPriceDailyMin = rentPriceDailyMinTask.Result.ToString("F2");

            return View();

            return View();
        }

    }
}
