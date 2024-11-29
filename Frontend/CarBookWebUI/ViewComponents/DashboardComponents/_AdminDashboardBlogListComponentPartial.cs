using System;
using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.DashboardComponents;

public class _AdminDashboardBlogListComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _AdminDashboardBlogListComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var createClient = _httpClientFactory.CreateClient();
        var request = await createClient.GetAsync("http://localhost:5002/api/Blog/GetBlogsWithAuthorList");

        if (request.IsSuccessStatusCode)
        {
            var jsonString = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<GetBlogsWithAuthorDto>>(jsonString).Take(7).ToList();

            return View(response);
        }
        return View();
    }
}
