using Firma.Data.Data;
using Firma.Data.Data.Sklep;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    //to jest kontroler bazowy z niego beda dziedziczyc wszystkie kontrolery realizujace operacje elementarne CRUD 
    //nad base controllerem jest IController ktory zawiera CRUDY interfejs
    //klasa baseController uzywa typu generycznego TEntity pod ktory w przypadku towarow zostanie wyswietlony towar
    public abstract class BaseController<TEntity> : Controller where TEntity : class
    {
        protected readonly FirmaContext _context;//lepiej zrob propertisa zamiast protecked 
        
        public BaseController(FirmaContext context)
        {
            _context = context;
        }
        //funckja jest abstrakcyjna jezeli nie ma bloku(nie wiemy jak ja napisac dopiero wiemy jak ja napisac w klasach dziedziczacych jezeli klasa ma co najm 1 funckje abstarkcyja to klassa musi byc abstrakcyjna)
        public abstract Task<List<TEntity>> GetEntityList();//dla towarow bedzie to lista towarow
        //index wyswietla wszystkie towary
        public async Task<IActionResult> Index()
        {
            // z bazy danynych pobieray asynchronicznie liste wszystkich towarow 
            //  var list = await _context.Towar.Where(t=>t.IsActive ==true).ToListAsync();//where isActive
           // var list = await _context.Towar.Include(t => t.Rodzaj).ToListAsync();//where isActive//zamiast tego zrobimy funkcje abstrakcyjna
            //tu linq ktore pobiera kulumny ktore sa potrzebne
            //maper kolumn z bazy danych na widok ?
            //i przekazujemy ja do widoku,! view model (tutaj view model pobrac do funkcji index) ktore pola pobierac potem mapper ktory mapuje co pobierac 
            //.Include(t=>t.Rodzaj). include zaladowanie klucza opbcego
            var list = await GetEntityList();//do widoku tyo przekazauje raz towary , raz pracownikow
            return View(list);
        }
        //funcjka setselectlist inicjalizuje dane do wyboru w combobosie jezeli tabela (encja) bedzie miala klucze obce to wtedy nadpiszemy te funckje w klasach dziedziczacych
        // /jezeli tabela nie bedzie miala kluczy obcych to nie besdzuemy te funckje nadpisywac zwrocimy nulla
        //jak ma klucze obce to nadpiszemy jak nie ma to zwrocimy nulla
        
        public virtual Task SetSelectList()//tak funkcja ustawia dane do wyboru z comboboxa - selecta
        {
            return null;//gdy wszzystkie nasze tabele nie mialy klucze obce to wtedy abstacyjne, jak nie ma kluczy obcych to null
        }
        //to funcja uruchamia sie przy wejsciu na strone dodawania nowego towaru
        public async Task<IActionResult> CreateAsync()
        {
            await SetSelectList();//przed wywolanie widoku inicjalizujemy comboboxy funkcja setselectlist
            return View();//f create wywoluje,generuje widok o tej samej nazwie czyli create.cshtml
        }
        //to jest funckja ktora wywoluje sie po kliknieciu w przycisk create, ale jest jeszcze z dziedziczenia
        [HttpPost]
        public async Task<IActionResult> Create(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
