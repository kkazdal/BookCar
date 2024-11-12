using System;
using System.Diagnostics;
using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.BlogViewComponents;

public class _BlogDetailAuthorAboutAndBlogComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _BlogDetailAuthorAboutAndBlogComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        var createClient = _httpClientFactory.CreateClient();
        var request = await createClient.GetAsync("http://localhost:5002/api/Blog/GetBlogById?id=" + id);

        if (request.IsSuccessStatusCode)
        {
            var json = await request.Content.ReadAsStringAsync();
            var convert = JsonConvert.DeserializeObject<GetBlogById>(json);
            Debug.WriteLine(json);

            return View(convert);
        }
        return View();
    }
}
