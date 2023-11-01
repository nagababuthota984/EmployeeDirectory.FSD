using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Concerns;
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
            IEnumerable<Employee> employees = await _employeeProvider.GetAllEmployeesAsync();
            return View(employees);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}