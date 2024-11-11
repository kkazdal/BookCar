using System;
using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.BlogViewComponents;

public class _BlogDetailRecentBlogComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _BlogDetailRecentBlogComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var createClient = _httpClientFactory.CreateClient();
        var request = await createClient.GetAsync("http://localhost:5000/api/Blog/GetLastBlogsByNumber?blogNumber=3");
        if (request.IsSuccessStatusCode)
        {
            var jsonString = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<LastBlogsDto>>(jsonString);

            return View(response);
        }
        return View();
    }
}
