using ColheitaSolidaria.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ColheitaSolidaria.Controllers
{
    public class CadastroController : Controller
    {
        private readonly AppDbContext _context;

        public CadastroController(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Perfil model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_context.Perfis.Any(u => model.CPF == model.CPF))
            {
                ViewBag.ErrorMessage = "CPF já cadastrado.";
                return View(model);
            }

            var newUser = new Perfil
            {
                Nome = model.Nome,
                Sobrenome = model.Sobrenome,
                CPF = model.CPF,
                DataNasc = model.DataNasc,
                Email = model.Email,
                Telefone = model.Telefone,
                Senha = model.Senha
            };

            _context.Perfis.Add(newUser);
            _context.SaveChanges();

            return RedirectToAction("Login", "Account");
        }

        public IActionResult EscolherCadastro()
        {
            ViewData["Title"] = "Escolha de Cadastro";
            return View();
        }

        public IActionResult CadastroRecebedor()
        {
            ViewData["Title"] = "Cadastro Recebedor";
            return View();
        }

        public IActionResult CadastroColaborador()
        {
            ViewData["Title"] = "Cadastro Colaborador";
            return View();
        }
    }
}



//using ColheitaSolidaria.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace ColheitaSolidaria.Controllers
//{
//    public class Cadastro : Controller
//    {
//        private readonly AppDbContext _context;

//        public Cadastro(AppDbContext context)
//        {
//            _context = context ?? throw new ArgumentNullException(nameof(context));
//        }

//        [HttpGet]
//        public IActionResult Register()
//        {
//            return View();
//        }


//        [HttpPost]
//        public IActionResult Register(string username, string sobrenome, string cpf, DateTime dataNasc, string email, string telefone, string password)
//        {
//            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(password))
//            {
//                ViewBag.ErrorMessage = "Todos os campos obrigatórios devem ser preenchidos.";
//                return View();
//            }

//            if (_context.Perfis.Any(u => u.CPF == cpf))
//            {
//                ViewBag.ErrorMessage = "CPF já cadastrado.";
//                return View();
//            }

//            var newUser = new Perfis
//            {
//                Nome = username,
//                Sobrenome = sobrenome,
//                CPF = cpf,
//                DataNasc = dataNasc,
//                Email = email,
//                Telefone = telefone,
//                Senha = password
//            };

//            _context.Perfis.Add(newUser);

//            _context.SaveChanges();

//            return RedirectToAction("Login");
//        }

//    }
//}


//    public class Cadastro : Controller
//    {
//        public IActionResult EscolherCadastro()
//        {
//            ViewData["Title"] = "Escolha de Cadastro";
//            return View();
//        }
//        public IActionResult CadastroRecebedor()
//        {
//            ViewData["Title"] = "Cadastro Receptor";
//            return View();
//        }
//        public IActionResult CadastroColaborador()
//        {
//            ViewData["Title"] = "Cadastro COlaborador";
//            return View();
//        }
//    }