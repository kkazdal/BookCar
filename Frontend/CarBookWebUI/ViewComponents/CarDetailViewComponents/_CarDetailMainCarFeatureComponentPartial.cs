using System;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.CarDetailViewComponents;

public class _CarDetailMainCarFeatureComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _CarDetailMainCarFeatureComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        ViewBag.carid = id;
        var client = _httpClientFactory.CreateClient();
        var resposenMessage = await client.GetAsync($"http://localhost:5002/api/Car/GetCar?id={id}");
        if (resposenMessage.IsSuccessStatusCode)
        {
            var jsonData = await resposenMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultCarWithBrandsDtos>(jsonData);
            return View(values);
        }
        return View();
    }
}
