using System;
using CarBook.Dto.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.DefaultViewComponents;

public class _DefaultCoverUILayoutComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultCoverUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var createClient = _httpClientFactory.CreateClient();
        var request = await createClient.GetAsync("http://localhost:5000/api/Banner/GetBannerList");

        if (request.IsSuccessStatusCode)
        {
            var json = await request.Content.ReadAsStringAsync();
            var convert = JsonConvert.DeserializeObject<List<ResultBannerDto>>(json);

            return View(convert);
        }
        return View();
    }
}
