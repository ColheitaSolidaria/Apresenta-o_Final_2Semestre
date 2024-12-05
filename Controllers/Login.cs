using ColheitaSolidaria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;

namespace ColheitaSolidaria.Controllers
{
    public class Login : Controller
    {
        private readonly AppDbContext _context;

        public Login()
        {
            _context = new AppDbContext(); // Use injeção de dependência em projetos maiores.
        }

        [HttpGet]
        public ActionResult Perfil()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Perfil(string username, string password)
        {
            // Verificar se o usuário existe

            var user = _context.Perfis.FirstOrDefault(p => p.CPF == username && p.Senha == password);

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
        public IActionResult Escolher()
        {
            ViewData["Title"] = "Escolha de Login";
            return View();
        }
        public IActionResult LoginColaborador()
        {
            ViewData["Title"] = "Login Colaborador";
            return View();
        }
        public IActionResult LoginRecebedor()
        {
            ViewData["Title"] = "Login Recebedor";
            return View();
        }
        public IActionResult LoginAdministrador()
        {
            ViewData["Title"] = "Login Administrador";
            return View();
        }
    }
}