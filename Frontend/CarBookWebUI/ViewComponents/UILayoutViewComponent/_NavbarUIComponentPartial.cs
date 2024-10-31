using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.UINavbarComponentPartial;

public class _NavbarUIComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
