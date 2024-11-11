using System;
using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.BlogViewComponents;

public class _BlogCategoriesComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _BlogCategoriesComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var createClient = _httpClientFactory.CreateClient();
        var request = await createClient.GetAsync("http://localhost:5000/api/Category/GetCategoryByBlogNumberList");

        if (request.IsSuccessStatusCode)
        {
            var json = await request.Content.ReadAsStringAsync();
            var convert = JsonConvert.DeserializeObject<List<CategoryDto>>(json);

            return View(convert);
        }
        return View();
    }
}
