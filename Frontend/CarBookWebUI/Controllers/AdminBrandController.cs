using System.Text;
using CarBook.Dto.Brand;
using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.Controllers
{
    public class AdminBrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ActionResult> Index()
        {
            var createClient = _httpClientFactory.CreateClient();
            var request = await createClient.GetAsync("http://localhost:5002/api/Brand/GetBrandList");

            if (request.IsSuccessStatusCode)
            {
                var jsonData = await request.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);

                return View(response);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBrandDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5002/api/Brand/CreateBrand", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> RemoveBrand(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5002/api/Brand/DeleteBrand?brandId={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var resposenMessage = await client.GetAsync($"http://localhost:5002/api/Brand/GetBrand?Id={id}");
            if (resposenMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposenMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBrandDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5002/api/Brand/UpdateBrand", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
