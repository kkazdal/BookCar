using System;
using System.Diagnostics;
using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.BlogViewComponents;

public class _TagCloudComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _TagCloudComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int blogId)
    {
        ViewBag.BlogId = blogId;
 
        var createClient = _httpClientFactory.CreateClient();
        var request = await createClient.GetAsync("http://localhost:5002/api/Tag/GetTagByBlogIdList?blogId=" + blogId);
        Debug.WriteLine(request);
        if (request.IsSuccessStatusCode)
        {
            var jsonString = await request.Content.ReadAsStringAsync();
            Debug.WriteLine(jsonString);

            var response = JsonConvert.DeserializeObject<List<GetTagByBlogIdDto>>(jsonString);

            return View(response);
        }
        return View();
    }
}
