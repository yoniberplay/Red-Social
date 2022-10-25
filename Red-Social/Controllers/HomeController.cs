using Microsoft.AspNetCore.Mvc;
using Red_Social.Middlewares;
using Red_Social.Models;
using System.Diagnostics;

namespace Red_Social.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ValidateUserSession _validateUserSession;
        public HomeController(ILogger<HomeController> logger, ValidateUserSession validateUserSession)
        {
            _validateUserSession = validateUserSession;
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}