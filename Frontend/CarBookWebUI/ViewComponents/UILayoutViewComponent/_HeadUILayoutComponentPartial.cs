using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.UILayoutViewComponent;

public class _HeadUILayoutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
