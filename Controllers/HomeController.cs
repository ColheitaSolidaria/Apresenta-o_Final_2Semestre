using ColheitaSolidaria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ColheitaSolidaria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Como ajudar?";
            return View();
        }

        public IActionResult Colaboradores()
        {
            ViewData["Title"] = "Colaboradores";
            return View();

        }

        public IActionResult Contato()
        {
            ViewData["Title"] = "Contato";
            return View();
        }

        public IActionResult SobreNos()
        {
            ViewData["Title"] = "Sobre nós";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
