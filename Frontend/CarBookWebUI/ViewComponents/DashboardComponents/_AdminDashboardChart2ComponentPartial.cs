using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.DashboardComponents;

public class _AdminDashboardChart2ComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _AdminDashboardChart2ComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var createClient = _httpClientFactory.CreateClient();
        var request = await createClient.GetAsync("http://localhost:5002/api/Statistics/GetNumberOfVehiclesByCar");

        if (request.IsSuccessStatusCode)
        {
            var jsonString = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<NumberOfVehiclesByCarDto>>(jsonString);

            var brandNameList = response.Select(x => x.BrandName.ToString()).ToList();
            var countList = response.Select(x => x.Count).ToList();

            var carTotalCount = response.Sum(x => x.Count);
            

            ViewBag.BrandNameList = brandNameList;
            ViewBag.Count = countList;
            ViewBag.TotalCarCount = carTotalCount;
            ViewBag.TotalBrandCount = brandNameList.Count();


            return View(response);
        }
        return View();
    }
}
