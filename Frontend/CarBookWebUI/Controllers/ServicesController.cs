using CarBook.Dto.ServicesDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServicesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ActionResult> Index()
        {
            var createClient = _httpClientFactory.CreateClient();
            var response = await createClient.GetAsync("http://localhost:5000/api/Service/GetServiceList");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var convert = JsonConvert.DeserializeObject<List<ServicesDto>>(jsonData);

                return View(convert);
            }
            return View();
        }

    }
}
