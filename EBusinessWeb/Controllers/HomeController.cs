using EBusinessData.DAL;
using EBusinessService.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EBusinessWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly AppDbContext context;

        public HomeController(IEmployeeService employeeService, AppDbContext context)
        {
            this.employeeService = employeeService;
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Employees = context.Employees.ToList(),
                Positions = context.Positions.ToList(),
                Contacts = context.Contacts.ToList(),
                Blogs = context.Blogs.ToList(),
                Posts = context.Posts.ToList(),
            };
            return View(homeVM);
        }
    }
}
