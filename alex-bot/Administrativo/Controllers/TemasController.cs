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
    public class TemasController : Controller
    {
        private readonly AlexContext _context;

        public TemasController(AlexContext context)
        {
            _context = context;
        }

        // GET: Temas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Temas.ToListAsync());
        }

        // GET: Temas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tema = await _context.Temas
                .Include(t => t.IncPor)
                .Include(t => t.ModPor)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tema == null)
            {
                return NotFound();
            }

            return View(tema);
        }

        // GET: Temas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Temas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Descricao,DataInc,DataMod")] Tema tema)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tema);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Não foi possível salvar o tema.");
            }
            return View(tema);
        }

        // GET: Temas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tema = await _context.Temas.SingleOrDefaultAsync(m => m.Id == id);
            if (tema == null)
            {
                return NotFound();
            }
            return View(tema);
        }

        // POST: Temas/Edit/5
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

            var tema = await _context.Temas.SingleOrDefaultAsync(t => t.Id == id);

            if (await TryUpdateModelAsync<Tema>(tema, "", t => t.Nome, t => t.Descricao))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Não foi possível salvar.");
                }
            }
            return View(tema);
        }

        // GET: Temas/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tema = await _context.Temas
                .Include(t => t.IncPor)
                .Include(t => t.ModPor)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tema == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Não foi possível excluir.";
            }

            return View(tema);
        }

        // POST: Temas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tema = await _context.Temas 
                .AsNoTracking()
                .SingleOrDefaultAsync(t => t.Id == id);

            if (tema == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                _context.Temas.Remove(tema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
        }

        private bool TemaExists(int id)
        {
            return _context.Temas.Any(e => e.Id == id);
        }
    }
}
