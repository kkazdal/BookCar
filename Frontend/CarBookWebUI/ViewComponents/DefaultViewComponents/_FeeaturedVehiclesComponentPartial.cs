using System;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.DefaultViewComponents;

public class _FeeaturedVehiclesComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _FeeaturedVehiclesComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var createClient = _httpClientFactory.CreateClient();
        var request = await createClient.GetAsync("http://localhost:5000/api/Car/GetLastCarsByNumber?carNumber=5");

        if (request.IsSuccessStatusCode)
        {
            var json = await request.Content.ReadAsStringAsync();
            var convert = JsonConvert.DeserializeObject<List<FeaturedVehiclesDto>>(json);

            return View(convert);
        }
        return View();
    }
}
