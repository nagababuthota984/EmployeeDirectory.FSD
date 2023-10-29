using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeDirectory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeProvider _employeeProvider;

        public HomeController(ILogger<HomeController> logger, IEmployeeProvider empProvider)
        {
            _logger = logger;
            _employeeProvider = empProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Employee()
        {
            Concerns.Employee emp = await _employeeProvider.GetEmployeeByIdAsync(1);
            EmployeeModel model = new EmployeeModel
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                PreferredName = emp.PreferredName,
                JobTitle = emp.JobTitle,
                Department = emp.Department,
                Office = emp.Office,
            };
            ViewData["Employee"] = emp;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}