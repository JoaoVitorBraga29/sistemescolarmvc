using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Models;

namespace SistemaEscolar.Controllers
{
    public class ContaController : Controller
    {
        private static List<Usuario> usuarios = new();

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var user = usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (user == null)
            {
                ViewBag.Erro = "Email ou senha inválidos.";
                return View();
            }

            if (user.Tipo == "Professor")
                return RedirectToAction("Index", "Aluno"); // Professores vão para cadastro aluno

            if (user.Tipo == "Aluno")
                return RedirectToAction("PainelAluno"); // Criamos já já

            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario user)
        {
            if (!ModelState.IsValid)
                return View(user);

            user.Id = usuarios.Count + 1;
            usuarios.Add(user);

            return RedirectToAction("Login");
        }

        public IActionResult PainelAluno()
        {
            return View();
        }
    }
}
