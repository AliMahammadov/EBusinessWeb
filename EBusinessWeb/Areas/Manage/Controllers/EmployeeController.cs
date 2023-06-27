using Microsoft.AspNetCore.Mvc;

namespace EBusinessWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class EmployeeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
