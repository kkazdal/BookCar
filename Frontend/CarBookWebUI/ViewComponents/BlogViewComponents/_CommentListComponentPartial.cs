using System;
using CarBook.Dto.CommentsDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarBookWebUI.ViewComponents.BlogViewComponents;

public class _CommentListComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _CommentListComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        ViewBag.BlogId = id;
        var createClient = _httpClientFactory.CreateClient();
        var request = await createClient.GetAsync("http://localhost:5002/api/Comment/GetMediatorCommentsListByBlogId?BlogId=" + id);

        if (request.IsSuccessStatusCode)
        {
            var json = await request.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            var resultList = jObject["result"];
            if (json != "[]")
            {
                var convert = JsonConvert.DeserializeObject<List<ResultCommentDto>>(resultList.ToString());
                return View(convert);
            }

            return View();

        }
        return View();
    }
}
