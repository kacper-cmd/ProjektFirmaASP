using Firma.Data.Data;
using Firma.Data.Data.Sklep;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Models.BusinessLogic
{
    public class KoszykB
    {
        private readonly FirmaContext _context;
        private string IdSesjiKoszyka { get; set; }//tu jest przechowywane id przegladarki
        public KoszykB(FirmaContext context, HttpContext httpContext)
        {
            _context = context;
            IdSesjiKoszyka = GetIdSesjiKoszyka(httpContext);
        }
        //to jest funckja ktora pobiera identyfikator przegladarki ktora laczy sie z systemem
        private string GetIdSesjiKoszyka(HttpContext httpContext)
        {
            //jezeli w sesji idSejsikoszyka jest nullem to trzeba to id sejsji wygenerowac
            if(httpContext.Session.GetString("IdSesjiKoszyka") == null)
            {
                //gerenuje to id sejsji koszyka na podstawie httpContext.User.Identity.Name 
                //jezeli to name nie jest puste lub nie ma bialych znakow 
                if(!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    //to wtedy httpContext.User.Identity.Name staje sie id sejsji koszyka
                    httpContext.Session.SetString("IdSesjiKoszyka", httpContext.User.Identity.Name);
                }
                else
                {
                    //w przeciwnym wypadku generujemy to id przy pomocy Guid.NewGuid()
                    Guid tempIdSesjiKoszyka = Guid.NewGuid();
                    //i wysylamy to wygenerowane id  jako cookie
                    httpContext.Session.SetString("IdSesjiKoszyka", tempIdSesjiKoszyka.ToString());
                }
            }
            return httpContext.Session.GetString("IdSesjiKoszyka").ToString();
        }
        //to jest funckja dodajace nowy towar do koszyka
        public void DodajDoKoszyka(Towar towar)
        {
            //najpierw sprawdzamy czy dany towar nie istnieje juz w koszyku danego klienta
            //var elementKoszyka = _context.ElementKoszyka.FirstOrDefault(
            //                   element => element.IdSesjiKoszyka == this.IdSesjiKoszyka && element.TowarId == towar.IdTowaru);
            var elementKoszyka = 
                (
                 from ek in _context.ElementKoszyka
                 where ek.IdSesjiKoszyka == this.IdSesjiKoszyka && ek.TowarId == towar.IdTowaru
                 select ek
                 ).FirstOrDefault();
            //jezeli towaru brak w koszyku 
            if(elementKoszyka == null)
            {
                //tworzymy towar koszyka
                //to dodajemy nowy element koszyka
                elementKoszyka = new ElementKoszyka()
                {
                    IdSesjiKoszyka = this.IdSesjiKoszyka,
                    TowarId = towar.IdTowaru,
                    Towar = _context.Towar.Find(towar.IdTowaru),
                    Ilosc = 1,
                    DataUtworzenia = DateTime.Now
                };
                //dodajemy element koszyka do bazy danych
                _context.ElementKoszyka.Add(elementKoszyka);
            }
            else
            {
                //jezeli towar juz istnieje w koszyku to zwiekszamy jego ilosc o 1
                elementKoszyka.Ilosc++;
            }
            //zapisujemy zmiany w bazie danych
            _context.SaveChanges();                

        }
        //funckja pobiera wszystkie elementy koszyka danej przegladarki
        public async Task<List<ElementKoszyka>> GetElementyKoszyka()
        {
            return await _context.ElementKoszyka.Where(e=>e.IdSesjiKoszyka==this.IdSesjiKoszyka).Include(e=>e.Towar).ToListAsync();
        }
        //funckja oblicza wartosc koszyka za ile pieniedzy kupilismy towary
        public async Task<decimal> GetRazem()
        {
            var items =
            (
                from element in _context.ElementKoszyka
                where element.IdSesjiKoszyka == this.IdSesjiKoszyka
                select (decimal?)element.Ilosc * element.Towar.Cena
            );//dla kazdego elementu ilosc * cena
            return await items.SumAsync() ?? 0;//albo suma albo zero jak nic nie ma
        }
    }
}


//logika biznesowa w osobnym projekcie (bo moze byc w mobilnej i webowej aplikacji)