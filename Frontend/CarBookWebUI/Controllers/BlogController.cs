using System.Text;
using CarBook.Dto.BlogDtos;
using CarBook.Dto.CommentsDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ActionResult> IndexAsync()
        {
            var createClient = _httpClientFactory.CreateClient();
            var request = await createClient.GetAsync("http://localhost:5002/api/Blog/GetBlogsWithAuthorList");

            if (request.IsSuccessStatusCode)
            {
                var jsonString = await request.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<List<GetBlogsWithAuthorDto>>(jsonString);

                return View(response);
            }
            return View();
        }

        public async Task<ActionResult> BlogDetail(int id)
        {
            ViewBag.BlogId = id;
            return View();
        }
        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.blogid = id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5002/api/Comment/CreateMediatorComment", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
