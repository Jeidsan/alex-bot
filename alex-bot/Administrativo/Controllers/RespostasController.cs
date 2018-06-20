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
    public class RespostasController : Controller
    {
        private readonly AlexContext _context;

        public RespostasController(AlexContext context)
        {
            _context = context;
        }

        // GET: Respostas
        public async Task<IActionResult> Index()
        {
            var respostas = _context.Respostas
                .Include(r => r.Pergunta)
                .Include(r => r.Anexos)
                .AsNoTracking();
            return View(await respostas.ToListAsync());
        }

        // GET: Respostas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resposta = await _context.Respostas
                .Include(r => r.IncPor)
                .Include(r => r.ModPor)
                .Include(r => r.Pergunta)
                .Include(r => r.Anexos)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // GET: Respostas/Create
        public IActionResult Create()
        {
            PopulatePerguntasDropDownList();
            return View();
        }

        private void PopulatePerguntasDropDownList(object selectedPergunta = null)
        {
            ViewBag.PerguntaId = new SelectList(_context.Perguntas.OrderBy(p => p.Descricao).AsNoTracking(), "Id", "Descricao", selectedPergunta);
        }

        // POST: Respostas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PerguntaId,Descricao")] Resposta resposta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    resposta.DataMod = DateTime.Now;
                    _context.Add(resposta);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível salvar a resposta.");
            }
            PopulatePerguntasDropDownList(resposta.PerguntaId);
            return View(resposta);
        }

        // GET: Respostas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resposta = await _context.Respostas
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (resposta == null)
            {
                return NotFound();
            }
            PopulatePerguntasDropDownList(resposta.PerguntaId);
            return View(resposta);
        }

        // POST: Respostas/Edit/5
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

            var resposta = await _context.Respostas.SingleOrDefaultAsync(r => r.Id == id);
            
            if(await TryUpdateModelAsync<Resposta>(resposta,
                "",
                r => r.Descricao, 
                r => r.PerguntaId, 
                r => r.DataMod))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch(DbUpdateException)
                {
                    ModelState.AddModelError("", "Não foi possível salvar a resposta.");
                }
            }
            PopulatePerguntasDropDownList(resposta.PerguntaId);
            return View(resposta);
        }

        // GET: Respostas/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resposta = await _context.Respostas
                .Include(p => p.IncPor)
                .Include(p => p.ModPor)
                .Include(p => p.Pergunta)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);  
            if (resposta == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Não foi possível excluir a resposta.";
            }

            return View(resposta);
        }

        // POST: Respostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resposta = await _context.Respostas
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);

            if (resposta == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Respostas.Remove(resposta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("Delete", new { id = id, saveChandesError = true });
            }
        }

        private bool RespostaExists(int id)
        {
            return _context.Respostas.Any(e => e.Id == id);
        }
    }
}
