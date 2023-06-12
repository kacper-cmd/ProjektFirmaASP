using Firma.Data.Data;
using Firma.PortalWWW.Models.BusinessLogic;
using Firma.PortalWWW.Models.Sklep;
using Microsoft.AspNetCore.Mvc;

namespace Firma.PortalWWW.Controllers
{
    public class KoszykController : Controller
    {
        private readonly FirmaContext _context;//jak dziczyczy klasy baze

        public KoszykController(FirmaContext context)
        {
            _context = context;
        }
        //ta funckja wystawia dane do wyswietlania koszyka 
        public async Task<IActionResult> Index()
        {
            //tworze obiekt klasy logiki biznesowej koszykb zdefiniowanej w wewrastwie models z ktorego to obiektu bede uzywal 2 funcji 
            KoszykB koszykb = new KoszykB(this._context, this.HttpContext);
            var daneDoKoszyka = new DaneDoKoszyka//view model przekazuje dane do widoku
            {
                ElementyKoszyka = await koszykb.GetElementyKoszyka(),
                Razem = await koszykb.GetRazem() 
            };
              //w jednym obiekcjie przekazuje dwie rzeczy do widoku 
            return View(daneDoKoszyka);
        }
        public async Task<IActionResult> DodajDoKoszyka(int id)
        {
            KoszykB koszykb = new KoszykB(this._context, this.HttpContext);
            koszykb.DodajDoKoszyka(await _context.Towar.FindAsync(id));
            return RedirectToAction("Index");
        }
    }
}
