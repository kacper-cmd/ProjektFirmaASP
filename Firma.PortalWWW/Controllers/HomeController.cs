using Firma.Data.Data;
using Firma.Data.Data.CMS;
using Firma.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Firma.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FirmaContext _context;//tu jest baza danych

        public HomeController(FirmaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)//to jest id strony ktora kliknieta
        {
            //viewbag to taki listonosz ktory przenosi dane miedzy kontrolerem a widokiem modelstrony to nazwa zmiennej 
            //ViewBag.ModelStrony =
            //    (
            //        from strona in _context.Strona
            //        orderby strona.Pozycja
            //        select strona
            //    ).ToList();
            //ViewBag.ModelAktualnosci =
            //   (
            //       from aktualnosc in _context.Aktualnosc
            //       orderby aktualnosc.Pozycja
            //       select aktualnosc
            //   ).ToList();
            //lub asynchronicznie
            var strony = await (
                from strona in _context.Strona
                orderby strona.Pozycja
                select strona
                ).ToListAsync();
            var aktualnosci = await (
               from aktualnosc in _context.Aktualnosc
               orderby aktualnosc.Pozycja
               select aktualnosc
               ).ToListAsync();//zamiast aktulnosci u ciebie ciekawe oferty
            ViewBag.ModelStrony = strony;
            ViewBag.ModelAktualnosci = aktualnosci;//edytutuj views-shared layoucshtml i przekaz do partial view viewbaga z aktualnosciami
                                                   // ViewBag.footerData = new Tuple<IEnumerable<Strona>, IEnumerable<Aktualnosc>>(strony, aktualnosci);//stwruktura wieloobiektowa

            ViewBag.DodatkoweInformacje =
             await  (
                   from DodatkoweInformacje in _context.DodatkoweInformacje
                   orderby DodatkoweInformacje.Pozycja
                   select DodatkoweInformacje
               ).ToListAsync();
            ViewBag.Partnerzy =
            await (
                  from Partnerzy in _context.Partner
                  orderby Partnerzy.Pozycja
                  select Partnerzy
              ).ToListAsync();

           // ViewBag.Partnerzy =
           //await (
           //        from partner in _context.Partner
           //        orderby partner.Pozycja
           //        select partner
           //    ).ToListAsync();
            //ViewBag.ModelParametry =
            //   (
            //     from parametr in _context.Parametry
            //     orderby parametr.Pozycja
            //     select parametr
            //   ).ToList();//to zle

            //przy pierwszym uruchomieniu jeszcze nic nie kliknieto to bedziemy wyswietlac pierwsza strone
            if (id == null)
            {
                id = _context.Strona.First().IdStrony;
            }
            //wyszukujemy w bazie danych strone o danym kliknietym id lub piersza strone w przypdadku pierwszego uruchomienia
            //znaleziona strone przekazujemy do widoku
            var item = await _context.Strona.FindAsync(id);
            return View(item);//edytuj layout i do partial biew przekaz viewbag//POTEM FO VIEWS hOME
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Kontakt()
        {
            return View();//widok bedzie nazywal sie tak samo jak funcja Kontakt
        }
        public IActionResult OFirmie()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}