using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers
{
    public class PartnerzyController : Controller
    {
        private readonly FirmaContext _context;//tu jest baza danych
        //bazowy kontroller i z baza danych i dziedziczy z niego wszystkie kontrolery
        public PartnerzyController(FirmaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int id)//to jest id kliknietej aktualnosci id nie moge byc nullem
        {
            //viewbag to taki listonosz ktory przenosi dane miedzy kontrolerem a widokiem modelstrony to nazwa zmiennej 
            ViewBag.ModelStrony =
               await (
                   from strona in _context.Strona
                   orderby strona.Pozycja
                   select strona
               ).ToListAsync();

            ViewBag.Partnerzy =
               await (
                    from Partnerzy in _context.Partner
                    orderby Partnerzy.Pozycja
                    select Partnerzy
                ).ToListAsync();

            ViewBag.Parametry =
              await (
                    from Parametry in _context.Parametr
                    select Parametry
                ).ToListAsync();

            ViewBag.DodatkoweInformacje =
              await (
                    from DodatkoweInformacje in _context.DodatkoweInformacje
                    orderby DodatkoweInformacje.Pozycja
                    select DodatkoweInformacje
                ).ToListAsync();
            ViewBag.ModelAktualnosci =
              await (
                    from Aktualnosci in _context.Aktualnosc
                    orderby Aktualnosci.Pozycja
                    select Aktualnosci
                ).ToListAsync();

            //odnadujemy aktualnosc o danym kliknietym id i przekazujemy do widoku
            var item = await _context.Partner.FindAsync(id);
            return View(item);
        }
    }
}
