using Microsoft.AspNetCore.Mvc;

namespace EBusinessWeb.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult SendEmail()
        {
            return View();
        }
    }
}
 