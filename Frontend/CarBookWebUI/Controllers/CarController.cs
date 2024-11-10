using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ActionResult> Index()
        {
            var createClient = _httpClientFactory.CreateClient();
            var request = await createClient.GetAsync("http://localhost:5000/api/Car/GetCarsWithPricingList");

            if (request.IsSuccessStatusCode)
            {
                var jsonData = await request.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<List<CarWithPricingModelDto>>(jsonData);

                return View(response);
            }
            return View();
        }

    }
}
