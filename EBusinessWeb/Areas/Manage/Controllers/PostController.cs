using EBusinessData.DAL;
using EBusinessEntity.Entities;
using EBusinessService.Services;
using EBusinessViewModel.Entities.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EBusinessWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PostController : Controller
    {
        private readonly IPostService service;
        private readonly AppDbContext dbContext;
        public PostController(IPostService service, AppDbContext dbContext)
        {
            this.service = service;
            this.dbContext = dbContext;
        }

        public async Task <IActionResult> Index()
        {
            ICollection<Post> posts =await service.GetAllPostAsync();

            return View(posts);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Blog = new SelectList(dbContext.Blogs,nameof(Blog.Id),nameof(Blog.Name));
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddPostVM postVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Blogs = new SelectList(dbContext.Blogs,nameof(Blog.Id), nameof(Blog.Name));
                return View();
            }
            await service.AddPostAsync(postVM);
            return RedirectToAction(nameof(Create));
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id!=null)
            {
                await service.RemovePostAsync(id);
            }
            return RedirectToAction($"{nameof(Index)}");
        }
        public async Task<IActionResult> Update(int id)
        {
            if (!ModelState.IsValid) return View();
            ViewBag.Blog = new SelectList(dbContext.Blogs,nameof(Blog.Id), nameof(Blog.Name));
            return View();

        }
        public async Task<IActionResult> Update(int id, EditPostVM postVM)
        {
            if (!ModelState.IsValid) return View();
            ViewBag.Blog = new SelectList(dbContext.Blogs, nameof(Blog.Id), nameof(Blog.Name));
            await service.EditPostPostAsync(id, postVM);
            return RedirectToAction("Index");   
        }
    }
}
