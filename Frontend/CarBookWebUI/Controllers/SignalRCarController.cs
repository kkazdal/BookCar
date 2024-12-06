using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.Controllers
{
    public class SignalRCarController : Controller
    {
        // GET: SignalRCarController
        public IActionResult Index()
        {
            return View();
        }

    }
}
