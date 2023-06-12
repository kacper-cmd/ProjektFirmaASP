using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers
{
    public class RodzajeMenuComponent : ViewComponent
    {
        private readonly FirmaContext _context;

        public RodzajeMenuComponent(FirmaContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //do widoku RodzajeMenuComponent przekazuje wszystkie rodzaje z bazy danych async (bez uzycia ViewBag)
            return View("RodzajeMenuComponent", await _context.Rodzaj.ToListAsync());
        }
    }
}
