using Microsoft.AspNetCore.Mvc;

namespace NBU.UI.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
