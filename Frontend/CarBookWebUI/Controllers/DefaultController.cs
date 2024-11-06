using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.Controllers
{
    public class DefaultController : Controller
    {
        // GET: DefaultController
        public ActionResult Index()
        {
            return View();
        }

    }
}
