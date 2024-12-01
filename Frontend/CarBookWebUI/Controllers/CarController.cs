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
            var request = await createClient.GetAsync("http://localhost:5002/api/Car/GetCarsWithPricingList");

            if (request.IsSuccessStatusCode)
            {
                var jsonData = await request.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<List<CarWithPricingModelDto>>(jsonData);

                return View(response);
            }
            return View();
        }
        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.v1 = "Araç Detayları";
            ViewBag.v2 = "Aracın Teknik Aksesuar ve Özellikleri";
            ViewBag.carid = id;
            return View();
        }
    }
}
