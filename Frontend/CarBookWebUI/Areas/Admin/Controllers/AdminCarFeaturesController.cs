using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeaturesDetail")]
    public class AdminCarFeaturesDetailController : Controller
    {
        [Route("Index/{id}")]
        public ActionResult Index(int id)
        {
            return View();
        }

    }
}
