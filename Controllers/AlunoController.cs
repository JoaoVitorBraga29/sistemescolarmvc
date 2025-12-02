using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Models;

namespace SistemaEscolar.Controllers
{
    public class AlunoController : Controller
    {
        private static List<Aluno> alunos = new();

        public IActionResult Index()
        {
            return View(alunos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Aluno aluno)
        {
            if (!ModelState.IsValid)
                return View(aluno);

            aluno.Id = alunos.Count + 1;
            alunos.Add(aluno);

            return RedirectToAction("Index");
        }

        public IActionResult Detalhes(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return NotFound();

            return View(aluno);
        }

        public IActionResult Editar(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return NotFound();

            return View(aluno);
        }

        [HttpPost]
        public IActionResult Editar(Aluno aluno)
        {
            var original = alunos.FirstOrDefault(a => a.Id == aluno.Id);
            if (original == null) return NotFound();

            original.Nome = aluno.Nome;
            original.Idade = aluno.Idade;
            original.Materia = aluno.Materia;
            original.Nota = aluno.Nota;

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return NotFound();

            return View(aluno);
        }

        [HttpPost]
        public IActionResult ConfirmarExclusao(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            if (aluno != null)
                alunos.Remove(aluno);

            return RedirectToAction("Index");
        }
    }
}
