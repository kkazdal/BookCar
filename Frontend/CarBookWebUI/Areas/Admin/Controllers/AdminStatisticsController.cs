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

            ViewBag.BlogCount = await GetCountAsync(client, "http://localhost:5002/api/Statistics/GetBlogCount");
            ViewBag.LocationCount = await GetCountAsync(client, "http://localhost:5002/api/Statistics/GetLocationCount");
            ViewBag.CarCount = await GetCountAsync(client, "http://localhost:5002/api/Statistics/GetTotalCarCount");
            ViewBag.AuthorCount = await GetCountAsync(client, "http://localhost:5002/api/Statistics/GetAuthorCount");

            ViewBag.BlogTitle = await GetStringAsync(client, "http://localhost:5002/api/Statistics/GetBlogTitleByMaxComment");

            ViewBag.DailyAmount = await GetAmountAsync(client, "http://localhost:5002/api/Statistics/GetAvgRentPriceForDaily");
            ViewBag.WeeklyAmount = await GetAmountAsync(client, "http://localhost:5002/api/Statistics/GetAvgRentPriceForWeekly");
            ViewBag.MontlyAmount = await GetAmountAsync(client, "http://localhost:5002/api/Statistics/GetAvgRentPriceForMontly");



            return View();
        }

    }
}
