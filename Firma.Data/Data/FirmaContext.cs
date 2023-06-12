using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Data.Data.CMS;
using Firma.Data.Data.Sklep;
using Microsoft.EntityFrameworkCore;

namespace Firma.Data.Data
{
    //klasa firma context reprezentuje cala baze danych 
    //jak nie dziala to popraw :IdentityDbContext
    public class FirmaContext : DbContext
    {
        public FirmaContext(DbContextOptions<FirmaContext> options)
            : base(options)
        {
        }

        public DbSet<Strona> Strona { get; set; }

        public DbSet<Aktualnosc> Aktualnosc { get; set; }
        public DbSet<Rodzaj> Rodzaj { get; set; }
        public DbSet<Towar> Towar { get; set; }
        public DbSet<Parametry> Parametr { get; set; }
        public DbSet<Partnerzy> Partner { get; set; }
        public DbSet<ElementKoszyka> ElementKoszyka { get; set; }
        public DbSet<DodatkoweInformacje> DodatkoweInformacje { get; set; }//dodaj controlery w intranecie i w portalu tez kontrolery dodaj i views Aktualnosc a tam index  i w shared dodaj partial view PArtnerzy, odnoscniki dodtakowe informacje

    }
}


