using EBusinessData.DAL;
using EBusinessEntity.Entities;
using EBusinessService.Services.Abstraction;
using EBusinessViewModel.Entities.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace EBusinessWeb.Areas.Manage.Controllers
{
    [Area("Manage"), Authorize(Roles = "Super Admin ,Admin")]
    public class EmployeeController : Controller //isci
    {
        private readonly IEmployeeService employeeService;
        private readonly AppDbContext context;

        public EmployeeController(IEmployeeService employeeService, AppDbContext context)
        {
            this.employeeService = employeeService;
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<Employee> employees = await employeeService.GetAllEmployeeAsync();

            return View(employees);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Position = new SelectList(context.Positions, nameof(Position.Id), nameof(Position.Name));
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeVM employeeVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Positions = new SelectList(context.Positions, nameof(Position.Id), nameof(Position.Name));
                return RedirectToAction(nameof(Create));
            }
            await employeeService.AddEmplooyeAsync(employeeVM);
            return RedirectToAction(nameof(Create));

        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id != null)
            {
                await employeeService.RemoveEmployeeAsync(id);
            }
            return RedirectToAction($"{nameof(Index)}");
        }
        public async Task<IActionResult> Update(int id)
        {
            if (!ModelState.IsValid) return View();

            ViewBag.Positions = new SelectList(context.Positions, nameof(Position.Id), nameof(Position.Name));

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateEmployeeVM employeeVM)
        {
            if (!ModelState.IsValid ) return View();

            ViewBag.Positions = new SelectList(context.Positions, nameof(Position.Id), nameof(Position.Name));


            await employeeService.UpdateEmployeeAsync(id, employeeVM);
            return RedirectToAction($"{nameof(Index)}");
        }

    }
}

