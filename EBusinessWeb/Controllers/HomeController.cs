using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EBusinessWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}