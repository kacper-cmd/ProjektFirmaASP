using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.CMS;

namespace Firma.Intranet.Controllers
{
    public class DodatkoweInformacjeController : Controller
    {
        private readonly FirmaContext _context;

        public DodatkoweInformacjeController(FirmaContext context)
        {
            _context = context;
        }

        // GET: DodatkoweInformacje
        public async Task<IActionResult> Index()
        {
              return _context.DodatkoweInformacje != null ? 
                          View(await _context.DodatkoweInformacje.ToListAsync()) :
                          Problem("Entity set 'FirmaContext.DodatkoweInformacje'  is null.");
        }

        // GET: DodatkoweInformacje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DodatkoweInformacje == null)
            {
                return NotFound();
            }

            var dodatkoweInformacje = await _context.DodatkoweInformacje
                .FirstOrDefaultAsync(m => m.IdDodatkowychInformacji == id);
            if (dodatkoweInformacje == null)
            {
                return NotFound();
            }

            return View(dodatkoweInformacje);
        }

        // GET: DodatkoweInformacje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DodatkoweInformacje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDodatkowychInformacji,LinkTytul,Tytul,Tresc,Pozycja")] DodatkoweInformacje dodatkoweInformacje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dodatkoweInformacje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dodatkoweInformacje);
        }

        // GET: DodatkoweInformacje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DodatkoweInformacje == null)
            {
                return NotFound();
            }

            var dodatkoweInformacje = await _context.DodatkoweInformacje.FindAsync(id);
            if (dodatkoweInformacje == null)
            {
                return NotFound();
            }
            return View(dodatkoweInformacje);
        }

        // POST: DodatkoweInformacje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDodatkowychInformacji,LinkTytul,Tytul,Tresc,Pozycja")] DodatkoweInformacje dodatkoweInformacje)
        {
            if (id != dodatkoweInformacje.IdDodatkowychInformacji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dodatkoweInformacje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DodatkoweInformacjeExists(dodatkoweInformacje.IdDodatkowychInformacji))
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
            return View(dodatkoweInformacje);
        }

        // GET: DodatkoweInformacje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DodatkoweInformacje == null)
            {
                return NotFound();
            }

            var dodatkoweInformacje = await _context.DodatkoweInformacje
                .FirstOrDefaultAsync(m => m.IdDodatkowychInformacji == id);
            if (dodatkoweInformacje == null)
            {
                return NotFound();
            }

            return View(dodatkoweInformacje);
        }

        // POST: DodatkoweInformacje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DodatkoweInformacje == null)
            {
                return Problem("Entity set 'FirmaContext.DodatkoweInformacje'  is null.");
            }
            var dodatkoweInformacje = await _context.DodatkoweInformacje.FindAsync(id);
            if (dodatkoweInformacje != null)
            {
                _context.DodatkoweInformacje.Remove(dodatkoweInformacje);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DodatkoweInformacjeExists(int id)
        {
          return (_context.DodatkoweInformacje?.Any(e => e.IdDodatkowychInformacji == id)).GetValueOrDefault();
        }
    }
}
