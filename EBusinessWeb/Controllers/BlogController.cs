using EBusinessData.DAL;
using EBusinessEntity.Entities;
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
        private readonly ICommentService commentService;


        public BlogController(IPostService service, AppDbContext context, IBlogService blogService, ICommentService commentService)
        {
            this.service = service;
            this.context = context;
            this.blogService = blogService;
            this.commentService = commentService;
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
        [HttpPost]
        public async Task<IActionResult> Comment(int id,Comment comment)
        {
            if (!ModelState.IsValid) return View();
            await commentService.AddCommentAsync(id, comment);
            return RedirectToAction("PostDetail", new RouteValueDictionary(new { Controller = "Blog", Action = "PostDetail", id = id }));
        }
    }
}
