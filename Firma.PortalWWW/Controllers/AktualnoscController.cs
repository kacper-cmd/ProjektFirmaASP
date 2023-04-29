using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index(int id)//to jest id kliknietej aktualnosci id nie moge byc nullem//tu klikne do kontretnej strony i ja wyswietlam
        {
            //viewbag to taki listonosz ktory przenosi dane miedzy kontrolerem a widokiem modelstrony to nazwa zmiennej 
            ViewBag.ModelStrony =
             await   (
                    from strona in _context.Strona
                    orderby strona.Pozycja
                    select strona
                ).ToListAsync();
            ViewBag.ModelAktualnosci =
             await (
                   from aktualnosc in _context.Aktualnosc
                   orderby aktualnosc.Pozycja
                   select aktualnosc
               ).ToListAsync();
            //ViewBag.Parametry =
            //   (
            //                     from parametr in _context.Parametr
            //                                       select parametr
            //                ).ToList();
            ViewBag.Partnerzy =
              await (
                                  from partner in _context.Partner
                                  orderby partner.Pozycja
                                  select partner
                ).ToListAsync();
            ViewBag.DodatkoweInformacje = await (
                                  from dodatkoweInformacje in _context.DodatkoweInformacje
                                  orderby dodatkoweInformacje.Pozycja
                                  select dodatkoweInformacje
             ).ToListAsync();
            //odnajdujemy aktualnosc o danym kliknietym id i przekazujemy do widoku
            var item = await _context.Aktualnosc.FindAsync(id);
            return View(item);//w aktualnosccontroller nacisnij PPM na Index funcja i dodaj add view razor view empty index.cshtml
        }
    }
}
