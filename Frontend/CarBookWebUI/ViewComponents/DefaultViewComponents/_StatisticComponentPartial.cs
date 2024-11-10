using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.DefaultViewComponents;

public class _StatisticComponentPartial : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
