using System.Diagnostics;
using System.Text;
using CarBook.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpFactory;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IHttpClientFactory httpFactory, ILogger<ContactController> logger)
        {
            _httpFactory = httpFactory;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(CreateContactDto createContactDto)
        {
            var createClient = _httpFactory.CreateClient();
            createContactDto.SendDate = DateTime.Now;
            var jsonConvert = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var request = await createClient.PostAsync("http://localhost:5000/api/Contact/CreateContact", stringContent);

            if (request.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }

            return View();
        }

    }
}
