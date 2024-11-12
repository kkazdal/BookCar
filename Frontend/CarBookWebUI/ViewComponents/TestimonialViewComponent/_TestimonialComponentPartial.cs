using System;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.TestimonialViewComponent;

public class _TestimonialComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _TestimonialComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var request = _httpClientFactory.CreateClient();
        var response = await request.GetAsync("http://localhost:5002/api/Testimonial/GetTestimonialList");

        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var convert = JsonConvert.DeserializeObject<List<TestimonialDto>>(jsonData);

            return View(convert);
        }

        return View();
    }

}
