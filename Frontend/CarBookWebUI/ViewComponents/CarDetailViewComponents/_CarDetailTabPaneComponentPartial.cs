using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.CarDetailViewComponents;

public class _CarDetailTabPaneComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
