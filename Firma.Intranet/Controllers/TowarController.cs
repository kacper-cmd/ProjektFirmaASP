using Firma.Data.Data;
using Firma.Data.Data.Sklep;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class TowarController : BaseController<Towar> //pod <TEntity> podstawiamy <Towar> z BaseController.cs dzieczic bo basze kontroler a pod tentity podstaw towear
    {
        //klasa towarcontroller dziedziczy po basecontroller podstawiajac za TEntity towar  
        public TowarController(FirmaContext context)
            : base(context)
        {
        }
        //w towarze napisz funkcje getentitylist
        public override async Task<List<Towar>> GetEntityList()//towar zamiast <TEntity>//jak pracownicy kotroller to tylko to napisze
        {
            return await _context.Towar.Include(t => t.Rodzaj).ToListAsync();//lub okno modalne wybor rodzajow 
        }
       public override async Task SetSelectList()
        {
            //bobieramy wszystkie rodzaje z bazy danych
            var rodzaje = await _context.Rodzaj.ToListAsync();//_context.Rodzaj.Where(r => r.IsActive == true).ToListAsync();
            //do select listy przekjazujemy te rodzaje kazemy wybierac id rodzaju   a wyswietlamy nazwe
            ViewBag.Rodzaje = new SelectList(rodzaje, "IdRodzaju", "Nazwa");
        }


    }
}
