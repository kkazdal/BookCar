using System;
using CarBook.Dto.CarFeaturesDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.CarDetailViewComponents;

public class _CarDetailCarFeatureByCarIdComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _CarDetailCarFeatureByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        ViewBag.carid = id;
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5002/api/CarFeatures/GetCarFeaturesByCarId?carId=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetCarFeaturesByCarIdDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
