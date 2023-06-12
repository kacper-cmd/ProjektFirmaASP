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
    public class PartnerzyController : Controller
    {
        private readonly FirmaContext _context;

        public PartnerzyController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Partnerzy
        public async Task<IActionResult> Index()
        {
              return _context.Partner != null ? 
                          View(await _context.Partner.ToListAsync()) :
                          Problem("Entity set 'FirmaContext.Partner'  is null.");
        }

        // GET: Partnerzy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Partner == null)
            {
                return NotFound();
            }

            var partnerzy = await _context.Partner
                .FirstOrDefaultAsync(m => m.IdPartnerzy == id);
            if (partnerzy == null)
            {
                return NotFound();
            }

            return View(partnerzy);
        }

        // GET: Partnerzy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partnerzy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPartnerzy,LinkTytul,Tytul,Tresc,Pozycja")] Partnerzy partnerzy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partnerzy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partnerzy);
        }

        // GET: Partnerzy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Partner == null)
            {
                return NotFound();
            }

            var partnerzy = await _context.Partner.FindAsync(id);
            if (partnerzy == null)
            {
                return NotFound();
            }
            return View(partnerzy);
        }

        // POST: Partnerzy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPartnerzy,LinkTytul,Tytul,Tresc,Pozycja")] Partnerzy partnerzy)
        {
            if (id != partnerzy.IdPartnerzy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partnerzy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerzyExists(partnerzy.IdPartnerzy))
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
            return View(partnerzy);
        }

        // GET: Partnerzy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Partner == null)
            {
                return NotFound();
            }

            var partnerzy = await _context.Partner
                .FirstOrDefaultAsync(m => m.IdPartnerzy == id);
            if (partnerzy == null)
            {
                return NotFound();
            }

            return View(partnerzy);
        }

        // POST: Partnerzy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Partner == null)
            {
                return Problem("Entity set 'FirmaContext.Partner'  is null.");
            }
            var partnerzy = await _context.Partner.FindAsync(id);
            if (partnerzy != null)
            {
                _context.Partner.Remove(partnerzy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerzyExists(int id)
        {
          return (_context.Partner?.Any(e => e.IdPartnerzy == id)).GetValueOrDefault();
        }
    }
}
