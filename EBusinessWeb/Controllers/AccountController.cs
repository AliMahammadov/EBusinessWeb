using Microsoft.AspNetCore.Mvc;

namespace EBusinessWeb.Controllers
{
    public class AccountController : Controller
    {
        public  async Task<IActionResult> Login()
        {
            return View();
        }
        //[HttpPost]
        //public   async Task<IActionResult>Login()
        //{
        //    return View();
        //}
        public async Task<IActionResult> Register()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Register()
        //{
        //    return View();
        //}
    }
}
