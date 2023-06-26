using Microsoft.AspNetCore.Mvc;

namespace EBusinessWeb.Controllers
{
    public class BlogDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
