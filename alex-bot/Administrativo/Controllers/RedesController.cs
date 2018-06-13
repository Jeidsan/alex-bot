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
    public class RedesController : Controller
    {
        private readonly AlexContext _context;

        public RedesController(AlexContext context)
        {
            _context = context;
        }

        // GET: Redes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Redes.ToListAsync());
        }

        // GET: Redes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rede = await _context.Redes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (rede == null)
            {
                return NotFound();
            }

            return View(rede);
        }

        // GET: Redes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Redes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,NomeAbreviado,Descricao,Id,DataInc,DataMod")] Rede rede)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rede);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rede);
        }

        // GET: Redes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rede = await _context.Redes.SingleOrDefaultAsync(m => m.Id == id);
            if (rede == null)
            {
                return NotFound();
            }
            return View(rede);
        }

        // POST: Redes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,NomeAbreviado,Descricao,Id,DataInc,DataMod")] Rede rede)
        {
            if (id != rede.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rede);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RedeExists(rede.Id))
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
            return View(rede);
        }

        // GET: Redes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rede = await _context.Redes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (rede == null)
            {
                return NotFound();
            }

            return View(rede);
        }

        // POST: Redes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rede = await _context.Redes.SingleOrDefaultAsync(m => m.Id == id);
            _context.Redes.Remove(rede);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RedeExists(int id)
        {
            return _context.Redes.Any(e => e.Id == id);
        }
    }
}
