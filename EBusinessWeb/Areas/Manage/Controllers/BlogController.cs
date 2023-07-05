using EBusinessEntity.Entities;
using EBusinessService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EBusinessWeb.Areas.Manage.Controllers
{
    [Area("Manage"), Authorize(Roles = "Super Admin ,Admin")]

    public class BlogController : Controller
    {
        private readonly IBlogService service;

        public BlogController(IBlogService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var blog = await service.GetAllBlogAsync();
            return View(blog);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (!ModelState.IsValid) return View();
            await service.AddBlogAsync(blog);
            return RedirectToAction($"{nameof(Create)}");
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return BadRequest();
            await service.RemoveBlogAsync(id);
            return RedirectToAction($"{nameof(Index)}");
        }
        public async Task<IActionResult> Update(int id)
        {
            var blog = await service.EditBlogAsync(id);
            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,Blog blog)
        {
            if(!ModelState.IsValid) return View();
            await service.EditPostBlogAsync(id, blog);
            return RedirectToAction(nameof(Index));
        }

    }
}
