﻿using EBusinessEntity.Entities;
using EBusinessService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EBusinessWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
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
            return RedirectToAction("Index") ;
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