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
        public async Task<IActionResult> Create([Bind("Nome,Descricao,Id,DataInc,DataMod")] Tema tema)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Descricao,Id,DataInc,DataMod")] Tema tema)
        {
            if (id != tema.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemaExists(tema.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tema);
        }

        // GET: Temas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tema = await _context.Temas
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tema == null)
            {
                return NotFound();
            }

            return View(tema);
        }

        // POST: Temas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tema = await _context.Temas.SingleOrDefaultAsync(m => m.Id == id);
            _context.Temas.Remove(tema);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemaExists(int id)
        {
            return _context.Temas.Any(e => e.Id == id);
        }
    }
}
