using Firma.Data.Data;
using Firma.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index(int? id)//to jest id strony ktora kliknieta
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
            //przy pierwszym uruchomieniu jeszcze nic nie kliknieto to bedziemy wyswietlac pierwsza strone
            if (id == null)
            {
                id = _context.Strona.First().IdStrony;
            }
            //wyszukujemy w bazie danych strone o danym kliknietym id lub piersza strone w przypdadku pierwszego uruchomienia
            //znaleziona strone przekazujemy do widoku
            var item = _context.Strona.Find(id);
            return View(item);
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