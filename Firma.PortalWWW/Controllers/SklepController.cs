using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly FirmaContext _context;
        public SklepController(FirmaContext context)
        {
            _context = context;
        }
        //funckja index wystawia wszytskie towary danego rodzaju widokowi index ze sklepu
        public async Task<IActionResult> Index(int? id)//w parametrze id bedzie przechowywana kliknieta kategoria towaru, katororia towaru bedzie nullem przy pierwszym wejsciu na strone
        {
            // var rodzaje = await _context.Rodzaj.ToListAsync();//wszystkie rodzaje, zeby nie wywolywac bazy//zakomentowany viewbag bo uzuwam componetow
            // ViewBag.Rodzaj = await _context.Rodzaj.ToListAsync();//przez viewbag przekazujem z kontrolera do widoku wszystkie rodzaje
            //przy pierwszym wejsciu do sklepu id kategori jest ppuste i podstawimy pod to piersza kategorie, tak zeby przy pierwszym wejsciu do sklepu wyswietlaly sie towary pierszej kategori (potem beda promowane)
            if (id ==null)
            {
               var pierwszy = await _context.Rodzaj.FirstAsync();//1 rodzaj ktory jest w bazie danych, jak firstordefault i wyswietlic erro czy nie wjest nullem
                id = pierwszy.IdRodzaju;
            }
            //do widoku przekazujemy wszystkie towary klliknietego rodzaju lub w przypadku pierwszego wejscia do sklepu wszystkie towary pierwszej kategorii
            return View(await _context.Towar.Where(t=>t.RodzajId == id).ToListAsync());
        }
        public async Task<IActionResult> Szczegoly(int? id)//w param id bvedzie umieszczone id kliknietego towaru ktorego szczegoly mamy wyswietlic 
        {
           // ViewBag.Rodzaj = await _context.Rodzaj.ToListAsync();//zakomentowany viewbag bo uzuwam componetow
           // return View(await _context.Towar.FirstOrDefaultAsync(t => t.IdTowaru == id));//zwracamy widok szczegoly i towary ktorego id jest rowne id z parametru
          //do widoku przekjazujemy towar o danym id ktory kliknieto (uzuj find) 
            return View(await _context.Towar.Where(t=>t.IdTowaru ==id).FirstOrDefaultAsync());//zwracamy widok szczegoly i towary ktorego id jest rowne id z parametru
        }
    }
}
