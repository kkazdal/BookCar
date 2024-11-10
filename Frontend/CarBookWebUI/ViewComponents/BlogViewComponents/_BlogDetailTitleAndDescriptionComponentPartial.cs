using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.BlogViewComponents;

public class _BlogDetailTitleAndDescriptionComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
