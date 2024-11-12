using System;
using CarBook.Dto.FooterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.FooterViewComponents;

public class _FooterAddressViewComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _FooterAddressViewComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var createClient = _httpClientFactory.CreateClient();
        var request = await createClient.GetAsync("http://localhost:5002/api/FooterAddress/GetFooterAddressList");

        if (request.IsSuccessStatusCode)
        {
            var data = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<FooterAddressDtos>>(data);

            if (response != null && response.Count != 0)
            {
                return View(response[0]);
            }
        }

        return View();
    }
}

