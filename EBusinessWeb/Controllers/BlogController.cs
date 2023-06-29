using EBusinessService.Services;
using EBusinessService.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace EBusinessWeb.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostService service;

        public BlogController(IPostService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var post = await service.GetAllPostAsync();
            
            return View(post);
        }
    }
}
