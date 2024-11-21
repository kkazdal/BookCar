using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.RentACarFieldComponents;

public class _RentACarFilterComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke(string v)
    {
        v = "aaaa";
        TempData["value"] = v;
        return View();
    }
}
