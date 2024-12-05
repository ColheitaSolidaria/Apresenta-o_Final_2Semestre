using ColheitaSolidaria.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColheitaSolidaria.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController()
        {
            _context = new AppDbContext(); // Use injeção de dependência em projetos maiores.
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Verificar se o usuário existe

            var user = _context.Perfil.FirstOrDefault(p => p.CPF == username && p.Senha == password);

            if (user != null)
            {
                // Armazenar informações do usuário na sessão
                HttpContext.Session.SetString("UserId", user.CPF);
                HttpContext.Session.SetString("Username", user.Senha);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Usuário ou senha inválidos.";
                return View();
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear(); // Limpa a sessão
            return RedirectToAction("Login");
        }
    }
}
