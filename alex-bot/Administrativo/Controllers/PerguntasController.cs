using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Administrativo.Data;
using Administrativo.Models;

namespace Administrativo.Controllers
{
    public class PerguntasController : Controller
    {
        private readonly AlexContext _context;

        public PerguntasController(AlexContext context)
        {
            _context = context;
        }

        // GET: Perguntas
        public async Task<IActionResult> Index()
        {
            var perguntas = _context.Perguntas
                .Include(p => p.Tema)
                .AsNoTracking();
            return View(await perguntas.ToListAsync());
        }

        // GET: Perguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas
                .Include(p => p.IncPor)
                .Include(p => p.ModPor)
                .Include(p => p.Tema)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pergunta == null)
            {
                return NotFound();
            }

            return View(pergunta);
        }

        // GET: Perguntas/Create
        public IActionResult Create()
        {            
            PopulateTemasDropDownList();
            return View();
        }

        private void PopulateTemasDropDownList(object selectedTema = null)
        {
            //var temaQuery = from t in _context.Temas
            //                orderby t.Nome
            //                select t;
            ViewBag.TemaId = new SelectList(_context.Temas.OrderBy(t => t.Nome).AsNoTracking().ToList(), "Id", "Nome", selectedTema);
        }

        // POST: Perguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TemaId,Descricao")] Pergunta pergunta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    pergunta.DataMod = DateTime.Now;
                    _context.Add(pergunta);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível salvar a pergunta.");
            }            
            PopulateTemasDropDownList(pergunta.TemaId);
            return View(pergunta);
        }

        // GET: Perguntas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pergunta == null)
            {
                return NotFound();
            }
            PopulateTemasDropDownList(pergunta.TemaId);
            return View(pergunta);
        }

        // POST: Perguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas.SingleOrDefaultAsync(p => p.Id == id);

            if (await TryUpdateModelAsync<Pergunta>(pergunta, 
                "", 
                p => p.Descricao, p => p.TemaId))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Não foi possível salvar.");
                }
            }
            PopulateTemasDropDownList(pergunta.TemaId);
            return View(pergunta);
        }

        // GET: Perguntas/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas
                .Include(p => p.IncPor)
                .Include(p => p.ModPor)
                .Include(p => p.Tema)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pergunta == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Não foi possível excluir.";
            }

            return View(pergunta);
        }

        // POST: Perguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pergunta = await _context.Perguntas
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);

            if (pergunta == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                _context.Perguntas.Remove(pergunta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("Delete", new { id = id, saveChandesError = true });
            }
        }

        private bool PerguntaExists(int id)
        {
            return _context.Perguntas.Any(e => e.Id == id);
        }
    }
}
