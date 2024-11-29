using System;
using CarBook.Dto.CarPricingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarBookWebUI.ViewComponents.DashboardComponents;

public class _AdminDashboardCarPricingListComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _AdminDashboardCarPricingListComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.v1 = "Paketler";
        ViewBag.v2 = "Araç Fiyat Paketleri";
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5002/api/CarPricing/GetCarPricingWithTimePeriodList");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(jsonData);
            var resultList = jObject["result"];

            // resultList'i string'e dönüştürüp deserialize et
            var values = JsonConvert.DeserializeObject<List<ResultCarPricingListWithModelDto>>(resultList.ToString()).Take(10).ToList();

            return View(values);
        }
        return View();
    }
}
