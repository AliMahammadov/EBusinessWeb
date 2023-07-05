using Microsoft.AspNetCore.Mvc;

[Area("User")]
public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

