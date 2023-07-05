using EBusinessEntity.Entities;
using EBusinessService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EBusinessWeb.Areas.Manage.Controllers
{
    [Area("Manage"), Authorize(Roles = "Super Admin ,Admin")]
    public class PositionController : Controller
    {
        private readonly IPositionService service;

        public PositionController(IPositionService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var position = await service.GetAllPositionAsync();
            return View(position);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Position position)
        {
            if (!ModelState.IsValid) return View();
            await service.AddPosition(position);
            return RedirectToAction("Create") ;
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return NotFound(); 
            await service.DeletePosition(id);
            
            return RedirectToAction($"{nameof(Index)}");
        }
        public async Task<IActionResult> Update(int id)
        {
            var position = await service.UpdatePositionAsync(id);
            return View(position);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,Position position)
        {
            if (!ModelState.IsValid) return View();
            await service.UpdatePositionPostAsync(id, position);
            return RedirectToAction($"{nameof(Index)}");
        }

    }
}
