using System;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarBookWebUI.ViewComponents.CarDetailViewComponents;

public class _CarDetailCommentsByCarIdComponentPartial : ViewComponent
{

    private readonly IHttpClientFactory _httpClientFactory;
    public _CarDetailCommentsByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        ViewBag.carid = id;
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5002/api/Review/GetReviewByCarIdList?carId=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(jsonData);
            var resultList = jObject["result"];
            
            var values = JsonConvert.DeserializeObject<List<ResultReviewByCarIdDto>>(resultList.ToString());
            return View(values);
        }
        return View();
    }
}
