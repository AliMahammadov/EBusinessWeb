using EBusinessData.DAL;
using EBusinessService.Services;
using EBusinessService.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EBusinessWeb.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostService service;
        private readonly AppDbContext context;


        public BlogController(IPostService service, AppDbContext context)
        {
            this.service = service;
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var post = await service.GetAllPostAsync();
            ViewBag.Blogs= await context.Blogs.ToListAsync();
            return View(post);
        }
    }
}
