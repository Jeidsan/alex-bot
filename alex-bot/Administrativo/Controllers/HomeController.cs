using Administrativo.Data;
using Administrativo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Controllers
{
    public class HomeController : Controller
    {
        private readonly AlexContext _context;

        public HomeController(AlexContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.QtdeTemas = String.Format("{0} temas cadastrados", _context.Temas.Count());
            ViewBag.QtdePerguntas = String.Format("{0} perguntas cadastradas", _context.Perguntas.Count());
            ViewBag.QtdeRespostas = String.Format("{0} respostas cadastradas", _context.Respostas.Count());
            ViewBag.QtdeAdministradores = String.Format("{0} administradores cadastrados", _context.Administradores.Count());

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Atualizar()
        {

            var respostas = _context.Respostas
                .Include(r => r.Pergunta)
                    .ThenInclude(p => p.Tema);
            var erro = await AlexUpdater.Atualizar(respostas.ToList());

            ViewData["Erro"] = erro;
  
            return RedirectToAction(nameof(Index));
        }
    }
}
