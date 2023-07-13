using EBusinessService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EBusinessWeb.Areas.Manage.Controllers
{
    [Area("Manage"), Authorize(Roles = "Super Admin ,Admin")]
    public class AboutController : Controller
    {
        //private readonly IAboutService service;

        //public AboutController(IAboutService service)
        //{
        //    this.service = service;
        //}

        public async Task<IActionResult> Index()
        {
           //await service.GetAllAboutAsync();
            return View();
        }
    }
}
