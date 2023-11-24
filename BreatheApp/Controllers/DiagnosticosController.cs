using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BreatheApp.Data;
using BreatheApp.Models;

namespace BreatheApp.Controllers
{
    public class DiagnosticosController : Controller
    {
        private readonly BreatheContext _context;

        public DiagnosticosController(BreatheContext context)
        {
            _context = context;
        }

        // GET: Diagnosticos
        public async Task<IActionResult> Index()
        {
            var breatheContext = _context.Diagnosticos.Include(d => d.Doenca).Include(d => d.Usuario);
            return View(await breatheContext.ToListAsync());
        }

        // GET: Diagnosticos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Diagnosticos == null)
            {
                return NotFound();
            }

            var diagnostico = await _context.Diagnosticos
                .Include(d => d.Doenca)
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.DiagnosticoId == id);
            if (diagnostico == null)
            {
                return NotFound();
            }

            return View(diagnostico);
        }

        // GET: Diagnosticos/Create
        public IActionResult Create()
        {
            ViewData["DoencaId"] = new SelectList(_context.Doencas, "DoencaId", "Descricao");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email");
            return View();
        }

        // POST: Diagnosticos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiagnosticoId,UsuarioId,DoencaId")] Diagnostico diagnostico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diagnostico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoencaId"] = new SelectList(_context.Doencas, "DoencaId", "Descricao", diagnostico.DoencaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", diagnostico.UsuarioId);
            return View(diagnostico);
        }

        // GET: Diagnosticos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Diagnosticos == null)
            {
                return NotFound();
            }

            var diagnostico = await _context.Diagnosticos.FindAsync(id);
            if (diagnostico == null)
            {
                return NotFound();
            }
            ViewData["DoencaId"] = new SelectList(_context.Doencas, "DoencaId", "Descricao", diagnostico.DoencaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", diagnostico.UsuarioId);
            return View(diagnostico);
        }

        // POST: Diagnosticos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiagnosticoId,UsuarioId,DoencaId")] Diagnostico diagnostico)
        {
            if (id != diagnostico.DiagnosticoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diagnostico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiagnosticoExists(diagnostico.DiagnosticoId))
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
            ViewData["DoencaId"] = new SelectList(_context.Doencas, "DoencaId", "Descricao", diagnostico.DoencaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", diagnostico.UsuarioId);
            return View(diagnostico);
        }

        // GET: Diagnosticos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Diagnosticos == null)
            {
                return NotFound();
            }

            var diagnostico = await _context.Diagnosticos
                .Include(d => d.Doenca)
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.DiagnosticoId == id);
            if (diagnostico == null)
            {
                return NotFound();
            }

            return View(diagnostico);
        }

        // POST: Diagnosticos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Diagnosticos == null)
            {
                return Problem("Entity set 'BreatheContext.Diagnosticos'  is null.");
            }
            var diagnostico = await _context.Diagnosticos.FindAsync(id);
            if (diagnostico != null)
            {
                _context.Diagnosticos.Remove(diagnostico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiagnosticoExists(int id)
        {
          return (_context.Diagnosticos?.Any(e => e.DiagnosticoId == id)).GetValueOrDefault();
        }
    }
}
