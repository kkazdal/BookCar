using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.BlogViewComponents;

public class _TagCloudComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
