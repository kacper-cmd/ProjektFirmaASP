using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace Firma.PortalWWW.Controllers
{
    public class AktualnoscController : Controller
    {
        private readonly FirmaContext _context;//tu jest baza danych
        //bazowy kontroller i z baza danych i dziedziczy z niego wszystkie kontrolery
        public AktualnoscController(FirmaContext context)
        {
            _context = context;
        }
        //tez index dziedziczyc moge, mozna to asynchronicznie zrobic
        public async Task<IActionResult> Index(int id)//to jest id kliknietej aktualnosci id nie moge byc nullem
        {
            //viewbag to taki listonosz ktory przenosi dane miedzy kontrolerem a widokiem modelstrony to nazwa zmiennej 
            ViewBag.ModelStrony =
                (
                    from strona in _context.Strona
                    orderby strona.Pozycja
                    select strona
                ).ToList();
            ViewBag.ModelAktualnosci =
               (
                   from aktualnosc in _context.Aktualnosc
                   orderby aktualnosc.Pozycja
                   select aktualnosc
               ).ToList();
            //odnadujemy aktualnosc o danym kliknietym id i przekazujemy do widoku
            var item = await _context.Aktualnosc.FindAsync(id);
            return View(item);
        }
    }
}
