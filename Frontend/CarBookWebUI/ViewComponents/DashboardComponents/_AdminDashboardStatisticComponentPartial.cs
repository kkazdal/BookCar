using System;
using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.DashboardComponents;

public class _AdminDashboardStatisticComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _AdminDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    private async Task<int> GetCountAsync(HttpClient client, string url)
    {
        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetCountDto>(jsonData);
            return values.count;
        }
        return 0; // Başarısız olursa varsayılan olarak 0 döner
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();

        // Tüm çağrıları paralel olarak başlatıyoruz
        var blogCountTask = GetCountAsync(client, "http://localhost:5002/api/Statistics/GetBlogCount");
        var locationCountTask = GetCountAsync(client, "http://localhost:5002/api/Statistics/GetLocationCount");
        var carCountTask = GetCountAsync(client, "http://localhost:5002/api/Statistics/GetTotalCarCount");
        var authorCountTask = GetCountAsync(client, "http://localhost:5002/api/Statistics/GetAuthorCount");

        // Tüm task'leri bekliyoruz
        await Task.WhenAll(
            blogCountTask, locationCountTask, carCountTask, authorCountTask
        );

        // Sonuçları atama
        ViewBag.BlogCount = blogCountTask.Result;
        ViewBag.LocationCount = locationCountTask.Result;
        ViewBag.CarCount = carCountTask.Result;
        ViewBag.AuthorCount = authorCountTask.Result;


        return View();

    }

}
