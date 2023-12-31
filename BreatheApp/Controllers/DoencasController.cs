﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BreatheApp.Data;
using BreatheApp.Models;
using System.Data;

namespace BreatheApp.Controllers
{
    public class DoencasController : Controller
    {
        private readonly BreatheContext _context;

        public DoencasController(BreatheContext context)
        {
            _context = context;
        }

        // GET: Doencas
        public async Task<IActionResult> Index(string SearchBy)
        {
            if (String.IsNullOrEmpty(SearchBy))
            {
                return _context.Doencas != null ?
                    View(await _context.Doencas.ToListAsync()) :
                    Problem("Entity set 'BreatheContext.Doencas'  is null.");
            } else
            {
                var searchIteams = await _context.Doencas.Where(d => d.Nome.Contains(SearchBy)).ToListAsync();
                return View(searchIteams);
            }

        }

        // GET: Doencas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doencas == null)
            {
                return NotFound();
            }

            var doenca = await _context.Doencas
                .FirstOrDefaultAsync(m => m.DoencaId == id);
            if (doenca == null)
            {
                return NotFound();
            }

            return View(doenca);
        }

        // GET: Doencas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doencas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoencaId,Nome,Descricao,Recomendacoes")] Doenca doenca)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _context.Add(doenca);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DataException error)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                Console.WriteLine(error.Message);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + error.Message);
            }
            return View(doenca);
        }

        // GET: Doencas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doencas == null)
            {
                return NotFound();
            }

            var doenca = await _context.Doencas.FindAsync(id);
            if (doenca == null)
            {
                return NotFound();
            }
            return View(doenca);
        }

        // POST: Doencas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoencaId,Nome,Descricao,Recomendacoes")] Doenca doenca)
        {
            if (id != doenca.DoencaId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(doenca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoencaExists(doenca.DoencaId))
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
            return View(doenca);
        }

        // GET: Doencas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doencas == null)
            {
                return NotFound();
            }

            var doenca = await _context.Doencas
                .FirstOrDefaultAsync(m => m.DoencaId == id);
            if (doenca == null)
            {
                return NotFound();
            }

            return View(doenca);
        }

        // POST: Doencas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doencas == null)
            {
                return Problem("Entity set 'BreatheContext.Doencas'  is null.");
            }
            var doenca = await _context.Doencas.FindAsync(id);
            if (doenca != null)
            {
                _context.Doencas.Remove(doenca);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoencaExists(int id)
        {
          return (_context.Doencas?.Any(e => e.DoencaId == id)).GetValueOrDefault();
        }
    }
}
