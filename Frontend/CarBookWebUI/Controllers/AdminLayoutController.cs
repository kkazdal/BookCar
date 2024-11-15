using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        // GET: AdminLayoutController
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AdminHeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminSidebarPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminFooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminScriptPartial()
        {
            return PartialView();
        }
    }
}
