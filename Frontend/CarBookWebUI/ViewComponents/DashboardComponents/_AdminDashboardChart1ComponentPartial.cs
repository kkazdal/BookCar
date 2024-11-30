using System;
using System.Diagnostics;
using CarBook.Dto.BlogDtos;
using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.DashboardComponents;

public class _AdminDashboardChart1ComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _AdminDashboardChart1ComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var createClient = _httpClientFactory.CreateClient();
        var request = await createClient.GetAsync("http://localhost:5002/api/Statistics/GetNumberOfRentalByYear");

        if (request.IsSuccessStatusCode)
        {
            var jsonString = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<NumberOfRentalByYearDto>>(jsonString);

            var yearList = response.Select(x => x.Year.ToString()).ToList();
            var countList = response.Select(x => x.RentalCount).ToList();

            ViewBag.Years = yearList;
            ViewBag.Count = countList;

            return View(response);
        }
        return View();
    }
}
