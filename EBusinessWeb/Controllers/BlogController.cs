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
        private readonly IBlogService blogService;


        public BlogController(IPostService service, AppDbContext context, IBlogService blogService)
        {
            this.service = service;
            this.context = context;
            this.blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Posts = await service.GetAllPostAsync(),
                Blogs = await blogService.GetAllBlogAsync(),


            };
            //var post = await service.GetAllPostAsync();
            //ViewBag.Blogs= await context.Blogs.ToListAsync();
            return View(homeVM);
        }
    }
}
