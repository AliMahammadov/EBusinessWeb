using EBusinessEntity.Entities;
using EBusinessService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EBusinessWeb.Areas.Manage.Controllers
{
    [Area("Manage"), Authorize(Roles = "Super Admin ,Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService service;

        public ContactController(IContactService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            await service.GetAllContactsAsync();
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
              await service.DeleteContactAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Reply(int id) //cavab ver
        {
            await service.GetContactByIdAsync(id);
            return View();
        }
       

    }
}
