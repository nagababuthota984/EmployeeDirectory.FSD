using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectory.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfigurationRoot _config;
        public LoginController(IConfigurationRoot config)
        {
            _config = config;
        }
        public IActionResult Index()
        {

            return View();
        }

    }
}
